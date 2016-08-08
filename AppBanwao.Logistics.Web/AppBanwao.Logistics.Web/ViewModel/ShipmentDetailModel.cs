using AppBanwao.Logistics.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBanwao.Logistics.Web.ViewModel
{
    public class ShipmentDetailModel
    {
        
        [Display(Name = "#AWB: ")]
        public string ShipmentAWB { get; set; }
        
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        
        [Display(Name = "Expected Delivery Date: ")]
        public DateTime ExpectedDeliveryOn { get; set; }

        [Display(Name = "Shipment details: ")]
        public string Details { get; set; }
        
        [Display(Name = "Current Status: ")]
        public string ShipmentStatus { get; set; }
        
        public int Status { get; set; }

        public int SenderID { get; set; }

        public Guid ShipmentID { get; set; }
        
        public string SEmailAddress { get; set; }
        public string SAddressLine1 { get; set; }
        public string SAddressLine2 { get; set; }
        public string SLandmark { get; set; }
        public string SenderCity { get; set; }
        public int SCity { get; set; }
        public string SenderState { get; set; }
        public int SState { get; set; }
        public string SenderCountry { get; set; }
        public int SCountry { get; set; }
        public string SPrimaryContact { get; set; }
        public string SSecondaryContact { get; set; }
        public DateTime SCreatedOn { get; set; }
        public DateTime SLastUpdatedOn { get; set; }
        public int ReceipientID { get; set; }
      
        public string REmailAddress { get; set; }
        public string RAddressLine1 { get; set; }
        public string RAddressLine2 { get; set; }
        public string RLandmark { get; set; }
        public string ReCity { get; set; }
        public int RCity { get; set; }
        public string ReState { get; set; }
        public int RState { get; set; }
        public string ReCountry { get; set; }
        public int RCountry { get; set; }
        public string RPrimaryContact { get; set; }
        public string RSecondaryContact { get; set; }
        public DateTime RCreatedOn { get; set; }
        public DateTime RLastUpdatedOn { get; set; }

        public List<ShipmentHistory> ShipmentHistory { get; set; }
    }
}