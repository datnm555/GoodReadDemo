using GoodRead.DataAccess.Entities;
namespace GoodRead.DataAccess.Context;
public class GoodReadDbContext : DbContext
{
    public GoodReadDbContext(DbContextOptions<GoodReadDbContext> options) : base(options)
    {
    }

    public List<User> Users { get; set; }
    public List<Book> Books { get; set; }
    public List<ReadActivity> ReadActivities { get; set; }
    

    //Because this is sample so i did not create unit Of Work class for manage transaction and delegate dispose, so i override Savechange in this class

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    //we can remove hard code  when we have authorization and create the currentUser from httpcontext
                    entry.Entity.CreatedBy = "Admin";
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTime.Now;
                    //we can remove hard code when we have authorization and create the currentUser from httpcontext
                    entry.Entity.ModifiedBy = "Admin";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

   

}
