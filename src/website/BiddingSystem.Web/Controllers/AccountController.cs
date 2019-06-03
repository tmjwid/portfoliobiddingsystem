using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Common;
using BiddingSystem.Models;
using BiddingSystem.Models.Account;
using BiddingSystem.Services.Contracts;


namespace BiddingSystem.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly IDashboardService dashboardService;

        public AccountController(IUserService userService, IProductService productService, IDashboardService dashboardService)
        {
            this.userService = userService;
            this.productService = productService;
            this.dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return Dashboard();
        }

        public IActionResult Login()
        {
            bool isLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel loginModel)
        {
            bool isLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return Json("Already Logged in ");
            }
            bool authed = userService.Login(loginModel);
            if (authed)
            {
                List<Claim> claims = new List<Claim>() { new Claim("user", loginModel.EmailAddress) };
                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "LoginCookie", "user", "role")));
                return RedirectToAction("Index", "Home");
            }
            return View(new UserModel() { Message = "We couldn't log you in." });
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            bool isLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            DashboardModel dashboard = dashboardService.GetUsersDashboard(HttpContext.User.Identity.Name);
            var errors = GetMessage();
            if (errors != null)
            {
                dashboard.Message = errors.Message;    
            }
            return View(dashboard);
        }

        [Authorize]
        public IActionResult Edit()
        {
            UserModel user = userService.GetFullUser(HttpContext.User.Identity.Name);
            return View(user);
        }
    }
}