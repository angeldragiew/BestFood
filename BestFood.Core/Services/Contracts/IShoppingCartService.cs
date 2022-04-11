using BestFood.Core.ViewModels.Cart;
using BestFood.Infrastructure.Data.Migrations;

namespace BestFood.Core.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task AddItemToCartAsync(string shoppingCartId, string productId);

        Task<IEnumerable<CartItemViewModel>> AllAsync(string shoppingCartId);
        Task ClearCart(string shoppingCartId);
        Task IncreaseQuantityAsync(string cartItemId, string shoppingCartId);
        Task DecreaseQuantityAsync(string cartItemId, string shoppingCartId);
    }
}
