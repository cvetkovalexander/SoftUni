using EFInversionOfControl.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFInversionOfControl;

public class Repository : IRepository
{
    private readonly SoftUniDbContext _context;

    public Repository(SoftUniDbContext context)
    {
        this._context = context;
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await this._context.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
    {
        await this._context.Set<T>().AddRangeAsync(entities);
    }

    public IQueryable<T> All<T>() where T : class
        => this._context.Set<T>();

    public IQueryable<T> AllReadOnly<T>() where T : class
        => this._context.Set<T>().AsNoTracking();

    public async Task ExecuteBulkDelete<T>(Expression<Func<T, bool>> filter) where T : class
    {
        await this._context.Set<T>()
            .Where(filter)
            .ExecuteDeleteAsync();
    }

    public void Delete<T>(T entity) where T : class
    {
        this._context.Set<T>().Remove(entity);
    }

    public async Task<int> SaveChangesAsync() 
        => await this._context.SaveChangesAsync();

    public async Task<T?> GetByIdAsync<T>(object id) where T : class
        => await this._context.Set<T>().FindAsync(id);
}
