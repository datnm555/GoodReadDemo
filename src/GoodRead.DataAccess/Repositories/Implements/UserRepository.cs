namespace GoodRead.DataAccess.Repositories.Implements;

internal class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(GoodReadDbContext dbContext) : base(dbContext)
    {
    }


}