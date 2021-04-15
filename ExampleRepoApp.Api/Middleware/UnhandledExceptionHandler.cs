using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ExampleRepoApp.Api.Middleware
{
    public class UnhandledExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public UnhandledExceptionHandler(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        
        // Update this with specific exception handling conditions, as a general rule
        // Exception should only result from an unhandled scenario, unless you specifically want
        // a 500 (Internal Server Error) to be reported in which case either specify it here or
        // just allow it to fallback to the standard Exception handler anyway.
        // For example, client request problems should throw something like an ArgumentException 
        // which is caught below and translated into a BadRequest response... 

        public async Task InvokeAsync(HttpContext context)
        {
            try
            { 
                await _next(context);
            }
            catch (ArgumentException aex)
            {
                _logger.LogError(aex, aex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
    
    public static class ControllerExceptionHandlerExtension {  
        public static IApplicationBuilder UseUnhandledExceptionHandler(this IApplicationBuilder builder) {  
            return builder.UseMiddleware<UnhandledExceptionHandler>();  
        }  
    }
}