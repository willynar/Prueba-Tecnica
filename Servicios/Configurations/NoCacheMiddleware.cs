using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Services.Configurations
{
    public class NoCacheMiddleware
    {
        private readonly RequestDelegate m_next;
        public NoCacheMiddleware(RequestDelegate next)
        {
            m_next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                httpContext.Response.OnStarting((state) =>
                {
                    // ref: http://stackoverflow.com/questions/49547/making-sure-a-web-page-is-not-cached-across-all-browsers
                    httpContext.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
                    httpContext.Response.Headers.Append("Pragma", "no-cache");
                    httpContext.Response.Headers.Append("Expires", "0");
                    return Task.FromResult(0);
                }, null);
                await m_next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
