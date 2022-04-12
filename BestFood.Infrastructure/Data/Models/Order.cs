using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Infrastructure.Enums;

namespace BestFood.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();


        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        [MaxLength(600)]
        public string? Note { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public OrderStatus OrderStatus { get; set; }

        public decimal Amount { get; set; }

        public string ProductsInfo { get; set; }


        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
