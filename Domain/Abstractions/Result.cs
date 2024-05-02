namespace Domain.Abstractions
{
    public class Result
    {
        private Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        private bool IsSuccess { get; }

        public bool IsFailure
        {
            get { return !IsSuccess; }
        }

        public Error Error { get; }

        public static Result Success
        {
            get { return new(true, Error.None); }
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
    }
}