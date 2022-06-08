using BaseDomainEntity.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ApplicationException = BaseDomainEntity.Errors.ApplicationException;

namespace Companies.Application.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
            => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = GetStatusCode(ex);
            var response = new
            {
                title = GetTitle(ex),
                status = statusCode,
                detaul = ex.Message,
                errors = GetErrors(ex)
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception ex)
        {
            IReadOnlyDictionary<string, string[]> errors = null;
            if (ex is ValidationException validationException)
                errors = validationException.ErrorsDictionary;
            return errors;
        }

        private static string GetTitle(Exception ex)
            => ex switch
            {
                ApplicationException applicationException => applicationException.Title,
                _ => "Server Error"
            };

        private static int GetStatusCode(Exception ex)
            => ex switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
