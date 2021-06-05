using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string LastIp { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string ProfilePic { get; set; }

    }
}
