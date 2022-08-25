namespace GoodRead.DataAccess.Context;
public class GoodReadDbContext : DbContext
{
    protected GoodReadDbContext()
    {
    }

    public GoodReadDbContext(DbContextOptions options) : base(options)
    {
    }

    public List<User> Users { get; set; }
    public List<Book> Books { get; set; }
    public List<Author> Authors { get; set; }
    public List<Publisher> Publishers { get; set; }
}
