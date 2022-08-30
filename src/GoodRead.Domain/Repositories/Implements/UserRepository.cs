
using GoodRead.Domain.Context;
using GoodRead.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodRead.Domain.Repositories.Implements;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}