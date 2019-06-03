using System.Collections.Generic;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;

namespace BiddingSystem.Models.Account
{
    public class DashboardModel : MessageViewModel
    {
        public List<ProductModel> CurrentProducts;

        public UserModel User { get; set; }
        public List<NotificationModel> Notifications { get; set; }
        public List<ProductModel> MyProducts { get; set; }
        public List<ProductModel> NewProducts { get; set; }
        public List<ProductModel> OldProducts { get; set; }
    }
}