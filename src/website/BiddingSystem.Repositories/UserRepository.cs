using System.Data;
using System.Linq;
using Dapper;
using BiddingSystem.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Npgsql;
using BiddingSystem.Models.Account;
using BiddingSystem.Common;
using BiddingSystem.Models;
using Microsoft.CSharp;
using BiddingSystem.Common.Contracts;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using BiddingSystem.Entities;
using System.Collections.Generic;

namespace BiddingSystem.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly ICryptoHelper cryptoHelper;
        private readonly ILogger<UserRepository> logger;
        public UserRepository(IConfiguration configuration, ICryptoHelper cryptoHelper, ILogger<UserRepository> logger) : base(configuration)
        {
            this.configuration = configuration;
            this.cryptoHelper = cryptoHelper;
            this.logger = logger;
        }

        public bool Exist(string userName)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    return con.QueryFirst<int>("select count(id) from users where username = @username",
                    new { username = userName }) > 0;

                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to find user", new { user = JsonConvert.SerializeObject(userName) });
                    return false;
                }
            }
        }

        public User GetUser(string userName)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    var user = con.Query<User, Company, User>("select * from users as u inner join company as co on u.companyid = co.id where username = @userName;", (userObject, company) =>
                    {
                        userObject.company = company;
                        return userObject;
                    }, new { userName = userName });
                    return user.FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get user", new { user = JsonConvert.SerializeObject(userName) });
                    return null;
                }
            }
        }

        public bool Login(User loginModel)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    User user = con.Query<User>("select password from users where username = @username", new { username = loginModel.username }).FirstOrDefault();
                    return user != null && !string.IsNullOrEmpty(user.password) ? cryptoHelper.VerifyHashedPassword(user.password, loginModel.password) : false;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to login user", new { user = JsonConvert.SerializeObject(loginModel) });
                    return false;
                }
            }
        }

        public DatabaseCode Insert(User user)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    bool exists = Exist(user.username);

                    if (!exists)
                    {
                        user.password = cryptoHelper.HashPassword(user.password);
                        con.Insert<User>(user);
                        return DatabaseCode.Inserted;
                    }

                    return DatabaseCode.Exists;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new user", new { user = JsonConvert.SerializeObject(user) });
                    return DatabaseCode.Error;
                }
            }
        }

        public User GetFullUser(string userName)
        {
            using (IDbConnection con = CreateConnection())
            {
                string sql = @"select u.*, co.*, ct.*, ad.*, cf.* from users as u 
                inner join company as co 
                on u.companyid = co.id 
                inner join contact as ct 
                on co.id = ct.companyid
                inner join address as ad
                on co.id = ad.companyid
                inner join companyfunction as cf 
                on co.companyfunctionid = cf.id
                where u.username = @userName";
                try
                {
                    var user = con.Query<User, Company, Contact, Address, CompanyFunction, User>(sql, (userObject, company, contact,
                    address, companyFunction) =>
                    {
                        userObject.company = company;
                        userObject.contact = contact;
                        userObject.address = address;
                        userObject.company.companyfunction = companyFunction;
                        return userObject;
                    }, new { userName = userName }).Distinct();

                    return user.FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get full user", new { user = JsonConvert.SerializeObject(userName) });
                    return null;
                }
            }
        }

        public Guid GetUserID(string userName)
        {
            string sql = "select id from users where username = @userName";
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    Guid userID = con.Query<Guid>(sql, new { username = userName }).FirstOrDefault();
                    return userID;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to login user", new { user = JsonConvert.SerializeObject(userName) });
                    return Guid.Empty;
                }
            }
        }

        public (Guid userID, int companyID) GetUserAndCompanyID(string userName)
        {
            string sql = "select id as uid, companyid as cpid from users where username = @userName";
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    dynamic details = con.Query<dynamic>(sql, new { username = userName });
                    return ((Guid)details[0].uid, (int)details[0].cpid);

                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to login user", new { user = JsonConvert.SerializeObject(userName) });
                    return (Guid.Empty, 0);
                }
            }
        }
    }
}
