using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadDashboardAPI.Models
{
  public class Notification
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public string Text { get; set; }

    public string UserName { get; set; }

    public string UserProfile { get; set; }

    public bool Seen { get; set; }

    public string UserType { get; set; }

    public string UserId { get; set; }
  }
}