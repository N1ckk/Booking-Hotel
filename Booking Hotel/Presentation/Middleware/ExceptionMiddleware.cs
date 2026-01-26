using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net;
using System.Text.Json;

namespace Booking_Hotel.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = exception.Message;

            switch (exception)
            {
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case ArgumentNullException:
                    status = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var result = JsonSerializer.Serialize(new { error = message });
            return context.Response.WriteAsync(result);
        }
    }
}
