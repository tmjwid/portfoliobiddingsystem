using System.Collections.Generic;
using System.Linq;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models;

namespace BiddingSystem.DTOMapper
{
    public class NotificationMapper : INotificationMapper
    {
        public Notification ToEntity(NotificationModel notificationModel)
        {
            Notification notification = new Notification();
            notification.duedate = notificationModel.DueDate;
            notification.information = notificationModel.Information;
            notification.id = notificationModel.ID;
            notification.read = notificationModel.Read;
            notification.receivinguserid = notificationModel.ReceivingUserID;
            return notification;
        }

        public NotificationModel ToModel(Notification notification)
        {
            NotificationModel notificationModel = new NotificationModel();
            notificationModel.DueDate = notification.duedate;
            notificationModel.Information = notification.information;
            notificationModel.ID = notification.id;
            notificationModel.Read = notification.read;
            notificationModel.ReceivingUserID = notification.receivinguserid;
            return notificationModel;
        }

        public List<NotificationModel> ToModelList(IEnumerable<Notification> notifications)
        {
            List<NotificationModel> list = new List<NotificationModel>();
            if (notifications != null && notifications.Any())
            {
                list.AddRange(notifications.Select(e => ToModel(e)));
            }
            return list;
        }
    }
}