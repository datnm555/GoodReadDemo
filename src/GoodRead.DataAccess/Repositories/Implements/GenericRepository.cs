

namespace GoodRead.DataAccess.Repositories.Implements;

public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
{
    private readonly GoodReadDbContext _dbContext;
    private readonly DbSet<T> _dbSet;


    public GenericRepository(GoodReadDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<T>();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>>? filter)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return query;
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, string includeProperties = "")
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return query.ToList();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
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