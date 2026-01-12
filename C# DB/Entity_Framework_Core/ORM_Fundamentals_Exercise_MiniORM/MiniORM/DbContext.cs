using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Reflection.Metadata;

namespace MiniORM;

// TODO: Implement SaveChanges, Persist and InitializeDbSets methods.

public abstract class DbContext
{
    private readonly DatabaseConnection _connection;

    private readonly IDictionary<Type, PropertyInfo> _dbSetProperties;

    protected DbContext(string connectionString)
    {
        this._connection = new DatabaseConnection(connectionString);
        this._dbSetProperties = this.DiscoverDbSets();
        using (new ConnectionManager(this._connection)) 
        {
            this.InitializeDbSets();
        }

        this.MapAllRelations();
    }

    internal static ICollection<Type> AllowedSqlTypes = new HashSet<Type>()
    {
        typeof(string),
        typeof(char),
        typeof(bool),
        typeof(byte),
        typeof(short),
        typeof(int),
        typeof(long),
        typeof(float),
        typeof(double),
        typeof(decimal),
        typeof(DateTime),
        typeof(TimeSpan),
        typeof(DateOnly),
        typeof(TimeOnly)
    };

    public void SaveChanges() 
    {
        
    }

    private IDictionary<Type, PropertyInfo> DiscoverDbSets() =>
            this.GetType()
            .GetProperties()
            .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

    private void InitializeDbSets()
    {
        foreach (KeyValuePair<Type, PropertyInfo> dbSetPropertyPair in this._dbSetProperties) 
        {
            Type entityType = dbSetPropertyPair.Key;
            PropertyInfo dbSetProperty = dbSetPropertyPair.Value;

            MethodInfo? populateDbSetMethodGeneric = this.GetType()
                .GetMethod(nameof(PopulateDbSet), BindingFlags.Instance | BindingFlags.NonPublic)?
                .MakeGenericMethod(entityType);

            if (populateDbSetMethodGeneric == null)
                throw new InvalidOperationException(ExceptionMessages.PopulateDbSetNotFoundMessage);

            populateDbSetMethodGeneric.Invoke(this, new object[] { dbSetProperty });
        }
    }

    private void PopulateDbSet<TEntity>(PropertyInfo dbSetPropertyInfo) 
        where TEntity : class, new()
    {
        IEnumerable<TEntity> tableEntities = this.LoadTableEntities<TEntity>();
        DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(tableEntities);

        ReflectionHelper.ReplaceBackingField(this, dbSetPropertyInfo.Name, dbSetInstance);
    }

    private IEnumerable<TEntity> LoadTableEntities<TEntity>()
        where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);
        string[] columnNames = this.GetEntityColumnNames(entityType).ToArray();
        string tableName = this.GetTableName(entityType);

        IEnumerable<TEntity> tableEntities = this._connection
            .FetchResultSet<TEntity>(tableName, columnNames);

        return tableEntities;
    }

    private IEnumerable<string> GetEntityColumnNames(Type entityType) 
    {
        string tableName = this.GetTableName(entityType);
        IEnumerable<string> columnNames = this._connection
            .FetchColumnNames(tableName);

        IEnumerable<string> entityColumnNames = entityType
            .GetProperties()
            .Where(pi => columnNames.Contains(pi.Name, StringComparer.InvariantCultureIgnoreCase) &&
            pi.HasAttribute<NotMappedAttribute>() == false &&
            AllowedSqlTypes.Contains(pi.PropertyType))
            .Select(pi => pi.Name)
            .ToArray();

        return entityColumnNames;
    }

    private string GetTableName(Type entityType) 
    {
        string? tableName = entityType.GetCustomAttribute<TableAttribute>()?.Name;
        if (tableName == null) 
            tableName = this._dbSetProperties[entityType].Name;

        return tableName;
    }

    private void MapAllRelations()
    {
        foreach (KeyValuePair<Type, PropertyInfo> dbSetPropertyPair in this._dbSetProperties) 
        {
            Type entityType = dbSetPropertyPair.Key;
            object? dbSetInstance = dbSetPropertyPair.Value.GetValue(this);
            if (dbSetInstance == null) 
                throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);

            MethodInfo? mapRelationsMethodGeneric = this.GetType()
                .GetMethod(nameof(MapRelations), BindingFlags.Instance | BindingFlags.NonPublic)?
                .MakeGenericMethod(entityType);
            if (mapRelationsMethodGeneric == null)
                throw new InvalidOperationException(ExceptionMessages.MapRelationsNotFoundMessage);

            mapRelationsMethodGeneric.Invoke(this, new object[] { dbSetInstance });
        }
    }

    private void MapRelations<TEntity>(DbSet<TEntity> dbSetInstance) 
        where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);
        this.MapNavigationProperties(dbSetInstance);

        PropertyInfo[] navigationCollectionsProperties = entityType
            .GetProperties()
            .Where(pi => pi.PropertyType.IsGenericType &&
                         pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                         this._dbSetProperties.ContainsKey(pi.PropertyType.GetGenericArguments().First()))
                         .ToArray();

        foreach (PropertyInfo navigationCollectionPropInfo in navigationCollectionsProperties) 
        {
            Type collectionEntityType = navigationCollectionPropInfo.PropertyType.GetGenericArguments().First();

            MethodInfo? mapCollectionMethodGeneric = this.GetType()
                .GetMethod(nameof(MapNavigationCollection), BindingFlags.Instance | BindingFlags.NonPublic)?
                .MakeGenericMethod(entityType, collectionEntityType);

            if (mapCollectionMethodGeneric == null)
                throw new InvalidOperationException(ExceptionMessages.MapNavigationCollectionNotFoundMessage);

            mapCollectionMethodGeneric.Invoke(this, new object[] { dbSetInstance, navigationCollectionPropInfo });
        }
    }

    private void MapNavigationCollection<TEntity, TCollectionEntity>(DbSet<TEntity> dbSetInstance, PropertyInfo navigationCollectionPropertyInfo)
        where TEntity : class, new()
        where TCollectionEntity : class, new()
    {
        Type entityType = typeof(TEntity);
        Type collectionEntityType = typeof(TCollectionEntity);

        PropertyInfo[] collectionEntityPrimaryKeys = collectionEntityType
            .GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        PropertyInfo collectionPrimaryKey = collectionEntityPrimaryKeys.First();

        PropertyInfo entityPrimaryKey = entityType
            .GetProperties()
            .First(pi => pi.HasAttribute<KeyAttribute>());

        bool isManyToMany = collectionEntityPrimaryKeys.Length > 1;

        if (isManyToMany) 
        {
            collectionPrimaryKey = collectionEntityType
                .GetProperties()
                .First(pi => collectionEntityType.GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name).PropertyType == entityType);
        }

        DbSet<TCollectionEntity>? navCollectionDbSet = 
            (DbSet<TCollectionEntity>?)this._dbSetProperties[collectionEntityType].GetValue(this);

        if (navCollectionDbSet == null)
            throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);

        foreach (TEntity entity in dbSetInstance) 
        {
            object entityPrimaryKeyValue = entityPrimaryKey.GetValue(entity);
            ICollection<TCollectionEntity> navigationEntities = navCollectionDbSet
                .Where(ne => collectionPrimaryKey.GetValue(ne).Equals(entityPrimaryKeyValue))
                .ToArray();

            ReflectionHelper.ReplaceBackingField(dbSetInstance, navigationCollectionPropertyInfo.Name, navigationEntities);
        }
    }

    private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSetInstance)
        where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);
        PropertyInfo[] foreignKeyProperties = entityType
            .GetProperties()
            .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
            .ToArray();

        foreach (PropertyInfo foreignKeyProperty in foreignKeyProperties) 
        {
            string navigationPropertyName = foreignKeyProperty
                .GetCustomAttribute<ForeignKeyAttribute>()!
                .Name;

            PropertyInfo navigationProperty = entityType
                .GetProperties()
                .First(pi => pi.Name == navigationPropertyName);

            object? navigationDbSetInstance = this._dbSetProperties[navigationProperty.PropertyType].GetValue(this);

            if (navigationDbSetInstance == null)
                throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);

            PropertyInfo navigationPrimaryKey = navigationProperty
                .PropertyType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            foreach (TEntity entity in dbSetInstance) 
            {
                object foreignKeyValue = foreignKeyProperty.GetValue(entity);
                if (foreignKeyValue == null)
                    continue;

                object navigationEntity = ((IEnumerable<object>)navigationDbSetInstance)
                    .First(ne => navigationPrimaryKey.GetValue(ne)!.Equals(foreignKeyValue));

                navigationProperty.SetValue(entity, navigationEntity);
            }
        }
    }

    private static bool IsObjectValid(object obj) 
    {
        ValidationContext validationContext = new ValidationContext(obj);
        IList<ValidationResult> validationResults = new List<ValidationResult>();

        return Validator.TryValidateObject(obj, validationContext, validationResults);
    }
}
