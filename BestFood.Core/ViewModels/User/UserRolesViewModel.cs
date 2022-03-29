using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.User
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string[] RoleNames { get; set; }
    }
}
