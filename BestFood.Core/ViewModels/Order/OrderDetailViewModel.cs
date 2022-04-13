using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Infrastructure.Enums;

namespace BestFood.Core.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string CreationDate { get; set; }
        public string Amount { get; set; }
        public string Note { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ProductsInfo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
