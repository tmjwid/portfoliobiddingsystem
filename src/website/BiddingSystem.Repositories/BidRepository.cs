using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BiddingSystem.Common;
using BiddingSystem.Entities;
using BiddingSystem.Models.Bid;
using BiddingSystem.Repository.Contracts;

namespace BiddingSystem.Repositories
{
    public class BidRepository : BaseRepository, IBidRepository
    {
        private readonly ILogger<BidRepository> logger;
        public BidRepository(IConfiguration configuration, ILogger<BidRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public int GetProductIDForBid(int bidID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    return con.QueryFirstOrDefault<int>("select productid from bid where id = @bidID", new { bidID });
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get productid for bid", JsonConvert.SerializeObject(new { bidID }));
                    return 0;
                }
            }
        }

        public (List<Bid> bidsRejected, DatabaseCode dbCode) DeclineBidsForProduct(Guid winningUserID, int bidID, int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    string whereClause = "where id != @bidID and userid = @winningUserID and productid = @productID and cancelled = false";
                    List<Bid> bidRows = con.Query<Bid>(string.Format("select id, userid from bid {0}", whereClause), new { bidID, winningUserID, productID }).ToList();
                    int bidCancelled = con.Execute(string.Format("select id, userid from bid {0}", whereClause), new { bidID, winningUserID, productID });
                    return bidRows.Count == bidCancelled ? (bidRows, DatabaseCode.Updated) : (null, DatabaseCode.Error);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel bids for product", JsonConvert.SerializeObject(new { productID }));
                    return (null, DatabaseCode.Error);
                }
            }
        }

        public (Guid userID, DatabaseCode dbCode) AcceptBid(int bidID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int bidCancelled = con.Execute("update bid set accepted = true where id = @bidID", new { bidID });
                    Guid userForBid = con.QueryFirstOrDefault<Guid>("select userid from bid where id = @bidID", new { bidID });
                    return bidCancelled > 0 ? (userForBid, DatabaseCode.Updated) : (Guid.Empty, DatabaseCode.Error);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to accept bid", JsonConvert.SerializeObject(new { bidID }));
                    return (Guid.Empty, DatabaseCode.Error);
                }
            }
        }

        public (Guid userID, DatabaseCode dbCode) DeclineBid(int bidID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int bidCancelled = con.Execute("update bid set declined = true where id = @bidID", new { bidID });
                    Guid userForBid = con.QueryFirstOrDefault<Guid>("select userid from bid where id = @bidID", new { bidID });
                    return bidCancelled > 0 ? (userForBid, DatabaseCode.Updated) : (Guid.Empty, DatabaseCode.Error);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to decline bid", JsonConvert.SerializeObject(new { bidID }));
                    return (Guid.Empty, DatabaseCode.Error);
                }
            }
        }

        public DatabaseCode CancelBid(int bidID, Guid userID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int bidCancelled = con.Execute("update bid set cancelled = true where id = @bidID and userid = @userID", new { bidID, userID });
                    return bidCancelled > 0 ? DatabaseCode.Updated : DatabaseCode.Error;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel bid", JsonConvert.SerializeObject(new { bidID, userID }));
                    return DatabaseCode.Error;
                }
            }
        }

        public bool DoesBidBelongToUser(int bidID, Guid userID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int bidExists = con.QueryFirstOrDefault<int>("select count(id) from bid where id = @bidID and userid = @userID", new { bidID, userID });
                    if (bidExists == 0)
                    {
                        //log that someone is potentially doing something naughty or there could be a bug somewhere
                        logger.LogWarning("User attempted to perform action on bid not belonging to them", new { contact = JsonConvert.SerializeObject(new { bidID, userID }) });
                    }
                    return bidExists > 0;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "User attempted to perform action on bid not belonging to them", new { contact = JsonConvert.SerializeObject(new { bidID, userID }) });
                    return false;
                }
            }
        }

        public bool PlaceBid(Bid bid)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    long bidID = con.Insert<Bid>(bid);
                    return bidID > 0;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to place bid", new { contact = JsonConvert.SerializeObject(bid) });
                    return false;
                }
            }
        }
    }
}