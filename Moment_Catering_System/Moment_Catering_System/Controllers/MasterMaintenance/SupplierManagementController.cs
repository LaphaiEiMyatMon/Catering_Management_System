using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class SupplierManagementController : Controller
    {
        #region List

        public ActionResult SupplierList()
        {
            var ingredient = new SupplierManagement();
            ingredient.GetDataList();
            return View(ingredient);
        }

        #endregion List

        #region Create

        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(BaseTB_SupplierEntity supplierEntity)
        {
            var supplier = new SupplierManagement();
            supplier.AddData(supplierEntity);
            return RedirectToAction("SupplierList");
        }

        #endregion Create

        #region Update

        public ActionResult EditSupplier(int SupplierID)
        {
            var supplier = new SupplierManagement();
            supplier.GetData(SupplierID);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult EditSupplier(BaseTB_SupplierEntity supplierEntity)
        {
            var supplier = new SupplierManagement();
            supplier.UpdateData(supplierEntity);
            return RedirectToAction("SupplierList");
        }

        #endregion Update

        #region Delete

        public ActionResult DeleteSupplier(int SupplierID)
        {
            var supplier = new SupplierManagement();
            supplier.DeleteData(SupplierID);
            return RedirectToAction("SupplierList");
        }

        #endregion Delete
    }
}