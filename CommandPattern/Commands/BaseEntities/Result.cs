﻿namespace CommandPattern.Commands.BaseEntities;

public class Result<T>
{
    public T Data { get; set; }
    public string Error { get; set; }
    public bool IsSuccess => string.IsNullOrEmpty(Error);
    
    public Result(T value, string errorMessage)
    {
        Data = value;
        Error = errorMessage;
    }
    public static Result<T> Success(T value) => new(value, null);
    public static Result<T> Failure(string errorMessage) => new(default, errorMessage);
}