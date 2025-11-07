using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using WareHouse.Application.Common.Exceptions;
using WareHouse.Application.Common.Models;
using AccessViolationException = WareHouse.Application.Common.Exceptions.AccessViolationException;

namespace WareHouse.Api.Infrastructure.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var result = new ApiError();

                switch (ex)
                {
                    case ValidationException validationException:
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.Message = validationException.Message;
                        break;

                    case NotFoundException notFoundException:
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                        result.Message = notFoundException.Message;
                        break;

                    case AccessViolationException accessViolationException:
                        result.StatusCode = (int)HttpStatusCode.Forbidden;
                        result.Message = accessViolationException.Message;
                        break;

                    default:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = ex.Message;
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = result.StatusCode;
                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
