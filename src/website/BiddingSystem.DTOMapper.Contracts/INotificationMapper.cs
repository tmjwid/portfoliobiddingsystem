using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface INotificationMapper
    {
        Notification ToEntity(NotificationModel productUpdate);
        NotificationModel ToModel(Notification productUpdate);
        List<NotificationModel> ToModelList(IEnumerable<Notification> productUpdates);
    }
}