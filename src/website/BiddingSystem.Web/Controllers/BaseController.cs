using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Models;

namespace BiddingSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected MessageViewModel GetMessage()
        {
            MessageViewModel message = TempData.Get<MessageViewModel>("Message");
            if (message == null)
            {
                return new MessageViewModel(){ShowMessage = false};
            }
            TempData.Remove("Message");
            return message;
        }

        protected void SetMessage(MessageViewModel error)
        {
            error.ShowMessage = true;
            TempData.Remove("Message");
            TempData.Set("Message", error); 
        }
    }
}