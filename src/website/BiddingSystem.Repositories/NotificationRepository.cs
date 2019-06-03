using System;
using System.Collections.Generic;
using System.Data;
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
    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        private readonly ILogger<NotificationRepository> logger;
        public NotificationRepository(IConfiguration configuration, ILogger<NotificationRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public IEnumerable<Notification> GetNotificationsForUser(Guid userID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    string sql = "select * from notification where receivinguserid = @userID and read = false order by datecreated desc";
                    return con.Query<Notification>(sql, new { userID });
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get notifications for user", new { user = JsonConvert.SerializeObject(userID) });
                    return null;
                }
            }
        }

        public (int productUpdateID, DatabaseCode dbCode) Insert(Notification productUpdate)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    long productUpdateID = con.Insert<Notification>(productUpdate);
                    return ((int)productUpdateID, DatabaseCode.Inserted);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new user", new { user = JsonConvert.SerializeObject(productUpdate) });
                    return (0, DatabaseCode.Error);
                }
            }
        }

        public DatabaseCode MarkAsRead(int notificationID, Guid userID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    string sql = "update notification set read = true where id = @notificationID and receivinguserid = @userID";
                    return con.Execute(sql, new { notificationID, userID }) > 0 ? DatabaseCode.Updated : DatabaseCode.Error;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get notifications for user", new { user = JsonConvert.SerializeObject(userID) });
                    return DatabaseCode.Error;
                }
            }
        }
    }
}