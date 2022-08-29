
namespace GoodRead.Domain.Repositories.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    IQueryable<Book> GetBooksQueryable(string bookName);
}