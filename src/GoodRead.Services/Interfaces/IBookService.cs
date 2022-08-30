using GoodRead.Services.Models.UserRead;
using GoodRead.Utilities.Responses;

namespace GoodRead.Services.Interfaces;

public interface IBookService
{
    Task<BaseResponse<List<BookDto>>> GetBooksAsync();

    Task<BaseResponse<List<BookDto>>> GetBooksByNameAsync(string name);

    Task<BaseResponse<UserReadCompleteDto>> GetCompletedReadingBooksAsync(int? userId);

    Task<BaseResponse<UserReadDto>> CreateUserReadBook(AddUserReadDto requestDto);

    Task<BaseResponse<UserReadDto>> UpdateBookStatusAsync(int id, UpdateBookStatusRequestDto requestDto);
}