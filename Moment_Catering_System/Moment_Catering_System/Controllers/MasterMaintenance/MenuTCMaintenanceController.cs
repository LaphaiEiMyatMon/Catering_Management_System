using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class MenuTCMaintenanceController : Controller
    {
        #region List
        public ActionResult MenuTCList()
        {
            var menutc = new MenuTCMaintenance();
            menutc.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(menutc);
        }
        #endregion
        #region Create
        public ActionResult AddMenuTC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMenuTC(BaseTB_MenuTCEntity menutcEntity)
        {
            var menutc = new MenuTCMaintenance();
            menutc.AddData(menutcEntity);
            return RedirectToAction("/MenuTCList");
        }
        #endregion
        #region Update 
        public ActionResult EditMenuTC(int TCID)
        {
            var menutc = new MenuTCMaintenance();
            menutc.GetData(TCID);
            return View(menutc);
        }

        [HttpPost]
        public ActionResult EditMenuTC(BaseTB_MenuTCEntity menutcEntity)
        {
            var menutc = new MenuTCMaintenance();
            menutc.UpdateData(menutcEntity);
            ViewBag.Message = "Successfully Updated";
            return RedirectToAction("/MenuTCList");
        }
        #endregion
        #region Delete
        public ActionResult DeleteMenuTC(int TCID)
        {
            var menutc = new MenuTCMaintenance();
            menutc.DeleteData(TCID);
            ViewBag.Message = "Successfully Deleted";
            return RedirectToAction("/MenuTCList");
        }
        #endregion
    }
}
