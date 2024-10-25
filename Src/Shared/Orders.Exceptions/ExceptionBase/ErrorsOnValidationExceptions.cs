using System.Net;

namespace Orders.Exceptions.ExceptionBase
{
    public class ErrorsOnValidationExceptions : OrderExceptions
    {
        private IList<string> _errorMessages { get; set; }

        public ErrorsOnValidationExceptions(IList<string> errorsMessages) : base(string.Empty)
        {
            _errorMessages = errorsMessages;
        }
        public override IList<string> GetErrorMessages() => _errorMessages;
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;

    }
}
