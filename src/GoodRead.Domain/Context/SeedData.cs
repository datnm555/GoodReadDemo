using Microsoft.Extensions.DependencyInjection;

namespace GoodRead.Domain.Context;

public class SeedData
{
    public static void AddDataInMemory(ApplicationDbContext context)
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