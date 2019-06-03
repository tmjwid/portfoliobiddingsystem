using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.Models;

namespace BiddingSystem.Services.Contracts
{
    public interface INotificationService
    {
        (int productUpdateID, DatabaseCode dbCode) Insert(NotificationModel productUpdate);
        List<NotificationModel> GetNotificationsForUser(Guid userID);
        DatabaseCode MarkAsRead(int notificationID, Guid userID);
    }
}