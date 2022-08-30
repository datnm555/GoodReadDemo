using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Api.Test.Base;
using GoodRead.Services.Models.Book;
using Newtonsoft.Json;
using Xunit;

namespace GoodRead.Api.Test.Controller
{
    public class BookControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public BookControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<BookDto>>(responseString);

            Assert.IsType<List<BookDto>>(result);
            Assert.NotEmpty(result);
        }

    }
}
