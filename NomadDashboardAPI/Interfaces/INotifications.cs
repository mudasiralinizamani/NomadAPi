using NomadDashboardAPI.Models;
using NomadDashboardAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Interfaces
{
  public interface INotifications
  {
    IEnumerable<Notification> GetNotifications();

    IEnumerable<Notification> GetNotificationsByUserId(string userId);

    bool SaveChanges();

    void CreateNotification(NotificationModel notification);

    Notification GetNotificationById(string id);


    void DeleteNotification(Notification notificationModel);
  }
}
