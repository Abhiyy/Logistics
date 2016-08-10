using AppBanwao.Logistics.Web.Helpers;
using AppBanwao.Logistics.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBanwao.Logistics.Web.Controllers
{
    [Authorize]
    public class ShipmentController : BaseController
    {
        //
        // GET: /Awb/
        ShipmentHelper _shipmentHelper = null;

        public ActionResult Index()
        {
            _shipmentHelper = new ShipmentHelper();

            var shipment = _shipmentHelper.GetShipments();
            _shipmentHelper = null;
            return View(shipment);
        }

        public ActionResult Create()
        {
            CreateViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipmentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentHelper = new ShipmentHelper();
                if (_shipmentHelper.AddShipment(model))
                {
                    Success(AlertStyles.SuccessSymbol + "The shipment has been added successfully.", true);
                    _shipmentHelper = null;
                    return RedirectToAction("Index");
                }
                else
                    Danger(AlertStyles.DangerSymbol + "The shipment has not been added successfully.", true);

                _shipmentHelper = null;
            }
            CreateViewBag();
            return View(model);

        }

        public ActionResult Details(Guid id)
        {
            _shipmentHelper = new ShipmentHelper();
            var shipment = _shipmentHelper.GetShipment(id);
            _shipmentHelper = null;
            return View(shipment);
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }

        public ActionResult Sender(Guid id)
        {
            return View();
        }

        public ActionResult Recepient(Guid id)
        {
            return View();
        }

        public ActionResult AddHistory(Guid id)
        {
            return View();
        }

        void CreateViewBag() 
        {
            _shipmentHelper = new ShipmentHelper();
           ViewBag.StatusList = _shipmentHelper.GetStatusList();
           _shipmentHelper = null;
        }

    }
}
