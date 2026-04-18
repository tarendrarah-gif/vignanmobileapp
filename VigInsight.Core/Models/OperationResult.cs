namespace VigInsight.Core.Models
{
    /// <summary>
    /// Generic wrapper returned by every service method so the
    /// controller can decide on HTTP status code without catching exceptions.
    /// </summary>
    public class OperationResult<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }

        private OperationResult() { }

        public static OperationResult<T> Ok(T data, string message = "Success")
            => new() { Success = true, Data = data, Message = message };

        public static OperationResult<T> Fail(string message)
            => new() { Success = false, Message = message };
    }
}
