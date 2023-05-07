using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Controller]
	[YVAdminFilter]
	public class NewUserController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private IAccountService accountService;

		public NewUserController(ILogger<HomeController> logger,
			IAccountService accountService)
		{
			_logger = logger;
			this.accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Create-User")]
		public async Task<IActionResult> CreateUser(UserInfoModel model)
		{
			var stringValues = Request.Form["Avatar"];
			model.Avatar = Encoding.UTF8.GetBytes(stringValues);


			ViewBag.isCreateNewUser = false;
			bool isCreate = await this.accountService.CreateNewUser(model.GetUpdateInfoRequest());
			if (isCreate)
			{
				ViewBag.isCreateNewUser = true;
				Console.WriteLine("created");
			}

			return Redirect("/admin/NewUser");
		}

		[HttpPost]
		[ActionName("Check-Username")]
		public async Task<JsonResult> CheckUsername(string username)
		{
			bool exists = await accountService.CheckAccountExistsAsync(username);
			return Json(exists);
		}

	}
}
