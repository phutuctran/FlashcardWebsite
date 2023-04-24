using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YVFlashCard.App_Start;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    [YVAdminFilter]
    public class UserInfosController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService accountService;

        public UserInfosController(ILogger<HomeController> logger,
            IAccountService accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string keySearch = "", int page = 1)
        {
            List<UserDTO> users;
            users = await this.accountService.GetAccountsAsync(keySearch, page * DefaultValue.PageSize);
            
            List<UserInfoModel> userInfoModels = new List<UserInfoModel>();
            users.ForEach(i => userInfoModels.Add(new UserInfoModel(i)));
            ViewBag.CurrentAccountPage = page;
            ViewBag.KeySearch = keySearch;
            return View(userInfoModels);
        }

        [HttpPost]
        [ActionName("update-Password")]
        public async Task<IActionResult> UpdateInfo(UserInfoModel model)
        {
            await this.accountService.UpdatePassword(model.GetUpdateInfoRequest());
            await this.accountService.UpdateInfo(model.GetUpdateInfoRequest());
            return Redirect($"/admin/UserInfos?page={Request.Form["currentPage"]}&keySearch={Request.Form["KeySearch"]}");
        }

        [HttpPost]
        public async Task<JsonResult> CheckUsernameExist(string userName)
        {
            return Json(await this.accountService.CheckAccountExistsAsync(userName));
        }

    }
}
