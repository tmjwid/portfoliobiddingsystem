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
    public class ContactRepository : BaseRepository, IContactRepository
    {

        private readonly ILogger<ContactRepository> logger;
        public ContactRepository(IConfiguration configuration, ILogger<ContactRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public (int contactID, DatabaseCode dbCode) Insert(Contact contact)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int contactID = Convert.ToInt32(con.Insert<Contact>(contact));
                    return (contactID, DatabaseCode.Inserted);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new contact", new { contact = JsonConvert.SerializeObject(contact) });
                    return (0, DatabaseCode.Error);
                }
            }
        }
    }
}