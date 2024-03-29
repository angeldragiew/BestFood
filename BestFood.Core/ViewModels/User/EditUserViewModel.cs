﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        [StringLength(60, MinimumLength = 5)]
        public string? Address { get; set; }
    }
}
