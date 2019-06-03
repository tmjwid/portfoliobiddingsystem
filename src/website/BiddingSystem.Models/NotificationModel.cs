using System;

namespace BiddingSystem.Models
{
    public class NotificationModel
    {
        public int ID { get; set; }
        public bool Read { get; set; }
        public string Information { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ReceivingUserID { get; set; }
        public string AdditionalInformation { get; set; }
    }
}