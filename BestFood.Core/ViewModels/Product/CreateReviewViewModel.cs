using System.ComponentModel.DataAnnotations;

namespace BestFood.Core.ViewModels.Review
{
    public class CreateReviewViewModel
    {
        [Required]
        [StringLength(300)]
        public string Text { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string ProductId { get; set; }
    }
}
