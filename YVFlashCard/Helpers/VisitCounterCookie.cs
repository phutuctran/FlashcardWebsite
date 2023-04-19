using Microsoft.AspNetCore.Http;
using System;

namespace YVFlashCard.Helpers
{
    public static class VisitCounterCookieHelper
    {
        public static void IncreaseVisitCount(HttpContext context)
        {
            if (!context.Request.Cookies.ContainsKey("VisitCount"))
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1)
                };
                context.Response.Cookies.Append("VisitCount", "1", options);
            }
        }

        public static int GetVisitCount(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("VisitCount", out string value))
            {
                if (int.TryParse(value, out int count))
                {
                    return count;
                }
            }
            return 0;
        }
        
        public static void DeleteVisitCountCookie(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("VisitCount"))
            {
                context.Response.Cookies.Delete("VisitCount");
            }
        }
    }
}
