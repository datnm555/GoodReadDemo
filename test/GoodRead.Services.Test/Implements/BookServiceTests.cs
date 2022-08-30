using GoodRead.Domain.Context;
using GoodRead.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace GoodRead.Services.Test.Implements;

[TestFixture]
public class BookServiceTests
{
    public  static DbContextOptions<ApplicationDbContext> DbContextOptions  = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GoodReadDb").Options;
    ApplicationDbContext context;


    [OneTimeSetUp]
    public void SetUp(IBookService bookService)
    {
        context = new ApplicationDbContext(DbContextOptions);
        context.Database.EnsureCreated();
        SeedDatabase();

    }

    private void SeedDatabase()
    {
        throw new NotImplementedException();
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        context.Database.EnsureDeleted();
    }

    [Test()]
    public void GetBooksAsyncTest()
    {
        Assert.Fail();
    }

    [Test()]
    public void GetBooksByNameAsyncTest()
    {
        Assert.Fail();
    }

    [Test()]
    public void GetCompletedReadingBooksAsyncTest()
    {
        Assert.Fail();
    }

    [Test()]
    public void CreateUserReadBookTest()
    {
        Assert.Fail();
    }

    [Test()]
    public void UpdateBookStatusAsyncTest()
    {
        Assert.Fail();
    }
}