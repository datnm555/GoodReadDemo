using GoodRead.Services.Models.Book;
using GoodRead.Utilities.Responses;

namespace GoodRead.Services.Interfaces;

public interface IBookService
{
    Task<BaseResponse<BookDto>> SearchBook(string name);







}