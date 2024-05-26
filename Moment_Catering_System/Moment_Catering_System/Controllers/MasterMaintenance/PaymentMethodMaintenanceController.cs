using Moment_Catering_System.Models;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class PaymentMethodMaintenanceController : Controller
    {
        #region "List"

        public ActionResult PaymentMethodList()
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.GetDataList();

            return View(paymentMethod);
        }

        #endregion "List"

        #region "Create"

        public ActionResult AddPaymentMethod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPaymentMethod(PaymentMethodMaintenance paymentMethod)
        {
            paymentMethod.AddData(paymentMethod.PaymentMethodEntity);
            return RedirectToAction("PaymentMethodList");
        }

        #endregion "Create"

        #region "Update"

        public ActionResult EditPaymentMethod(int paymentMethodID)
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.GetData(paymentMethodID);
            return View(paymentMethod);
        }

        [HttpPost]
        public ActionResult EditPaymentMethod(PaymentMethodMaintenance model)
        {
            model.UpdateData(model.PaymentMethodEntity);
            return RedirectToAction("PaymentMethodList");
        }

        #endregion "Update"

        #region "Delete"

        public ActionResult DeletePaymentMethod(int paymentMethodID)
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.DeleteData(paymentMethodID);
            return RedirectToAction("PaymentMethodList");
        }

        #endregion "Delete"
    }
}