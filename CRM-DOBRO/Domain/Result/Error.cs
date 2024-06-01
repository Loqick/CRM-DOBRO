﻿namespace Domain.Result
{
    public class Error(string code, string? message)
    {
        public string Code { get; set; } = code;
        public string? Message { get; set; } = message;
    }
}
