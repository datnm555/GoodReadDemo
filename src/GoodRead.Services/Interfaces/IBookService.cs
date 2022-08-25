using GoodRead.Services.Models.Book;
using GoodRead.Utilities.Responses;

namespace GoodRead.Services.Interfaces;

public interface IBookService
{
    Task<BaseResponse<List<BookDto>>> GetBooksAsync(string name);

    Task<BaseResponse<BookDto>> UpdateBookStatusAsync(UpdateBookStatusRequestDto requestDto);

    Task<BaseResponse<BookDto>> GetCompletedReadingBooksAsync(int? userId);

}