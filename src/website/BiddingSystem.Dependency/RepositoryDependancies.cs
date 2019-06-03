using Microsoft.Extensions.DependencyInjection;
using BiddingSystem.Repositories;
using BiddingSystem.Repository.Contracts;

namespace BiddingSystem.Dependency
{
    public class RepositoryDependencies
    {
        public IServiceCollection BuildDependencies(IServiceCollection collection)
        {
            collection.AddTransient<IAddressRepository, AddressRepository>();
            collection.AddTransient<IBidRepository, BidRepository>();
            collection.AddTransient<ICompanyRepository, CompanyRepository>();            
            collection.AddTransient<IContactRepository, ContactRepository>();
            collection.AddTransient<IProductRepository, ProductRepository>();
            collection.AddTransient<INotificationRepository, NotificationRepository>();
            collection.AddTransient<IUserRepository, UserRepository>();
            return collection;
        }
    }
}