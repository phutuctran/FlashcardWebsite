using DBModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace YVFlashCard.Areas.Admin.Controllers
{
	public class BaseController : Controller
	{
		public BaseController()
		{

		}

		protected AuthUserAbstract getCurrentUser()
		{
			//Null object design pattern
			if (HttpContext.Items.ContainsKey("CurrentUser"))
			{
				Accounts account = (Accounts)HttpContext.Items["CurrentUser"];

				if (account.Role == "A")
					return new AuthUserAdmin(account);
				return new AuthUserRegular(account);
			}

			return new AnonymousUser();
		}
	}

	public abstract class AuthUserAbstract
	{
		public string UserName { get; set; }
		public string Role { get; set; }

		/// <summary>
		/// Trả về true nếu người dùng đã đăng nhập
		/// </summary>
		/// <returns></returns>
		public abstract bool IsAuthenticated();
	}

	class AuthUserAdmin : AuthUserAbstract
	{
		public AuthUserAdmin(Accounts account)
		{
			this.UserName = account.UserName;
			this.Role = account.Role;
			if (account.Role != "A")
				throw new Exception($"Unknown permission {account.Role}");
		}

		public override bool IsAuthenticated()
		{
			return true;
		}
	}

    class AuthUserRegular : AuthUserAbstract
    {
        public AuthUserRegular(Accounts account)
        {
			this.UserName = account.UserName;
			this.Role = account.Role;
            if (account.Role != "A")
                throw new Exception($"Unknown permission {account.Role}");
        }

        public override bool IsAuthenticated()
        {
            return true;
        }
    }

    class AnonymousUser : AuthUserAbstract
	{
		public override bool IsAuthenticated()
		{
			return false;
		}
	}
}
