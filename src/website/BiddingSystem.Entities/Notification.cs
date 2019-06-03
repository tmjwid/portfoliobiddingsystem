using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiddingSystem.Entities
{
    [Table("notification")]
    public class Notification
    {
        [Key]
        public int id { get; set; }
        public bool read { get; set; }
        public DateTime duedate { get; set; }
        public string information { get; set; }
        public int productupdatetypeid { get { return 1; } }
        public Guid receivinguserid { get; set; }
    }
}