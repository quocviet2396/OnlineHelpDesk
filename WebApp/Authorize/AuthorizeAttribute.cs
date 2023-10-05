using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Authorize
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            string accEmail = httpContext.Session.GetString("accEmail");

            if (string.IsNullOrEmpty(accEmail))
            {
                // Chuyển hướng đến trang đăng nhập
                context.Result = new RedirectResult("/Authen/Login");
            }
        }
    }
}