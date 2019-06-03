using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Models;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MessageViewModel {  });
        }
    }
}
