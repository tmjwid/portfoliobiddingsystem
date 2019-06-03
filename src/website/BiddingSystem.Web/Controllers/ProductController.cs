using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BiddingSystem.Common;
using BiddingSystem.Models;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;
using BiddingSystem.Models.Product.ViewModels;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IUploadService uploadService;
        private readonly IBidService bidService;

        public ProductController(IProductService productService, IUploadService uploadService, IBidService bidService)
        {
            this.productService = productService;
            this.uploadService = uploadService;
            this.bidService = bidService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [ImportModelState]
        public IActionResult Create()
        {
            if (TempData.Count > 0)
            {
                ProductModel form = GetCurrentForm();
                return View(form);
            }
            else
            {
                SetCurrentForm(new ProductModel());
                return View(new ProductModel());
            }
        }

        [HttpPost]
        [Authorize]
        [ExportModelState]
        public IActionResult Create(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                SetCurrentForm(product);
                return RedirectToAction("Create");
            }
            (int productID, DatabaseCode dbCode) = productService.CreateProduct(product, HttpContext.User.Identity.Name);
            return RedirectToAction("View", new { productID = productID });
        }

        public IActionResult View(int productID)
        {
            (bool viewable, ProductModel product) productModel = productService.View(productID, HttpContext.User.Identity.Name);
            if (productModel.product == null)
            {
                return NotFound();
            }

            ProductViewViewModel productViewModel = new ProductViewViewModel();
            productViewModel.Product = productModel.product;
            productViewModel.Bid = new BidModel() { ProductID = productModel.product.ID };
            var message = GetMessage();
            if (productViewModel != null)
            {
                productViewModel.Message = message.Message;   
                productViewModel.ShowMessage = message.ShowMessage; 
            }
            return View(productViewModel);
        }

        public IActionResult Cancel(int productID)
        {
            bool cancelled = productService.Cancel(productID);
            SetMessage(new MessageViewModel() { Message = "Product has been cancelled" });
            return RedirectToAction("Dashboard", "Account");
        }

        [HttpPost]
        public IActionResult Bid(BidModel bid)
        {

            bool bidPlaced = bidService.PlaceBid(bid, HttpContext.User.Identity.Name);
            SetMessage(new MessageViewModel()
            {
                Message = bidPlaced ? "Bid was successfully placed" : "There was an error placing your bid",
            });
            return RedirectToAction("View", "Product", new { productID = bid.ProductID, });
        }

        private ProductModel GetCurrentForm()
        {
            return TempData.Get<ProductModel>("currentform");
        }

        private void SetCurrentForm(ProductModel currentForm)
        {
            TempData.Set("currentform", currentForm);
        }
    }
}