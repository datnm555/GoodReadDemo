using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.DataAccess.Repositories.Interfaces;
using GoodRead.Services.Models.Book;
using GoodRead.Utilities.Responses;

namespace GoodRead.Services.Implements;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BaseResponse<List<BookDto>>> GetBooksAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<BookDto>> UpdateBookStatusAsync(UpdateBookStatusRequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<BookDto>> GetCompletedRedingBooksAsync(int? userId)
    {
        throw new NotImplementedException();
    }
}