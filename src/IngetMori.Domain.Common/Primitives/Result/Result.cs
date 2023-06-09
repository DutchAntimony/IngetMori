﻿namespace IngetMori.Domain.Common.Primitives.Result;

public class Result
{
   protected internal Result(bool isSuccess, Error error)
    {
        if (!isSuccess && error == Error.None) { throw new InvalidOperationException(); }
        if (isSuccess && error != Error.None) { throw new InvalidOperationException(); }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result<T> SuccessIfNotNull<T>(T? value, Error errorIfNull) =>
        value is not null ? Result<T>.Success(value) : Result<T>.Failure(errorIfNull);
    
    public static Result Failure(Error error) => new(false, error);

    public static Result AggregateResult(params Result[] results) => 
        results.All(result => result.IsSuccess) 
        ? Success() 
        : results.First(result => result.IsFailure);
}

public class Result<TValue> : Result
{
    private readonly TValue _value;
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => _value = value!;

    public TValue Value =>
        IsSuccess ? _value : throw new InvalidOperationException("Can't access the result of a failure. Verify the state first.");

    public static Result<TValue> Success(TValue value) => new(value, true, Error.None);

    public static new Result<TValue> Failure(Error error) => new(default!, false, error);

    public static Result<TValue> SuccessIfNotNull(TValue? value, Error errorIfNull) =>
        value is not null ? Success(value) : Failure(errorIfNull);


    public static implicit operator Result<TValue>(TValue value) => Success(value);
}