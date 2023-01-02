using GCB.Comum.Comandos;
using GCB.Comum.Excecoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using ValidationException = GCB.Comum.Excecoes.ValidationException;

namespace GCB.Comum.Filtros
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
            };

            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext> value))
            {
                value.Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            _logger.LogError($"Exception: {context.Exception};\n\tActionDescriptor: {context.ActionDescriptor.DisplayName}");

            var details = new CommandResult(
                 "⚠ Ops, algo deu errado!",
                 context.Exception.Message
            );

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new CommandResult(
                HttpStatusCode.BadRequest,
                exception.Message,
                exception.Errors
            );

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new CommandResult(
                HttpStatusCode.NotFound,
                exception.Message,
                null
            );

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
