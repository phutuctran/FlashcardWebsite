using DBModels.Models;
using Microsoft.AspNetCore.Mvc;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    [YVAdminFilter]
    public class DictionaryController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService accountService;

        public DictionaryController(ILogger<HomeController> logger,
            IAccountService accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserDTO> accounts = await this.accountService.GetAllAccountsAsync();
            ViewBag.Accounts = accounts;
            UserInfoModel UserInfoUpdateModel = new UserInfoModel();
            return View(UserInfoUpdateModel);
        }

        [HttpPost]
        [ActionName("update-Password")]
        public async Task<IActionResult> UpdateInfo(UserInfoModel model)
        {
            //Console.WriteLine(model);
            await this.accountService.UpdatePassword(model.GetUpdateInfoRequest());
            await this.accountService.UpdateInfo(model.GetUpdateInfoRequest());
            return Redirect("/admin/UserInfos");
        }
    }
}
