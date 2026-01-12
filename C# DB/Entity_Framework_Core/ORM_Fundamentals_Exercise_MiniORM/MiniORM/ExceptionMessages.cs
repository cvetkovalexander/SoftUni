namespace MiniORM;

public static class ExceptionMessages
{
    public const string NullEntityAddedMessage = "Entity cannot be null.";

    public const string PopulateDbSetNotFoundMessage = 
        "There was an internal error while populating the DbSet. Please make sure that your AppDbContext inherits from the MiniORM DbContext.";

    public const string NullDbSetMessage = "There was an internal error while populating the DbSet.";

    public const string MapRelationsNotFoundMessage =
        "There was an internal error while mapping the relations. Please make sure that your AppDbContext inherits from the MiniORM DbContext.";

    public const string MapNavigationCollectionNotFoundMessage =
        "There was an internal error while mapping the navigation collection. Please make sure that your AppDbContext inherits from the MiniORM DbContext.";

    public const string InvalidEntitiesInDbSetMessage =
        "The DbSet contains invalid entities. Please make sure that the entities have valid primary key values.";
}
