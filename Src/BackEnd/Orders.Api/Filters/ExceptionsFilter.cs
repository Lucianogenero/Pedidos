using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Orders.Comunication.Response;
using Orders.Exceptions.ExceptionBase;
using System.Net;

namespace Orders.Api.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is OrderExceptions)
                HandleProjectException(context);
            else
                HandleUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorsOnValidationExceptions)
            {
                var exception = context.Exception as ErrorsOnValidationExceptions;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorsJson(exception.ErrorsMessages));
            }
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorsJson("UNKNOW_ERROR"));
        }

    }
}
