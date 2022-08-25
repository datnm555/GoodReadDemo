// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GoodRead.Api.Controllers;

public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetBooks(string name)
    {
        return Ok(await _bookService.GetBooksAsync(name));
    }

    [HttpGet]
    [Route("get-completed-reading-book/{userId}")]
    public async Task<IActionResult> GetCompletedReadingBooks(int? userId = null)
    {
        return Ok(await _bookService.GetCompletedReadingBooksAsync(userId));
    }

    [HttpPut("update-book-status")]
    public async Task<IActionResult> UpdateBookStatus([FromBody] UpdateBookStatusRequestDto requestDto)
    {
        return Ok(await _bookService.UpdateBookStatusAsync(requestDto));
    }
}
