using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Infrastructure.Data.Models
{
	public class Review
	{
		[Key]
		[MaxLength(36)]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[Required]
		[StringLength(300)]
		public string Text { get; set; }

		[Range(1,5)]
		public int Rating { get; set; }

		public DateTime Date { get; set; } = DateTime.Now;

		[Required]
		public string ProductId { get; set; }
		
		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; }

		[Required]
		public string ApplicationUserId { get; set; }

		[ForeignKey(nameof(ApplicationUserId))]
		public ApplicationUser ApplicationUser { get; set; }
	}
}
