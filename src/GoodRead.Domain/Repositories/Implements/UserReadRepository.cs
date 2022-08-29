using GoodRead.Domain.Context;
using GoodRead.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodRead.Domain.Repositories.Implements
{
    internal class UserReadRepository : GenericRepository<UserRead>, IUserReadRepository
    {
        public UserReadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
