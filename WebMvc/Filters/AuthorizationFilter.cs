using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebMvc.Models;

namespace WebMvc.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        private const string ValidRole = "User";


        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await Task.Delay(10);
            var userRole = "User";
            bool isAuthenticated = userRole == ValidRole;
            if (!isAuthenticated)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = context.HttpContext.TraceIdentifier,
                    ErrorTitle = "授權失敗",
                    ErrorMessage = "你沒有權限",
                    ReturnUrl = "/",
                    ReturnText = "返回首頁"
                };
                context.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<ErrorViewModel>(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                    {
                        Model = errorViewModel
                    }

                };
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
