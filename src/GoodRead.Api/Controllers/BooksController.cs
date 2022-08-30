// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using GoodRead.Services.Models.UserRead;

namespace GoodRead.Api.Controllers;

/// <summary>
/// book controller
/// </summary>
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    /// <summary>
    /// book constructor
    /// </summary>
    /// <param name="bookService"></param>
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Get all books
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await _bookService.GetBooksAsync());
    }

    /// <summary>
    /// Get books by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get-books-by-name/{name}")]
    public async Task<IActionResult> GetBooksByName(string name)
    {
        return Ok(await _bookService.GetBooksByNameAsync(name));
    }

    /// <summary>
    /// Get books have completed status
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get-completed-reading-book/{userId}")]
    public async Task<IActionResult> GetCompletedReadingBooks(int? userId = null)
    {
        return Ok(await _bookService.GetCompletedReadingBooksAsync(userId));
    }
    
    /// <summary>
    /// update book status 
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [HttpPost("create-user-read-book")]
    public async Task<IActionResult> CreateUserReadBook([FromBody] AddUserReadDto requestDto)
    {
        return Ok(await _bookService.CreateUserReadBook(requestDto));
    }

    /// <summary>
    /// update book status 
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [HttpPut("update-book-status/{id}")]
    public async Task<IActionResult> UpdateBookStatus(int id, [FromBody] UpdateBookStatusRequestDto requestDto)
    {
        return Ok(await _bookService.UpdateBookStatusAsync(id,requestDto));
    }
}
