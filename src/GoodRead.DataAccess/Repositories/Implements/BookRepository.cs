using GoodRead.DataAccess.Entities;

namespace GoodRead.DataAccess.Repositories.Implements;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(GoodReadDbContext dbContext) : base(dbContext)
    {
    }
}