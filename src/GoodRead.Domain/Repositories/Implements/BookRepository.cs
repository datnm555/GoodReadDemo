
using GoodRead.Domain.Context;
using GoodRead.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodRead.Domain.Repositories.Implements;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Book> GetBooksQueryable(string bookName)
    {
        var bookQueryable = DbSet.AsNoTracking();

        if (!string.IsNullOrEmpty(bookName))
        {
            bookQueryable = bookQueryable.Where(x => x.Name.Equals(bookName));
        }
        return bookQueryable;
    }
}