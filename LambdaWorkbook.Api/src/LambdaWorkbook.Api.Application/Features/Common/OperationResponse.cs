namespace LambdaWorkbook.Api.Application.Features.Common;

public class OperationResponse
{
    public bool Failed { get; init; }
    public string? ErorMessage { get; init; }

    public static OperationResponse Fail(string? message)
    {
        return new OperationResponse
        {
            Failed = true,
            ErorMessage = message
        };
    }

    public static OperationResponse Success()
    {
        return new OperationResponse
        {
        };
    }
}

public class OperationResponse<T> : OperationResponse
{
    public T? Result { get; init; }

    public static new OperationResponse<T> Fail(string? message)
    {
        return new OperationResponse<T>
        {
            Failed = false,
            ErorMessage = message
        };
    }

    public static OperationResponse<T> Success(T result)
    {
        return new OperationResponse<T>
        {
            Result = result
        };
    }
}