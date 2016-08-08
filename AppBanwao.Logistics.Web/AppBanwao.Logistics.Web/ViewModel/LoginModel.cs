using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBanwao.Logistics.Web.ViewModel
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool isRemember { get; set; }
    }
}