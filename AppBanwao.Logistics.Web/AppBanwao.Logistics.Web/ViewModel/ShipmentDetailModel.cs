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

        [Display(Name = "Actual Delivery On: ")]
        public string ActualDeliveryDate { get; set; }


        [Display(Name = "Created On: ")]
        public DateTime ShipmentCreatedOn { get; set; }

        [Display(Name = "Last Updated On: ")]
        public DateTime ShipmentUpdatedOn { get; set; }

        public int Status { get; set; }

        public int SenderID { get; set; }

        public Guid ShipmentID { get; set; }
         [Display(Name = "Name: ")]
        public string SName { get; set; }
        [Display(Name = "Sender Email Address: ")]
        public string SEmailAddress { get; set; }
       [Display(Name = "Sender Address 1: ")]
        public string SAddressLine1 { get; set; }
        [Display(Name = "Address 2: ")]
        public string SAddressLine2 { get; set; }
        [Display(Name = "Landmark: ")]
        public string SLandmark { get; set; }
        [Display(Name = "City: ")]
        public string SenderCity { get; set; }
        public int SCity { get; set; }
        [Display(Name = "State: ")]
        public string SenderState { get; set; }
        public int SState { get; set; }
        [Display(Name = "Country: ")]
        public string SenderCountry { get; set; }
        
        public int SCountry { get; set; }
        [Display(Name = "Primary Contact: ")]
        public string SPrimaryContact { get; set; }
        [Display(Name = "Secondry Contact: ")]
        public string SSecondaryContact { get; set; }
        [Display(Name = "Created On: ")]
        public DateTime SCreatedOn { get; set; }
        [Display(Name = "Last Updated On: ")]
        public DateTime SLastUpdatedOn { get; set; }
        public int ReceipientID { get; set; }
        [Display(Name = "Name: ")]
        public string RName { get; set; }
        [Display(Name = "Email Address: ")]
        public string REmailAddress { get; set; }
        [Display(Name = "Address 1: ")]
        public string RAddressLine1 { get; set; }
        [Display(Name = "Address 2: ")]
        public string RAddressLine2 { get; set; }
        [Display(Name = "Landmark: ")]
        public string RLandmark { get; set; }
        [Display(Name = "City: ")]
        public string ReCity { get; set; }
        public int RCity { get; set; }
        [Display(Name = "State: ")]
        public string ReState { get; set; }
        public int RState { get; set; }
        [Display(Name = "Country: ")]
        public string ReCountry { get; set; }
        public int RCountry { get; set; }
        [Display(Name = "Primary Contact: ")]
        public string RPrimaryContact { get; set; }
        [Display(Name = "Secondary Contact: ")]
        public string RSecondaryContact { get; set; }
        [Display(Name = "Created On: ")]
        public DateTime RCreatedOn { get; set; }
        [Display(Name = "Last Updated On: ")]
        public DateTime RLastUpdatedOn { get; set; }

        public List<ShipmentHistory> ShipmentHistory { get; set; }
    }
}