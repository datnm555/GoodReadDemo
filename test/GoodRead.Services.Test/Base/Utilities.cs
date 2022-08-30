using GoodRead.Domain.Context;
using GoodRead.Domain.Entities;

namespace GoodRead.Services.Test.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var user = new User
                {
                    Name = "TestUser",
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now

                };
                context.Users.Add(user);
            }

            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new()
                    {
                        Name = "Connan",
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now
                    },
                    new()
                    {
                        Name = "Doremon",
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now
                    },
                    new()
                    {
                        Name = "Harry Potter",
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now
                    }
                };
                context.Books.AddRange(books);

            }
            context.SaveChanges();
        }
    }
}
