using Microsoft.Extensions.DependencyInjection;
using BiddingSystem.Common.Contracts;
using BiddingSystem.Common;


namespace BiddingSystem.Dependency
{
    public class HelperDependencies
    {
        public IServiceCollection BuildDependencies(IServiceCollection collection)
        {
            collection.AddTransient<ICryptoHelper, CryptoHelper>();
            collection.AddTransient<ICookieHelper, CookieHelper>();
            return collection;
        }
    }
}