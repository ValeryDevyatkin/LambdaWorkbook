namespace LambdaWorkbook.Api.Application.Features.Common;

public class OperationResponse
{
    public bool Success { get; init; }
    public string? ErorMessage { get; init; }

    public static OperationResponse Failed(string? message)
    {
        return new OperationResponse
        {
            Success = false,
            ErorMessage = message
        };
    }

    public static OperationResponse Succeed()
    {
        return new OperationResponse
        {
            Success = true
        };
    }
}

public class OperationResponse<T> : OperationResponse
{
    public T? Result { get; init; }

    public static OperationResponse Succeed(T result)
    {
        return new OperationResponse<T>
        {
            Success = true,
            Result = result
        };
    }
}