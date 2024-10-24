namespace Orders.Exceptions.ExceptionBase
{
    public class ErrorsOnValidationExceptions : OrderExceptions
    {
        public List<string> ErrorsMessages { get; set; }

        public ErrorsOnValidationExceptions(List<string> errorsMessages) => ErrorsMessages = errorsMessages;
    }
}
