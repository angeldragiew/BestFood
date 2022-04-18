using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Order
{
    public class RejectOrderViewModel
    {
        public string RejectOrderId { get; set; }

        [MaxLength(300)]
        public string RejectOrderNote { get; set; }
    }
}
