using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System.IO;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class MenuMaintenanceController : Controller
    {
        #region List

        public ActionResult MenuList()
        {
            var menu = new MenuMaintenance();
            menu.GetDataList();
            return View(menu);
        }

        #endregion List

        #region Create

        public ActionResult AddMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMenu(BaseTB_MenuEntity menuEntity)
        {
            if (menuEntity.ImageFile != null && menuEntity.ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(menuEntity.ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("/Images"), fileName);
                menuEntity.ImageFile.SaveAs(imagePath);

                menuEntity.Url = "/Images/" + fileName;
            }
            var menu = new MenuMaintenance();
            menu.AddData(menuEntity);
            return RedirectToAction("MenuList");
        }

        #endregion Create

        #region Update

        public ActionResult EditMenu(int MenuID)
        {
            var menu = new MenuMaintenance();
            menu.GetData(MenuID);
            return View(menu);
        }

        [HttpPost]
        public ActionResult EditMenu(BaseTB_MenuEntity menuEntity)
        {
            if (menuEntity.ImageFile != null && menuEntity.ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(menuEntity.ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("/Images"), fileName);
                menuEntity.ImageFile.SaveAs(imagePath);

                menuEntity.Url = "/Images/" + fileName;
            }
            var menu = new MenuMaintenance();
            menu.UpdateData(menuEntity);
            return RedirectToAction("MenuList");
        }

        #endregion Update

        #region Delete

        public ActionResult DeleteMenu(int MenuID)
        {
            var menu = new MenuMaintenance();
            menu.DeleteData(MenuID);
            return RedirectToAction("MenuList");
        }

        #endregion Delete
    }
}