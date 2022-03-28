using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BestFood.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
