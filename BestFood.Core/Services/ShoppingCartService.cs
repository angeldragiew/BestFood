using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Cart;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IRepository<Product> productRepository;
        public ShoppingCartService(IRepository<CartItem> cartItemRepository,
            IRepository<Product> productRepository)
        {
            this.cartItemRepository = cartItemRepository;
            this.productRepository = productRepository;
        }
        public async Task AddItemToCartAsync(string shoppingCartId, string productId)
        {
            var cartItem = cartItemRepository
                .All()
                .SingleOrDefault(c => c.CartId == shoppingCartId &&
                c.ProductId == productId);

            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    ProductId = productId,
                    CartId = shoppingCartId,
                    Quantity = 1,
                };

                await cartItemRepository.AddAsync(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            await cartItemRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItemViewModel>> AllAsync(string shoppingCartId)
        {
            return await cartItemRepository
                .All()
                .Where(ci => ci.CartId == shoppingCartId)
                .Select(ci => new CartItemViewModel()
                {
                    Id = ci.ItemId,
                    Name = ci.Product.Name,
                    Image = ci.Product.Image,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price,
                    IngredientNames = ci.Product.ProductsIngredients.Select(pi => pi.Ingredient.Name).ToList()
                }).ToListAsync();
        }

        public async Task DecreaseQuantityAsync(string cartItemId, string shoppingCartId)
        {
            var cartItem = cartItemRepository
                .All()
                .SingleOrDefault(ci => ci.ItemId == cartItemId &&
                ci.CartId == shoppingCartId);

            if (cartItem == null)
            {
                throw new ArgumentException("Unknown cart item!");
            }

            if (cartItem.Quantity == 1)
            {
                cartItemRepository.Delete(cartItem);
            }
            else
            {
                cartItem.Quantity--;
            }

            await cartItemRepository.SaveChangesAsync();
        }

        public async Task IncreaseQuantityAsync(string cartItemId, string shoppingCartId)
        {
            var cartItem = cartItemRepository
                .All()
                .SingleOrDefault(ci => ci.ItemId == cartItemId &&
                ci.CartId == shoppingCartId);

            if (cartItem == null)
            {
                throw new ArgumentException("Unknown cart item!");
            }

            cartItem.Quantity++;
            await cartItemRepository.SaveChangesAsync();
        }
    }
}
