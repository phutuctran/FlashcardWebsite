using DBModels.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using YVFlashCard.Service.Interfaces;

namespace YVFlashCard.Areas.Admin.Middleware
{
	public class YVAuthenticationMiddleware
	{
        private readonly RequestDelegate _next;

        public YVAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMessageWriter is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext, IAccountService accountService)
        {
            if (httpContext.User.Claims.Any(u => u.Type == ClaimTypes.Name))
            {
                //Console.WriteLine("found");
                string username = httpContext.User.Claims.First(u => u.Type == ClaimTypes.Name).Value;

                Accounts loginedAccount = await accountService.GetAccountByUsernameAsync(username);
                httpContext.Items["CurrenUser"] = loginedAccount;
            }
            else
            {
                Console.WriteLine("not found cookie");
            }

            await _next(httpContext);
        }

	}
}
