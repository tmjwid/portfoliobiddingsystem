using Microsoft.Extensions.DependencyInjection;
using BiddingSystem.DTOMapper;
using BiddingSystem.DTOMapper.Contracts;

namespace BiddingSystem.Dependency
{
    public class MapperDependanices
    {
        public IServiceCollection BuildDependencies(IServiceCollection collection)
        {
            collection.AddTransient<IAddressMapper, AddressMapper>();
            collection.AddTransient<IBidMapper, BidMapper>();
            collection.AddTransient<ICompanyMapper, CompanyMapper>();
            collection.AddTransient<ICompanyFunctionMapper, CompanyFunctionMapper>();
            collection.AddTransient<IContactMapper, ContactMapper>();
            collection.AddTransient<IProductMapper, ProductMapper>();  
            collection.AddTransient<INotificationMapper, NotificationMapper>();         
            collection.AddTransient<IUserMapper, UserMapper>();
            return collection;
        }
    }
}