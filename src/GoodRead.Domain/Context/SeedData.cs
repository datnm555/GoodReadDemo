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
                Name = "User1",
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
                    Name = "Book1",
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new()
                {
                    Name = "Book2",
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new()
                {
                    Name = "Book3",
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                }
            };
            context.Books.AddRange(books);

        }
        context.SaveChanges();
    }
}