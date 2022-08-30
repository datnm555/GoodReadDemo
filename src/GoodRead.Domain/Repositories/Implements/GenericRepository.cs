

using System.Linq.Expressions;
using GoodRead.Domain.Context;
using GoodRead.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodRead.Domain.Repositories.Implements;

public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    protected DbSet<T> DbSet;


    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = _dbContext.Set<T>();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>>? filter, bool tracking = true)
    {
        var query = DbSet.AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return query;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter, bool tracking = true)
    {
        var query = DbSet.AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>>? filter, bool tracking = true)
    {
        var query = DbSet.AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.SingleOrDefaultAsync() ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "")
    {
        IQueryable<T> query = DbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }


    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}