using Microsoft.AspNetCore.Mvc;
using NomadDashboardAPI.ViewModels;
using NomadDashboardAPI.Interfaces;

namespace NomadDashboardAPI.Controllers
{
  // route = /api/notifications/
  [Route("api/[controller]")]
  [ApiController]
  public class NotificationsController : ControllerBase
  {
    private readonly INotifications _notificationsService;

    public NotificationsController(INotifications notificationsService)
    {
      _notificationsService = notificationsService;
    }

    [Route("GetNotifications")]
    [HttpGet]
    public ActionResult GetNotifications()
    {
      var notifications = _notificationsService.GetNotifications();
      return Ok(notifications);
    }

    [HttpPost]
    [Route("CreateNotification")]
    public ActionResult CreateNotification(NotificationModel notificationModel)
    {
      _notificationsService.CreateNotification(notificationModel);
      _notificationsService.SaveChanges();
      return Ok("created");
    }

    [HttpGet]
    [Route("DeleteNotifiation{id}")]
    public ActionResult DeleteNotification(string id)
    {
      var notification = _notificationsService.GetNotificationById(id);
      if (notification != null)
      {
        _notificationsService.DeleteNotification(notification);
        _notificationsService.SaveChanges();
        return Ok("deleted");
      }
      return NotFound();
    }

  }
}