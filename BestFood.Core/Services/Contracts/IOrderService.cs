using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.ViewModels.Order;

namespace BestFood.Core.Services.Contracts
{
    public interface IOrderService
    {
        Task CreateAsync(string shoppingCartId, string currentUserName, CreateOrderViewModel model);
        Task<IEnumerable<OrderDetailViewModel>> AllUserOrders(string userName);
        Task<IEnumerable<OrderViewModel>> AllPendingOrders();
        Task<OrderDetailViewModel> OrderDetails(string id);

    }
}
