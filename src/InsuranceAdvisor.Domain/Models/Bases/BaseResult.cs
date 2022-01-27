namespace InsuranceAdvisor.Domain.Services
{
    public class BaseResult
    {
        public bool IsValid { get => !Messages.Any(); }
        public List<string> Messages { get; }
        public Exception? Error { get; set; }

        public BaseResult() => Messages = new List<string>();
        public BaseResult(string message) => Messages = new List<string>() { message };
        public BaseResult(List<string> messages) => Messages = messages;
        public BaseResult(string message, Exception exception)
        {
            Messages = new List<string>() { message };
            Error = exception;
        }
        public BaseResult(List<string> messages, Exception exception)
        {
            Messages = messages;
            Error = exception;
        }
    }

    public class BaseResult<T> : BaseResult
    {
        public T? Data { get; set; }

        public BaseResult() : base() { }
        public BaseResult(string mensagem) : base(mensagem) { }
        public BaseResult(List<string> mensagens) : base(mensagens) { }
        public BaseResult(string mensagem, Exception ex) : base(mensagem, ex) { }
        public BaseResult(List<string> mensagens, Exception ex) : base(mensagens, ex) { }
        public static BaseResult<T> New(T value) => new BaseResult<T> { Data = value };
    }
}