﻿namespace TodoList.WebApi.ViewModels.Common
{
    public class ErrorResponseViewModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = String.Empty;

        public ErrorResponseViewModel() {}

        public ErrorResponseViewModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
