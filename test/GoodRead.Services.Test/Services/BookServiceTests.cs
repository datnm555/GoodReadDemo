using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Repositories.Interfaces;
using GoodRead.Services.Implements;
using GoodRead.Services.Interfaces;
using GoodRead.Services.Models.Book;
using GoodRead.Services.Test.Base;
using Newtonsoft.Json;

namespace GoodRead.Services.Test.Services
{
    public class BookServiceTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        IBookService _bookService;

        public BookServiceTests(CustomWebApplicationFactory<Program> factory, IBookService bookService)
        {
            _factory = factory;
            _bookService = bookService;
        }

        [Fact]
        public async Task GetBooksAsyncTest()
        {
            var test = _factory.GetAnonymousClient();


            //var result = await _bookService.GetBooksAsync();
            
            //Assert.IsType<List<BookDto>>(result?.Results);
            //Assert.NotEmpty(result.Results);
        }

    }
}
