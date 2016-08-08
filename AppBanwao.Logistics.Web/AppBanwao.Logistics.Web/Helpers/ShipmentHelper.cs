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
                    _context.Shipments.Add(shipment);
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

                return lstShipment;
            
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
                        Description = shipment.Description,
                        Details = shipment.Details,
                        ExpectedDeliveryOn = shipment.ExpectedDeliveryOn.Value,
                        RAddressLine1 = shipment.ShipmentReceipients.FirstOrDefault().AddressLine1,
                        RAddressLine2 = shipment.ShipmentReceipients.FirstOrDefault().AddressLine2,
                        RCity = shipment.ShipmentReceipients.FirstOrDefault().City.Value,
                        RCountry = shipment.ShipmentReceipients.FirstOrDefault().Country.Value,
                        RCreatedOn = shipment.ShipmentReceipients.FirstOrDefault().CreatedOn.Value,
                        ReceipientID = shipment.ShipmentReceipients.FirstOrDefault().ReceipientID,
                        REmailAddress = shipment.ShipmentReceipients.FirstOrDefault().EmailAddress,
                        RLandmark = shipment.ShipmentReceipients.FirstOrDefault().Landmark,
                        RLastUpdatedOn = shipment.ShipmentReceipients.FirstOrDefault().LastUpdatedOn.Value,
                        RPrimaryContact = shipment.ShipmentReceipients.FirstOrDefault().PrimaryContact,
                        RSecondaryContact = shipment.ShipmentReceipients.FirstOrDefault().SecondaryContact,
                        RState = shipment.ShipmentReceipients.FirstOrDefault().State.Value,
                        SAddressLine1 = shipment.ShipmentSenders.FirstOrDefault().AddressLine1,
                        SAddressLine2 = shipment.ShipmentSenders.FirstOrDefault().AddressLine2,
                        SCity = shipment.ShipmentSenders.FirstOrDefault().City.Value,
                        SCountry = shipment.ShipmentSenders.FirstOrDefault().Country.Value,
                        SCreatedOn = shipment.ShipmentSenders.FirstOrDefault().CreatedOn.Value,
                        SenderID = shipment.ShipmentSenders.FirstOrDefault().SenderID,
                        SEmailAddress = shipment.ShipmentSenders.FirstOrDefault().EmailAddress,
                        SLandmark = shipment.ShipmentSenders.FirstOrDefault().Landmark,
                        SLastUpdatedOn = shipment.ShipmentSenders.FirstOrDefault().LastUpdatedOn.Value,
                        SPrimaryContact = shipment.ShipmentSenders.FirstOrDefault().PrimaryContact,
                        SSecondaryContact = shipment.ShipmentSenders.FirstOrDefault().SecondaryContact,
                        SState = shipment.ShipmentSenders.FirstOrDefault().State.Value,
                    };
                    shipmentDetails.ReCity = _context.Cities.Where(x => x.ID == shipmentDetails.RCity).FirstOrDefault().Name;
                    shipmentDetails.ReState = _context.States.Where(x => x.ID == shipmentDetails.RState).FirstOrDefault().Name;
                    shipmentDetails.ReCountry = _context.States.Where(x => x.ID == shipmentDetails.RCountry).FirstOrDefault().Name;
                    shipmentDetails.SenderCity = _context.Cities.Where(x => x.ID == shipmentDetails.RCity).FirstOrDefault().Name;
                    shipmentDetails.SenderState = _context.States.Where(x => x.ID == shipmentDetails.RState).FirstOrDefault().Name;
                    shipmentDetails.SenderCountry = _context.States.Where(x => x.ID == shipmentDetails.RCountry).FirstOrDefault().Name;

                    return shipmentDetails;
                }
                
            }
            return null;
        }
    }
}