using BestFood.Core.ViewModels.Category;

namespace BestFood.Core.ViewModels.Order
{
    public class OrderListViewModel
    {
        public int PageNo { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
