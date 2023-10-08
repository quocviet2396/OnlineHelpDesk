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
            var allowedActions = new List<string> { "CheckPassword", "ChangePassword", "ForgotPassword" }; // Thay thế bởi danh sách các action được phép

            // Kiểm tra xem action hiện tại có trong danh sách được phép không
            var actionName = context.ActionDescriptor.RouteValues["action"];
            if (string.IsNullOrEmpty(accEmail) && !allowedActions.Contains(actionName))
            {
                // Chuyển hướng đến trang đăng nhập
                context.Result = new RedirectResult("/Authen/Login");
            }
        }
    }
}