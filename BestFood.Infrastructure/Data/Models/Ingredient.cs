﻿using System.ComponentModel.DataAnnotations;
using BestFood.Infrastructure.Enums;

namespace BestFood.Infrastructure.Data.Models
{
	public class Ingredient
	{
		[Key]
		[MaxLength(36)]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public IngredientType Type { get; set; }

		public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
		public ICollection<CategoryIngredient> CategoryIngredients { get; set; } = new List<CategoryIngredient>();
	}
}
