using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YVFlashCard.Areas.Admin.Middleware
{
	public class YVAdminFilterAttribute : Attribute, IAuthorizationFilter
    {

		public YVAdminFilterAttribute()
		{
			
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			Accounts accounts = (Accounts)context.HttpContext.Items["CurrenUser"];
			if (accounts == null)
			{
				context.Result = new UnauthorizedResult();
				return;
            }

			if (accounts.Role != "A")
			{
				Console.WriteLine("da dang nhap nhung chua du quyen");
				context.Result = new ObjectResult(null)
				{
					StatusCode = 403,
				};
			}
		}
	}
}
