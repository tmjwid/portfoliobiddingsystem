using System;
using Microsoft.Extensions.DependencyInjection;
using BiddingSystem.Services;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Dependency
{
    public class ServiceDependencies
    {
        public IServiceCollection BuildDependencies(IServiceCollection collection)
        {
            collection.AddTransient<IAddressService, AddressService>();
            collection.AddTransient<IBidService, BidService>();
            collection.AddTransient<ICompanyService, CompanyService>();
            collection.AddTransient<IContactService, ContactService>();
            collection.AddTransient<IDashboardService, DashboardService>();
            collection.AddTransient<IProductService, productService>();
            collection.AddTransient<INotificationService, NotificationService>();
            collection.AddTransient<IUserService, UserService>();
            collection.AddTransient<IUploadService, UploadService>();
            return collection;
        }
    }
}
