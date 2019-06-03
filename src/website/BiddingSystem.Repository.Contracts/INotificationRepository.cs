using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface INotificationRepository
    {
        (int productUpdateID, DatabaseCode dbCode) Insert(Notification productUpdate);
        IEnumerable<Notification> GetNotificationsForUser(Guid userID);
        DatabaseCode MarkAsRead(int notificationID, Guid userID);
    }
}