using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Services.Contracts;

namespace Namespace
{
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;
        private readonly IUserService userService;
        public NotificationController(INotificationService notificationService, IUserService userService)
        {
            this.notificationService = notificationService;
            this.userService = userService;
        }
        public IActionResult Read(int id)
        {
            Guid userID = userService.GetUserID(HttpContext.User.Identity.Name);
            notificationService.MarkAsRead(id, userID);
            return RedirectToAction("Dashboard", "Account");
        }
    }
}