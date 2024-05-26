using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System;
using System.IO;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class StaffMaintenanceController : Controller
    {
        #region "List"

        public ActionResult StaffList(StaffMaintenance staff)
        {

            staff.GetDataList(staff);
    
            return View(staff);
        }

        #endregion "List"

        #region "Create"

        public ActionResult AddNewStaff()
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.StaffEntity.IsActive = true;
            return View(staff);
        }

        [HttpPost]
        public ActionResult AddNewStaff(BaseTB_StaffEntity staffEntity)
        {
            StaffMaintenance staff = new StaffMaintenance();
            if (staffEntity.FileBase != null)
            {
                byte[] imageBytes;
                using (var binaryReader = new BinaryReader(staffEntity.FileBase.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(staffEntity.FileBase.ContentLength);
                }

                string base64String = Convert.ToBase64String(imageBytes);
                staffEntity.ProfilePicture = base64String;
            }

            staff.AddData(staffEntity);

            return RedirectToAction("StaffList");
        }

        #endregion "Create"

        #region "Update"

        public ActionResult UpdateStaff(string staffID)
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.GetData(staffID);
            return View(staff);
        }

        [HttpPost]
        public ActionResult UpdateStaff(BaseTB_StaffEntity staffEntity)
        {
            StaffMaintenance staff = new StaffMaintenance();
            if (staffEntity.FileBase != null)
            {
                byte[] imageBytes;
                using (var binaryReader = new BinaryReader(staffEntity.FileBase.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(staffEntity.FileBase.ContentLength);
                }

                string base64String = Convert.ToBase64String(imageBytes);
                staffEntity.ProfilePicture = base64String;
            }
            staff.UpdateData(staffEntity);
           
            return RedirectToAction("StaffList");
        }

        #endregion "Update"

        #region "Login Logout"

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(StaffMaintenance model)

        {
            ResultStatus result = new ResultStatus();
            result = model.GetUser(model);
            if (result.Status == false)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            // Store a success message in TempData
            TempData["Message"] = "Login successful!";
            return RedirectToAction("Dashboard");
        }

        public ActionResult Logout()
        {
            SessionModel.KillSession();
            LoginInfo.KillSession();
            return RedirectToAction("Login");
        }

        #endregion "Login"

        #region "Dashboard"

        public ActionResult Dashboard()
        {
            ViewBag.Message = TempData["Message"];
            BaseTB_Count count = new BaseTB_Count();
            count.GetData();
            return View(count);
        }

        #endregion "Dashboard"

        #region "Detail"

        public ActionResult DetailStaff(string staffID)
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.GetData(staffID);
            
            return View(staff);
        }

        #endregion "Detail"
    }
}