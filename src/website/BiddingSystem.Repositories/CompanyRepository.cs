using System;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BiddingSystem.Common;
using BiddingSystem.Entities;
using BiddingSystem.Repository.Contracts;

namespace BiddingSystem.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        private readonly ILogger<CompanyRepository> logger;

        public CompanyRepository(IConfiguration configuration, ILogger<CompanyRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public int GetCompanyIDByUserUsername(string username)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int companyID = con.Query<int>("select co.id from company as co inner join users as us on co.id = us.companyid where us.username = @username", new { username = username}).FirstOrDefault();
                    return companyID;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get companyid", new
                    {
                        contact = JsonConvert.SerializeObject(username)
                    });
                    return 0;
                }
            }
        }

        public (int companyID, DatabaseCode dbCode) Insert(Company company)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int companyID = Convert.ToInt32(con.Insert<Company>(company));
                    return (companyID, DatabaseCode.Inserted);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new contact", new { contact = JsonConvert.SerializeObject(company) });
                    return (0, DatabaseCode.Error);
                }
            }
        }
    }
}