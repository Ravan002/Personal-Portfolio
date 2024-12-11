namespace Core.Helpers.Results.Concrete
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult(T data, string message) : base(data, message, true)
        {

        }
        public SuccesDataResult(T data) : base(data, true)
        {

        }
        public SuccesDataResult(string message) : base(default, message, true)
        {

        }
        public SuccesDataResult() : base(default, true)
        {

        }
    }
}
