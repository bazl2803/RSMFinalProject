namespace Domain.Abstractions
{
    public class Result<TSuccess, TFailure>
    {
        private readonly TSuccess _successValue;
        private readonly TFailure _failureValue;
        private readonly bool _isSuccess;

        public Result(TSuccess successValue)
        {
            _successValue = successValue;
            _isSuccess = true;
        }

        public Result(TFailure failureValue)
        {
            _failureValue = failureValue;
            _isSuccess = false;
        }

        public bool IsSuccess => _isSuccess;

        public TSuccess Value
        {
            get
            {
                if (!_isSuccess)
                {
                    throw new InvalidOperationException("Result is not successful");
                }
                return _successValue;
            }
        }

        public TFailure Error
        {
            get
            {
                if (_isSuccess)
                {
                    throw new InvalidOperationException("Result is successful");
                }
                return _failureValue;
            }
        }

        public static Result<TSuccess, TFailure> Ok(TSuccess value) => new Result<TSuccess, TFailure>(value);
        public static Result<TSuccess, TFailure> Fail(TFailure error) => new Result<TSuccess, TFailure>(error);

        public TResult Match<TResult>(
            Func<TSuccess, TResult> success,
            Func<TFailure, TResult> failure)
        {
            if (_isSuccess)
            {
                return success(_successValue);
            }
            else
            {
                return failure(_failureValue);
            }
        }
    }

}