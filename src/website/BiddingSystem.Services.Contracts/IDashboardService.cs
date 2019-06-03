using BiddingSystem.Models.Account;

namespace BiddingSystem.Services.Contracts
{
    public interface IDashboardService
    {
         DashboardModel GetUsersDashboard(string username);
    }
}