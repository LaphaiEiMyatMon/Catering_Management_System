using Moment_Catering_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers
{
    public class PaymentMaintenanceController : Controller
    {
        // GET: PaymentMaintenance
        public ActionResult CustomerPaymentList()
        {
            if (!string.IsNullOrEmpty(LoginInfo.UserID))
            {
                PaymentMaintenance model = new PaymentMaintenance();
                model.GetDataList(model);
                return View(model);
            }
            return View();

        }

        public ActionResult DisplayPaymentMethods(int paymentID)
        {
            PaymentMaintenance model = new PaymentMaintenance();
            model.GetData(paymentID);
            return View(model);
        }

        public ActionResult PaymentList(PaymentMaintenance model)
        {    
            model.GetDataList(model);
            return View(model);
        }

        public ActionResult RegisterPayment(int paymentID)
        {
            PaymentMaintenance model = new PaymentMaintenance();
            model.GetData(paymentID);
            return View(model);
        }

        public ActionResult UpdatePayment(PaymentMaintenance model)
        {
            model.UpdateData(model.PaymentEntity);

            if (LoginInfo.UserID.StartsWith("S"))
            {
                return RedirectToAction("PaymentList");
            }
            else
            {
                return RedirectToAction("CustomerPaymentList");
            }
           
        }
    }
}