
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    public class BidNotification
    {
        [Key]
        public int id { get; set; }
        public string information { get; set; }
        public int type { get; set; }
        public bool read { get; set; }
        public int bidid { get; set; }
    }
}