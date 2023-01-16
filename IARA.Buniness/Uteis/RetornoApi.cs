using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace IARA.Buniness.Uteis
{
    public class RetornoApi
    {
        public bool IsSuccess => !Errors.Any();
        public int ResultCode { get; set; } = StatusCodes.Status200OK;
        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public RetornoApi SetResultCode(int resultCode)
        {
            ResultCode = resultCode;
            return this;
        }
    }

    public class RetornoApi<T> : RetornoApi
    {
        public T Data { get; set; }

        public RetornoApi SetData(T data)
        {
            Data = data;
            return this;
        }
    }
}

