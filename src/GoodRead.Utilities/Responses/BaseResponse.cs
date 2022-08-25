using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Utilities.Responses;

public class BaseResponse<T>
{
    public BaseResponse()
    {
        Success = true;
    }

    public BaseResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public BaseResponse(string message = null)
    {
        Success = true;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Results { get; set; }
}