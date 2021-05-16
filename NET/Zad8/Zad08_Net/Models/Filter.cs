using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad08_Net.Models
{
    public class Filter : ResultFilterAttribute
    {
        public string ClientIP { get; private set; }


        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            ClientIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = (PageResult)context.Result;
            result.ViewData["IPAddress"] = ClientIP;
            await next.Invoke();
        }
    }
}
