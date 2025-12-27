using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult ShowError(
               string errorMessage,
               string? errorTitle = null,
               string? returnUrl = null,
               string? returnText = null
               )
        {
            var error = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorTitle = errorTitle ?? "錯誤",
                ErrorMessage = errorMessage,
                ReturnUrl = returnUrl,
                ReturnText = returnText
            };
            return View("Error", error);
        }
        protected IActionResult HandleException(
            Exception ex,
            string? userFriendlyMessage = null,
            string? returnUrl = null,
              string? returnText = null
            )
        {
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            var error = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorTitle = "系統錯誤",
                ErrorMessage = userFriendlyMessage ?? "系統發生錯誤",
                ErrorDetails = isDevelopment ? $"{ex.GetType().Name}: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}" :  string.Empty,
                ReturnUrl = returnUrl,
                ReturnText = returnText
            };

            return View("Error", error);
        }
        protected IActionResult ShowNotFound(
            string resourceName,
            object? resourceId = null,
           string? returnUrl = null,
            string? returnText = null
       )
        {
            var message = resourceId != null
                ? $"找不到{resourceName}(ID:{resourceId})"
                : $"找不到指定的{resourceName}";
            return ShowError(
                errorMessage: message,
                errorTitle: "找不到資源",
                returnUrl: returnUrl,
                returnText: returnText
                );
        }
    }
}

