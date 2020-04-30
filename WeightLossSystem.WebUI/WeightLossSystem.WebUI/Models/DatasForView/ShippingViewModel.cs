using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeightLossSystem.WebUI.Models.DatasForView
{
    public class ShippingViewModel
    {
        
        [Required(ErrorMessage = "Indicate your name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Enter a city")]
        [Display(Name = "City")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
    }
}