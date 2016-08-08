using AppBanwao.Logistics.Web.Helpers;
using AppBanwao.Logistics.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBanwao.Logistics.Web.Controllers
{
    public class ShipmentController : BaseController
    {
        //
        // GET: /Awb/
        ShipmentHelper _shipmentHelper = null;

        public ActionResult Index()
        {
            return View();
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
                    return RedirectToAction("Index");
                }
                else
                    Danger(AlertStyles.DangerSymbol + "The shipment has not been added successfully.", true);

               
            }

            return View(model);

        }

        void CreateViewBag() 
        {
            _shipmentHelper = new ShipmentHelper();
           ViewBag.StatusList = _shipmentHelper.GetStatusList();
           _shipmentHelper = null;
        }

    }
}
