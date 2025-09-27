using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp_Net_Core_Mvc_Store.Filters
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _authKey;

        public AuthFilter(string authKey)
        {
            _authKey = authKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? specifiedKey = context.HttpContext.Request.Query["key"];

            if (specifiedKey != _authKey)
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
        }
    }
}
