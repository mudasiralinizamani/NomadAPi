using NomadDashboardAPI.Contexts;
using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.Models;
using NomadDashboardAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Services
{
  public class INotificationsService : INotifications
  {
    private readonly APIContext _context;

    public INotificationsService(APIContext context)
    {
      _context = context;
    }
    public IEnumerable<Notification> GetNotificationsByUserId(string userId)
    {
      return _context.Notifications.Where(x => x.UserId == userId);
    }

    public IEnumerable<Notification> GetNotifications()
    {
      return _context.Notifications.ToList();
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void CreateNotification(NotificationModel model)
    {
      if (model == null)
      {
        throw new ArgumentNullException(nameof(model));

      }

      var newNotification = new Notification
      {
        CreatedAt = DateTime.Now,
        Text = model.Text,
        Seen = false,
        UserName = model.UserName,
        UserId = model.UserId,
        UserProfile = model.UserProfile,
        UserType = model.UserType
      };

      _context.Notifications.Add(newNotification);
    }

    public void DeleteNotificationById(string id)
    {

    }

    public Notification GetNotificationById(string id)
    {
      var notification = _context.Notifications.FirstOrDefault(x => x.Id == id);
      return notification;
    }

    public void DeleteNotification(Notification notificationModel)
    {
      if (notificationModel != null)
      {
        _context.Remove(notificationModel);
      }
    }
  }
}
