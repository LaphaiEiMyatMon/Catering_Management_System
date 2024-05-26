using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers.MasterMaintenance
{
    public class IngredientMaintenanceController : Controller
    {
        #region List

        public ActionResult IngredientList()
        {
            IngredientMaintenance ingredient = new IngredientMaintenance();
            ingredient.GetDataList();
            return View(ingredient);
        }

        #endregion List

        #region Create

        public ActionResult AddIngredient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIngredient(BaseTB_IngredientEntity ingredientEntity)
        {
            var ingredient = new IngredientMaintenance();
            ingredient.AddData(ingredientEntity);
            return RedirectToAction("IngredientList");
        }

        #endregion Create

        #region Update

        public ActionResult EditIngredient(int IngredientID)
        {
            var ingredient = new IngredientMaintenance();
            ingredient.GetData(IngredientID);
            return View(ingredient);
        }

        [HttpPost]
        public ActionResult EditIngredient(BaseTB_IngredientEntity ingredientEntity)
        {
            var ingredient = new IngredientMaintenance();
            ingredient.UpdateData(ingredientEntity);
            return RedirectToAction("IngredientList");
        }

        #endregion Update

        #region Delete

        public ActionResult DeleteIngredient(int IngredientID)
        {
            var ingredient = new IngredientMaintenance();
            ingredient.DeleteData(IngredientID);
            return RedirectToAction("IngredientList");
        }

        #endregion Delete
    }
}