using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class BranchMaintenanceController : Controller
    {
        #region "List"

        public ActionResult BranchList()
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.GetDataList();
            ViewBag.Msg = TempData["Message"];
            return View(branch);
        }

        #endregion "List"

        #region "Create"

        public ActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBranch(BaseTB_BranchEntity branchEntity)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.AddData(branchEntity);
          
            return Redirect("BranchList");
        }

        #endregion "Create"

        #region "Update"

        public ActionResult EditBranch(int branchNo)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.GetData(branchNo);
            return View(branch);
        }

        [HttpPost]
        public ActionResult EditBranch(BaseTB_BranchEntity branchEntity)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.UpdateData(branchEntity);
            TempData["Message"] = "Successfully Updated!";
            return RedirectToAction("/BranchList");
        }

        #endregion "Update"

        #region "Delete"

        public ActionResult DeleteBranch(int branchNo)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.DeleteData(branchNo);
            return RedirectToAction("/BranchList");
        }

        #endregion "Delete"
    }
}