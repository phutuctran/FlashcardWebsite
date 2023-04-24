using Microsoft.AspNetCore.Mvc;
using DBModels;
using DBModels.Models;
using YVFlashCard.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using YVFlashCard.Service.Interfaces;
using System.Security.Claims;
using YVFlashCard.Areas.Admin.Middleware;
using YVFlashCard.Service.Users.DTO;
using YVFlashCard.Service;
using YVFlashCard.Service.VisitCounter;

namespace YVFlashCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    [YVAdminFilter]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService accountService;
        private IVisitCounterRepositoryService visitCounterRepositoryService = new VisitCounterRepositoryService();

        public HomeController(ILogger<HomeController> logger,
            IAccountService accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ViewBag.VisitCount = await visitCounterRepositoryService.GetVisitCountAsync();
            return View();
        }
    }
}
