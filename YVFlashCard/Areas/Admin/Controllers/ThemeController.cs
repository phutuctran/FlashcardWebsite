using DBModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;
using YVFlashCard.App_Start;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;

namespace YVFlashCard.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Controller]
	[YVAdminFilter]
	public class ThemeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private IThemeService _themeService;

		public ThemeController(ILogger<HomeController> logger,
			IThemeService themeService)
		{
			_logger = logger;
			this._themeService = themeService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string keySearch = "", int page = 1)
		{
			List<ThemeDTO> themeDTOs = await this._themeService.GetThemeByAdminAsync(page * DefaultValue.PageSize, keySearch);
			List<ThemeModel> themes = new List<ThemeModel>();
			themeDTOs.ForEach(i => themes.Add(new ThemeModel(i)));
			ViewBag.CurrentPage = page;
			ViewBag.KeySearch = keySearch;
			return View(themes);
		}

		[HttpPost]
		[ActionName("update-theme")]
		public async Task<IActionResult> UpdateInfo(ThemeModel model)
		{

			await this._themeService.UpdateThemeAsync(model);
			return Redirect($"/admin/Theme?page={Request.Form["currentPage"]}&keySearch={Request.Form["keySearch"]}");
		}

		[HttpPost]
		[ActionName("create-theme")]
		public async Task<IActionResult> CreateInfo(ThemeModel model)
		{
			var stringValues = Request.Form["IlluImg"];
			model.IllustrationImg = Encoding.UTF8.GetBytes(stringValues);
			await this._themeService.CreateNewThemeAsync(model);
			ViewBag.CreateSuccess = true;
			return Redirect($"/admin/Theme?page={Request.Form["currentPage"]}&keySearch={Request.Form["keySearch"]}");
		}
	}
}
