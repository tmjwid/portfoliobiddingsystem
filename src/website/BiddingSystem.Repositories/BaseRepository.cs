using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BiddingSystem.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration configuration;
        public BaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        protected IDbConnection CreateConnection()
        {
            var con = new NpgsqlConnection(configuration.GetConnectionString("BiddingDatabase"));
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
    }
}