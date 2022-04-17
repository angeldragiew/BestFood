using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BestFood.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string? LastName { get; set; }

        [StringLength(60, MinimumLength = 5)]
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
