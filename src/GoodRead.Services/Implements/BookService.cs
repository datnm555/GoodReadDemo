using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Entities;
using GoodRead.Domain.Repositories.Interfaces;
using GoodRead.Services.Models.Book;
using GoodRead.Services.Models.UserRead;
using GoodRead.Utilities.Constants;
using GoodRead.Utilities.Exceptions;
using GoodRead.Utilities.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodRead.Services.Implements;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper, IUserReadRepository userReadRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<BaseResponse<List<BookDto>>> GetBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return new BaseResponse<List<BookDto>>(_mapper.Map<List<BookDto>>(books));
    }

    public async Task<BaseResponse<List<BookDto>>> GetBooksByNameAsync(string bookName)
    {
        var bookQueryable = _bookRepository.Find(x => x.Name.Contains(bookName));
        var books = await bookQueryable.ToListAsync();
        return new BaseResponse<List<BookDto>>(_mapper.Map<List<BookDto>>(books));
    }

    public async Task<BaseResponse<BookDto>> UpdateBookStatusAsync(UpdateBookStatusRequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<UserReadCompleteDto>> GetCompletedReadingBooksAsync(int? userId)
    {
        if (userId == null)
        {
            throw new BadRequestException("Userid is null");
        }

        var booksRead = await _userReadRepository.Find(x => x.UserId == userId && x.Status == (int)Constants.BookStatus.Completed).Include(x=>x.Book).ToListAsync();
        var userReadDtos = _mapper.Map<List<UserReadDto>>(booksRead);
        var result = _mapper.Map<UserReadCompleteDto>(userReadDtos);
        result.UserId = userId.Value;
        return new BaseResponse<UserReadCompleteDto>(result);
    }
}