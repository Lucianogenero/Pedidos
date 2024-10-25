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
            if (context.Exception is OrderExceptions orderException)
                HandleProjectException(orderException, context);
            else
                HandleUnknowException(context);
        }

        private void HandleProjectException(OrderExceptions orderException, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)orderException.GetStatusCode();
            context.Result = new BadRequestObjectResult(new ResponseErrorsJson(orderException.GetErrorMessages()));
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorsJson("UNKNOW_ERROR"));
        }

    }
}
