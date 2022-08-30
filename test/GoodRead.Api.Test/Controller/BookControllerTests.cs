using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Api.Test.Base;
using GoodRead.Services.Models.Book;
using GoodRead.Utilities.Responses;
using Newtonsoft.Json;

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
        public async Task GetBpoks()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Books");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse<List<BookDto>>>(responseString);

            Assert.IsType<List<BookDto>>(result?.Results);
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public async Task GetBooksByName()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("get-books-by-name/na");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse<List<BookDto>>>(responseString);

            Assert.IsType<List<BookDto>>(result?.Results);
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public async Task GetCompletedReadingBooks()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Books/get-completed-reading-book/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse<List<BookDto>>>(responseString);

            Assert.IsType<List<BookDto>>(result?.Results);
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public async Task CreateUserReadBook()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Books/create-user-read-book");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse<List<BookDto>>>(responseString);

            Assert.IsType<List<BookDto>>(result?.Results);
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public async Task UpdateBookStatus()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Books/update-book-status/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse<List<BookDto>>>(responseString);

            Assert.IsType<List<BookDto>>(result?.Results);
            Assert.NotEmpty(result.Results);
        }

    }
}
