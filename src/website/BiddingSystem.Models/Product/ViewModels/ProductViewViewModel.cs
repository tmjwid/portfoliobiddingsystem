using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;

namespace BiddingSystem.Models.Product.ViewModels
{
    public class ProductViewViewModel : MessageViewModel
    {
        public ProductModel Product { get; set; }
        public BidModel Bid { get; set; }

    }
}