using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Models
{
    public class Lead
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public string  City { get; set; }

        public string Email { get; set; }

        public string Province { get; set; }

        public string Website { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string ZipCode { get; set; }

        public string Value { get; set; }

        public string DefaultLanguage { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Source { get; set; }

        public string AssignedTo { get; set; }

    }
}
