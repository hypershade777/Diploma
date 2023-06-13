using Microsoft.AspNetCore.Mvc.Filters;

namespace NotesWEBApi.Filters
{
    public class CookieFilter : IActionFilter
    {
        private readonly string _cookieName;
        private readonly string _userId;

        public CookieFilter()
        {
            _cookieName = "userId";
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cookieValue = context.HttpContext.Request.Cookies[_cookieName];
            if (string.IsNullOrEmpty(cookieValue))
            {
                cookieValue = _userId;
            }

            context.ActionArguments["userId"] = cookieValue;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do nothing
        }
    }
}
