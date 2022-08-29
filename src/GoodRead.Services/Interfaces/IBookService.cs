﻿using GoodRead.Services.Models.Book;
using GoodRead.Utilities.Responses;

namespace GoodRead.Services.Interfaces;

public interface IBookService
{
    Task<BaseResponse<List<BookDto>>> GetBooksAsync();

    Task<BaseResponse<List<BookDto>>> GetBooksByNameAsync(string name);

    Task<BaseResponse<BookDto>> UpdateBookStatusAsync(UpdateBookStatusRequestDto requestDto);

    Task<BaseResponse<BookDto>> GetCompletedReadingBooksAsync(int? userId);

}