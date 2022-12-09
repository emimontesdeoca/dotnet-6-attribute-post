using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet6CustomAttribute.Attributes
{
    public class HeaderCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get all headers
            var headers = context.HttpContext.Request.Headers;

            // Check if headers has x-dotnet-6-custom-attribute
            if (!headers.ContainsKey("x-dotnet-6-custom-attribute"))
            {
                context.Result = new BadRequestObjectResult("The header x-dotnet-6-custom-attribute is missing");
            }
            else if (string.IsNullOrEmpty(headers["x-dotnet-6-custom-attribute"]))
            {
                context.Result = new BadRequestObjectResult("The header x-dotnet-6-custom-attribute can't be null or empty");
            }

            base.OnActionExecuting(context);
        }
    }
}
