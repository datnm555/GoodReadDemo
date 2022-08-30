using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GoodRead.Domain.Context;

public static class SeedData
{
    public static void AddDataInMemory(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

        var user = new User()
        {
            Name = "User1",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now
            
        };
        db.Users.Add(user);

        var books = new List<Book>()
        {
            new Book()
            {
                Name = "Book1",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            },
            new Book()
            {
                Name = "Book2",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            },
            new Book()
            {
                Name = "Book3",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            }
        };
        db.Books.AddRange(books);

        db.SaveChanges();
    }
}