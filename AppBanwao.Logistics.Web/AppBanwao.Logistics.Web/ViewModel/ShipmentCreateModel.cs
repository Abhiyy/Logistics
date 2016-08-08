using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBanwao.Logistics.Web.ViewModel
{
    public class ShipmentCreateModel
    {
        [Required]
        [Display(Name="Enter #AWB: ")]
        public string ShipmentAWB { get; set; }
        [Required]
        [Display(Name = "Enter Description: ")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Choose Expected Delivery Date: ")]
        public DateTime ExpectedDeliveryOn { get; set; }
        
        [Display(Name = "Enter shipment details: ")]
        public string Details { get; set; }
        [Display(Name = "Select Current Status: ")]
        public int Status { get; set; }
    }
}