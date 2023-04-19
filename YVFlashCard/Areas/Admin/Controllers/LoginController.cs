using DBModels.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YVFlashCard.Areas.Admin.Models;
using YVFlashCard.Helpers;
using YVFlashCard.Service.Interfaces;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using YVFlashCard.Service;

namespace YVFlashCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private IAccountService accountService;
        private IVisitCounterRepositoryService visitCountService = new VisitCounterRepositoryService();

        public LoginController(ILogger<LoginController> logger,
            IAccountService authorizationService)
        {
            _logger = logger;
            this.accountService = authorizationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["CurrenUser"] != null)
            {
                visitCountService.IncrementVisitCountAsync();
                Accounts account = (Accounts)HttpContext.Items["CurrenUser"];
                this._logger.LogInformation("Đã đăng nhập " + account.UserName);
                ViewBag.LoginSuccess = true;
                ViewBag.Account = account;
                return Redirect("/admin");
            }
            else
            {
                this._logger.LogInformation("Chưa đăng nhập");
                LoginModel model = new LoginModel();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            Console.WriteLine("logout ne");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            Accounts? account = await accountService.AuthenticateAsync(model.userName, model.password);

            if (account == null)
            {
                this._logger.LogInformation("login failed");
                ViewBag.LoginSuccess = false;
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Role, account.Role),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties()
                {

                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                visitCountService.IncrementVisitCountAsync();
                this._logger.LogInformation("login ok " + account.UserName);
                ViewBag.LoginSuccess = true;
                ViewBag.Account = account;
                return Redirect("/admin");
            }
        }

        public IActionResult SuccessPage()
        {
            return View();
        }
    }
}
