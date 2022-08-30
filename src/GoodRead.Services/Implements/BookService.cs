using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GoodRead.Domain.Entities;
using GoodRead.Domain.Repositories.Interfaces;
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
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper, IUserReadRepository userReadRepository, IUserRepository userRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _userReadRepository = userReadRepository;
        _userRepository = userRepository;
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

    public async Task<BaseResponse<UserReadCompleteDto>> GetCompletedReadingBooksAsync(int? userId)
    {
        if (userId == null || userId == 0)
        {
            throw new BadRequestException("UserId must be not null or zero");
        }

        var booksRead = await _mapper.ProjectTo<UserReadDto>( _userReadRepository
                .Find(x => x.UserId == userId && x.Status == (int)Constants.BookStatus.Completed)
                .Include(x => x.Book)).ToListAsync();
        var userReadDtos = _mapper.Map<List<UserReadDto>>(booksRead);
        var userReadBookDtos = _mapper.ProjectTo<UserReadBookDto>(userReadDtos.AsQueryable().Select(x=>x)).ToList();

        var userReadCompleteDto = new UserReadCompleteDto();
        userReadCompleteDto.UserId = userId.Value;
        userReadCompleteDto.UserReadBookDtos = userReadBookDtos;
        return new BaseResponse<UserReadCompleteDto>(userReadCompleteDto);
    }

    public async Task<BaseResponse<UserReadDto>> CreateUserReadBook(AddUserReadDto requestDto)
    {
        var book = await _bookRepository.GetByIdAsync(requestDto.BookId);
        if (book == null)
        {
            throw new NotFoundException(nameof(Book), requestDto.BookId);
        }
        var user = await _userRepository.GetByIdAsync(requestDto.UserId);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), requestDto.BookId);
        }

        var userRead =
            await _userReadRepository.FirstOrDefaultAsync(x => x.BookId == requestDto.BookId && x.UserId == requestDto.UserId);
        if (userRead != null)
        {
            throw new BadRequestException("Book exist in user's store");
        }

        var userReadMap = _mapper.Map<UserRead>(requestDto);
        var userReadAdd = await _userReadRepository.AddAsync(userReadMap);

        return new BaseResponse<UserReadDto>(_mapper.Map<UserReadDto>(userReadAdd));
    }

    public async Task<BaseResponse<UserReadDto>> UpdateBookStatusAsync(int id, UpdateBookStatusRequestDto requestDto)
    {
        var userRead = await _userReadRepository.GetByIdAsync(id);
        if (userRead == null)
        {
            throw new NotFoundException(nameof(UserRead), id);
        }

        userRead.Status = requestDto.Status;
        await _userReadRepository.UpdateAsync(userRead);

        return new BaseResponse<UserReadDto>(_mapper.Map<UserReadDto>(userRead));
    }
}