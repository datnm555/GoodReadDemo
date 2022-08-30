using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoodRead.Utilities.Responses;

public class ErrorResponse<T> : BaseResponse<T>
{
    public List<string> Errors { get; set; }

    public ErrorResponse(bool success, HttpStatusCode statusCode, List<string> errors) : base(success, statusCode)
    {
        Errors = errors;
    }
}