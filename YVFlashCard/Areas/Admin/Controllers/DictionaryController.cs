using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Claims;
using YVFlashCard.App_Start;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;
using YVFlashCard.Service.Users.DTO;
using YVFlashCard.Service.Vocabularies;
using YVFlashCard.Service.Vocabularies.DTO;

namespace YVFlashCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    [YVAdminFilter]
    public class DictionaryController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IDictionaryWordService _dictionaryService;
        private IThemeService _themeService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public DictionaryController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor,
            IDictionaryWordService dictionaryService, IThemeService themeService)
        {
            _logger = logger;
            this._dictionaryService = dictionaryService;
            this._themeService = themeService;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchKey = "", int page = 1)
        {
			//get theme
			List<ThemeDTO> themeDTOs = await this._themeService.GetThemeByAdminAsync(page * DefaultValue.PageSize, searchKey);
			List<ThemeModel> themes = new List<ThemeModel>();
			themeDTOs.ForEach(i => themes.Add(new ThemeModel(i)));
			
            //get Vocabulary
			List<VocabularyDTO> vobDTOs = await this._dictionaryService.GetVocabularyAsync(new GetVocabularyByAdmin(page * DefaultValue.PageSize, searchKey));
            List<VocabularyModel> vobs = new List<VocabularyModel>();
            vobDTOs.ForEach(i => vobs.Add(new VocabularyModel(i)));
            
			ViewBag.CurrentPage = page;
            ViewBag.KeySearch = searchKey;
			HttpContext httpContext = _httpContextAccessor.HttpContext;
			if (httpContext.User.Claims.Any(u => u.Type == ClaimTypes.Name))
			{
				//Console.WriteLine("found");
				ViewBag.Username = httpContext.User.Claims.First(u => u.Type == ClaimTypes.Name).Value;
			}
            return View(vobs);
        }

        [HttpPost]
        [ActionName("update-Password")]
        public async Task<IActionResult> UpdateInfo(UserInfoModel model)
        {
            return Redirect("/admin/UserInfos");
        }
    }
}
