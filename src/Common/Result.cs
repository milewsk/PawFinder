namespace Common;

public class Result
{
    // Properties
    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;
    public Error? Error { get; set; }

    // Constructors
    public Result(bool isSuccess, Error error)
    {
        if ((IsSuccess && error != Error.None) || (!IsSuccess && error == Error.None))
        {
            throw new ArgumentException("Error object is not valid", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);
}