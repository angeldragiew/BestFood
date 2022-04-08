using System.ComponentModel.DataAnnotations;

namespace BestFood.Infrastructure.Data.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; } = Guid.NewGuid().ToString();

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

    }
}
