using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Common;
using BiddingSystem.Models;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Web.Controllers
{
    public class BidController : BaseController
    {
        private readonly IBidService bidService;
        private readonly IUserService userService;
        public BidController(IBidService bidService, IUserService userService)
        {
            this.bidService = bidService;
            this.userService = userService;
        }

        public IActionResult AcceptBid(int bidID)
        {
            Guid userID = userService.GetUserID(HttpContext.User.Identity.Name);
            DatabaseCode result = bidService.AcceptBid(bidID, userID);
            if (result == DatabaseCode.Updated)
            {
                SetMessage(new MessageViewModel() { Message = "Bid has been accepted and the contractor has been notified." });
            }
            else if (result == DatabaseCode.NotAllowed)
            {
                SetMessage(new MessageViewModel() { Message = "You cannot accept a bid for a product you didn't make. This has been logged." });
            }
            else
            {
                SetMessage(new MessageViewModel() { Message = "Sorry but an error has occured." });
            }
            return RedirectToAction("Dashboard", "Account");
        }

        public IActionResult DeclineBid(int bidID)
        {
            Guid userID = userService.GetUserID(HttpContext.User.Identity.Name);
            (int productid, DatabaseCode result) = bidService.DeclineBid(bidID, userID);
            if (result == DatabaseCode.Updated)
            {
                SetMessage(new MessageViewModel() { Message = "Bid has been declined and the contractor has been notified." });
            }
            else if (result == DatabaseCode.NotAllowed)
            {
                SetMessage(new MessageViewModel() { Message = "You cannot decline a bid for a product you didn't make. This has been logged." });
            }
            else
            {
                SetMessage(new MessageViewModel() { Message = "Sorry but an error has occured." });
            }
            return RedirectToAction("View", "Product", new { productid });
        }

        public IActionResult Cancel(int productID, int bidID)
        {
            Guid userID = userService.GetUserID(HttpContext.User.Identity.Name);
            DatabaseCode result = bidService.CancelBid(bidID, userID);
            if (result == DatabaseCode.Updated)
            {
                SetMessage(new MessageViewModel() { Message = "Your bid has been cancelled" });
            }
            else if (result == DatabaseCode.NotAllowed)
            {
                SetMessage(new MessageViewModel() { Message = "You cannot cancel a bid you didn't place. This has been logged." });
            }
            else
            {
                SetMessage(new MessageViewModel() { Message = "Sorry but an error has occured." });
            }
            return RedirectToAction("View", "Product", new { productid = productID });
        }
    }
}


