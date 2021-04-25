using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Extensions
{
    public class AuditFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public AuditFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = context.HttpContext.User.Identity.Name + " Access the page " +
                    context.HttpContext.Request.GetDisplayUrl() + " Information Test 1: ?? " +
                    context.HttpContext.TraceIdentifier.TrimEnd() + " Information Test 2: ?? " +
                    context.HttpContext.Features.ToString();

                _logger.Info(message);
            }
            
        }

        public void OnActionExecuting(ActionExecutingContext context){}
    }
}
