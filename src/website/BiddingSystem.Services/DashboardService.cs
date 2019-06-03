using System.Linq;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Account;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly INotificationService notificationService;

        public DashboardService(IUserService userService, IProductService productService, INotificationService notificationService)
        {
            this.userService = userService;
            this.productService = productService;    
            this.notificationService = notificationService;
        }

        public DashboardModel GetUsersDashboard(string username)
        {
            DashboardModel dashboard = new DashboardModel();
            dashboard.User = userService.GetFullUser(username);
            dashboard.Notifications = notificationService.GetNotificationsForUser(dashboard.User.ID);
            dashboard.User.Company.Products = productService.GetByCompanyID(dashboard.User.CompanyID);
            dashboard.NewProducts = productService.GetNewProducts(dashboard.User.CompanyID);
            return dashboard;
        }
    }
}