using Moment_Catering_System.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class DishMaintenanceController : Controller
    {
        #region Add

        public ActionResult AddDish()
        {
            DishMaintenance model = new DishMaintenance();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDish(DishMaintenance model)
        {
            if (model.DishEntity.FileBase != null)
            {
                byte[] imageBytes;
                using (var binaryReader = new BinaryReader(model.DishEntity.FileBase.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(model.DishEntity.FileBase.ContentLength);
                }

                string base64String = Convert.ToBase64String(imageBytes);
                model.DishEntity.Picture = base64String;
            }
            model.AddData(model.DishEntity);

            return RedirectToAction("DishList");
        }

        #endregion Add

        #region Update

        public ActionResult UpdateDish(int dishID)
        {
            var model = new DishMaintenance();
            model.GetData(dishID);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateDish(DishMaintenance model)
        {
            if (model.DishEntity.FileBase != null)
            {
                byte[] imageBytes;
                using (var binaryReader = new BinaryReader(model.DishEntity.FileBase.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(model.DishEntity.FileBase.ContentLength);
                }

                string base64String = Convert.ToBase64String(imageBytes);
                model.DishEntity.Picture = base64String;
            }

            model.UpdateData(model.DishEntity);
            return RedirectToAction("DishList");
        }

        #endregion Update

        #region Delete

        public ActionResult DeleteDish(int dishID)
        {
            var dish = new DishMaintenance();
            dish.DeleteData(dishID);
            return RedirectToAction("DishList");
        }

        #endregion Delete

        #region List

        public ActionResult DishList()
        {
            DishMaintenance model = new DishMaintenance();
            model.GetDataList();
            return View(model);
        }

        #endregion List
    }
}