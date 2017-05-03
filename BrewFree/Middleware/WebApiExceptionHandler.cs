using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BrewFree.Middleware
{
    public class WebApiExceptionHandler
    {
        private readonly RequestDelegate next;

        public WebApiExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                if (context.Request.Path.StartsWithSegments("/api"))
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    // todo: log the error in app insights
                    return;
                }

                throw;
            }
        }
    }
}
