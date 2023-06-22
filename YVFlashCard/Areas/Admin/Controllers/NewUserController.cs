using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
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
		private readonly IWebHostEnvironment _hostEnvironment;

		public NewUserController(ILogger<HomeController> logger,
			IAccountService accountService,
			IWebHostEnvironment hostEnvironment)
		{
			_logger = logger;
			this.accountService = accountService;
			_hostEnvironment = hostEnvironment;	
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
			model.Avatar = null;
			var byteArray = Encoding.UTF8.GetBytes(Request.Form["Avatar"]);
			//System.IO.File.WriteAllBytes("D:\\test.txt", byteArray);
			if (byteArray != null)
			{
				model.Avatar = byteArray;
			}
			

			

			ViewBag.isCreateNewUser = false;
			bool isCreate = await this.accountService.CreateNewUserAsync(model.GetUpdateInfoRequest());
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
