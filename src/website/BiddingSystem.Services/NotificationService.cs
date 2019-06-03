using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationsRepository;
        private readonly INotificationMapper notificationsMapper;
        public NotificationService(INotificationRepository notificationsRepository, INotificationMapper notificationsMapper)
        {
            this.notificationsRepository = notificationsRepository;
            this.notificationsMapper = notificationsMapper;
        }

        public List<NotificationModel> GetNotificationsForUser(Guid userID)
        {
            return notificationsMapper.ToModelList(notificationsRepository.GetNotificationsForUser(userID));
        }

        public (int productUpdateID, DatabaseCode dbCode) Insert(NotificationModel productUpdate)
        {
            return notificationsRepository.Insert(notificationsMapper.ToEntity(productUpdate));
        }

        public DatabaseCode MarkAsRead(int notificationID, Guid userID)
        {
            return notificationsRepository.MarkAsRead(notificationID, userID);
        }
    }
}