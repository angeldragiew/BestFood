using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Infrastructure.Data.Models
{
    public class ProductOrder
    {
        public string ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; }


		public string OrderId { get; set; }

		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; }
	}
}
