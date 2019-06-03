using System;
using System.Data;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BiddingSystem.Common;
using BiddingSystem.Entities;
using BiddingSystem.Repository.Contracts;

namespace BiddingSystem.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        private readonly ILogger<AddressRepository> logger;
        public AddressRepository(IConfiguration configuration, ILogger<AddressRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public (int addressID, DatabaseCode dbCode) Insert(Address address)
        {

            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int contactID = Convert.ToInt32(con.Insert<Address>(address));
                    return (contactID, DatabaseCode.Inserted);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new address", new { contact = JsonConvert.SerializeObject(address) });
                    return (0, DatabaseCode.Error);
                }
            }
        }
    }
}