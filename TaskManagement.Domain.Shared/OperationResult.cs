
namespace TaskManagement.Domain.Shared;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string CatchMessage { get; set; }

    protected OperationResult(bool isSuccess = default, string message = default, string catchMessage = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        CatchMessage = catchMessage;
    }

    public static OperationResult Success(string message = default)
        => new OperationResult(isSuccess: true, message: message);
    public static OperationResult Failed(string message = "", string catchMessage = "")
        => new OperationResult(isSuccess: false, message: message, catchMessage: catchMessage);
}
public class OperationResult<T> : OperationResult
{
    public T Data { get; set; }

    protected OperationResult(bool isSuccess = default, string message = default, string catchMessage = default, T data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        CatchMessage = catchMessage;
        Data = data;
    }

    public static OperationResult<T> Success(T data, string message = default)
        => new OperationResult<T>(isSuccess: true, message: message, data: data);
    public static OperationResult<T> Failed(string message = "", string catchMessage = "")
        => new OperationResult<T>(isSuccess: false, message: message, catchMessage: catchMessage);
}
public class PaginationOperationResult<T> : OperationResult<T>
{
    public int OutCount { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }

    private PaginationOperationResult(
        int outCount = 0,
        int page = 0,
        int perPage = 0,
        bool isSuccess = default,
        string message = default,
        string catchMessage = default,
        T data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        CatchMessage = catchMessage;
        Data = data;
        OutCount = outCount;
        Page = page;
        PerPage = perPage;
    }

    public static PaginationOperationResult<T> Success(T data, int outCount, string message = default)
        => new PaginationOperationResult<T>(
            outCount: outCount,
            isSuccess: true,
            message: message,
            data: data);
    public static PaginationOperationResult<T> Failed(string message = "", string catchMessage = "")
        => new PaginationOperationResult<T>(
            isSuccess: false,
            message: message,
            catchMessage: catchMessage);
}