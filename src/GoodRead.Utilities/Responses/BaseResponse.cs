﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Utilities.Responses;

public class BaseResponse<T>
{
    public BaseResponse(T results)
    {
        Results = results;
        Success = true;
        StatusCode = (int)HttpStatusCode.OK;
    }

    public BaseResponse(bool success, string message, T results)
    {
        Success = success;
        Message = message;
        Results = results;
    }

    public BaseResponse(T results, string message = null)
    {
        Success = true;
        Results = results;
        Message = message;
    }

    public int StatusCode { get; set; } 
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Results { get; set; }
}