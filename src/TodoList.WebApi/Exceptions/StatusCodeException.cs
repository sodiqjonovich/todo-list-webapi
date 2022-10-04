﻿using System.Net;

namespace TodoList.WebApi.Exceptions;

public class StatusCodeException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public StatusCodeException(){}

    public StatusCodeException(HttpStatusCode httpStatusCode, string message) 
        : base(message)
    {
        this.HttpStatusCode = httpStatusCode;
    }
}
