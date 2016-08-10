using AppBanwao.Logistics.DataLayer;
using AppBanwao.Logistics.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBanwao.Logistics.Web.Helpers
{
    public class ShipmentHelper
    {
        LogisticsEntities _context = null;

        public SelectList GetStatusList()
        {
            using (_context = new LogisticsEntities())
            {
                return new SelectList(_context.StatusLists.ToList(), "ID", "NAME", "1");

            }
            return null;
        }

        public bool AddShipment(ShipmentCreateModel model)
        {
            using (_context = new LogisticsEntities())
            {
                if (!(_context.Shipments.Where(x => x.ShipmentAWB == model.ShipmentAWB).Count() > 0))
                {
                    var shipment = new Shipment()
                    {
                        CreatedOn = DateTime.Now,
                        Description = model.Description,
                        Details = model.Details ,
                        ExpectedDeliveryOn = model.ExpectedDeliveryOn,
                        ShipmentAWB = model.ShipmentAWB,
                        ShipmentID = Guid.NewGuid(),
                        Status = model.Status,
                        UpdatedOn = DateTime.Now
                    };
                    var sender = new ShipmentSender() { ShipmentID = shipment.ShipmentID };
                    var recepient = new ShipmentReceipient() { ShipmentID = shipment.ShipmentID };
                    var shipmentHistory = new ShipmentHistory() { ShipmentID = shipment.ShipmentID};
                    
                    _context.Shipments.Add(shipment);
                    _context.ShipmentSenders.Add(sender);
                    _context.ShipmentReceipients.Add(recepient);
                    _context.ShipmentHistories.Add(shipmentHistory);

                    if (_context.SaveChanges() > 0)
                        return true;
                }
            }
            return false;
        
        }

        public List<ShipmentDetailModel> GetShipments()
        {
            using (_context = new LogisticsEntities())
            {
                List<ShipmentDetailModel> lstShipment = new List<ShipmentDetailModel>();
                var shipmentIDs = _context.Shipments.Select(x => x.ShipmentID).ToList();

                foreach (var shipmentID in shipmentIDs)
                {
                    lstShipment.Add(GetShipment(shipmentID));
                }

                return lstShipment.OrderByDescending(x=>x.ShipmentCreatedOn).ToList();
            
            }

            return null;
        }

        public ShipmentDetailModel GetShipment(Guid ShipmentID)
        {
            using (_context = new LogisticsEntities())
            {
                var shipment = _context.Shipments.Find(ShipmentID);

                if (shipment != null)
                {
                    var shipmentDetails = new ShipmentDetailModel()
                    {
                        ShipmentAWB = shipment.ShipmentAWB,
                        Description = shipment.Description,
                        Details = shipment.Details,
                        ShipmentCreatedOn =shipment.CreatedOn.HasValue? shipment.CreatedOn.Value:DateTime.Now,
                        ShipmentUpdatedOn =shipment.UpdatedOn.HasValue? shipment.UpdatedOn.Value:DateTime.Now,
                        ExpectedDeliveryOn = shipment.ExpectedDeliveryOn.Value,
                        RAddressLine1 = shipment.ShipmentReceipients.FirstOrDefault().AddressLine1,
                        RAddressLine2 = shipment.ShipmentReceipients.FirstOrDefault().AddressLine2,
                        RCity = shipment.ShipmentReceipients.FirstOrDefault().City.HasValue?shipment.ShipmentReceipients.FirstOrDefault().City.Value:0,
                        RCountry = shipment.ShipmentReceipients.FirstOrDefault().Country.HasValue?shipment.ShipmentReceipients.FirstOrDefault().Country.Value:0,
                        RCreatedOn = shipment.ShipmentReceipients.FirstOrDefault().CreatedOn.HasValue? shipment.ShipmentReceipients.FirstOrDefault().CreatedOn.Value:DateTime.Now,
                        ReceipientID = shipment.ShipmentReceipients.FirstOrDefault().ReceipientID,
                        REmailAddress = shipment.ShipmentReceipients.FirstOrDefault().EmailAddress,
                        RLandmark = shipment.ShipmentReceipients.FirstOrDefault().Landmark,
                        RLastUpdatedOn = shipment.ShipmentReceipients.FirstOrDefault().LastUpdatedOn.HasValue?shipment.ShipmentReceipients.FirstOrDefault().LastUpdatedOn.Value:DateTime.Now,
                        RPrimaryContact = shipment.ShipmentReceipients.FirstOrDefault().PrimaryContact,
                        RSecondaryContact = shipment.ShipmentReceipients.FirstOrDefault().SecondaryContact,
                        RState =shipment.ShipmentReceipients.FirstOrDefault().State.HasValue? shipment.ShipmentReceipients.FirstOrDefault().State.Value:0,
                        SAddressLine1 = shipment.ShipmentSenders.FirstOrDefault().AddressLine1,
                        SAddressLine2 = shipment.ShipmentSenders.FirstOrDefault().AddressLine2,
                        SCity =shipment.ShipmentSenders.FirstOrDefault().City.HasValue? shipment.ShipmentSenders.FirstOrDefault().City.Value:0,
                        SCountry = shipment.ShipmentSenders.FirstOrDefault().Country.HasValue? shipment.ShipmentSenders.FirstOrDefault().Country.Value:0,
                        SCreatedOn = shipment.ShipmentSenders.FirstOrDefault().CreatedOn.HasValue?shipment.ShipmentSenders.FirstOrDefault().CreatedOn.Value:DateTime.Now,
                        SenderID = shipment.ShipmentSenders.FirstOrDefault().SenderID,
                        SEmailAddress = shipment.ShipmentSenders.FirstOrDefault().EmailAddress,
                        SLandmark = shipment.ShipmentSenders.FirstOrDefault().Landmark,
                        SLastUpdatedOn = shipment.ShipmentSenders.FirstOrDefault().LastUpdatedOn.HasValue? shipment.ShipmentSenders.FirstOrDefault().LastUpdatedOn.Value:DateTime.Now,
                        SPrimaryContact = shipment.ShipmentSenders.FirstOrDefault().PrimaryContact,
                        SSecondaryContact = shipment.ShipmentSenders.FirstOrDefault().SecondaryContact,
                        SState = shipment.ShipmentSenders.FirstOrDefault().State.HasValue?shipment.ShipmentSenders.FirstOrDefault().State.Value:0,
                        RName = shipment.ShipmentReceipients.FirstOrDefault().Name,
                        SName = shipment.ShipmentSenders.FirstOrDefault().Name,
                        ShipmentID = shipment.ShipmentID,
                        Status = shipment.Status.Value,
                        ActualDeliveryDate =shipment.ActualDeliveryOn.HasValue?shipment.ActualDeliveryOn.Value.ToString():null
                    };
                    shipmentDetails.ReCity = shipmentDetails.RCity!=0?_context.Cities.Where(x => x.ID == shipmentDetails.RCity).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.ReState = shipmentDetails.RState!=0?_context.States.Where(x => x.ID == shipmentDetails.RState).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.ReCountry =shipmentDetails.RCountry!=0? _context.States.Where(x => x.ID == shipmentDetails.RCountry).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.SenderCity = shipmentDetails.SCity!=0?_context.Cities.Where(x => x.ID == shipmentDetails.SCity).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.SenderState = shipmentDetails.SState!=0?_context.States.Where(x => x.ID == shipmentDetails.SState).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.SenderCountry =shipmentDetails.SCountry!=0?_context.States.Where(x => x.ID == shipmentDetails.SCountry).FirstOrDefault().Name:string.Empty;
                    shipmentDetails.ShipmentStatus = _context.StatusLists.Where(x => x.ID == shipment.Status).FirstOrDefault().Name;
                    shipmentDetails.ShipmentHistory = shipment.ShipmentHistories.ToList();
                    return shipmentDetails;
                }
                
            }
            return null;
        }
    }
}