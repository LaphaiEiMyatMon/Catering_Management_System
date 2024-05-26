using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers
{
    public class PurchaseMaintenanceController : Controller
    {
        #region "Register"
        // GET: PurchaseMaintenance
        public ActionResult RegisterPurchase()
        {
            PurchaseMaintenance model = new PurchaseMaintenance();
            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterPurchase(List<BaseTB_PurchaseEntity> data)
        {
            try
            {
                PurchaseMaintenance model = new PurchaseMaintenance();
                model.AddData(data);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        #endregion Register

        #region "List"

        public ActionResult PurchaseList()
        {
            PurchaseMaintenance model = new PurchaseMaintenance();
            model.GetDataList(model.SearchEntity);
            return View(model);
        }

        [HttpPost]
        public ActionResult PurchaseList(PurchaseMaintenance model)
        {
            model.GetDataList(model.SearchEntity);
            return View(model);
        }
        #endregion "List"

        #region "Detail/Edit"

        public ActionResult DetailEdit(int purchaseID)
        {
            
            PurchaseMaintenance model = new PurchaseMaintenance();
            model.GetData(purchaseID);
            model.PDateFormatted = model.PurchaseEntity.PDate.ToString("yyyy-MM-dd");
            return View(model);
        }

        #endregion "Detail/Edit"

        #region "Update"
        [HttpPost]
        public ActionResult UpdatePurchase(PurchaseMaintenance model)
        {
            if (DateTime.TryParseExact(model.PDateFormatted, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                // If parsing is successful, assign the parsed date to the PurchaseEntity
                model.PurchaseEntity.PDate = parsedDate;
                model.UpdateData(model.PurchaseEntity);
                return RedirectToAction("PurchaseList");
            }
            else
            {
                // Handle invalid date format
                ViewBag.ErrorMessage = "Invalid date format.";
                return View(model);
            }
        }
        #endregion "Update"

        #region "Delete"
        public ActionResult DeletePurchase(int purchaseID)
        {
            PurchaseMaintenance model = new PurchaseMaintenance();
            model.DeleteData(purchaseID);
            return RedirectToAction("PurchaseList");
        }
        #endregion

        public void ExportExcelPurchase()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "PurchaseID";
            Sheet.Cells["B1"].Value = "Purchase Date";
            Sheet.Cells["C1"].Value = "Ingredient Name";
            Sheet.Cells["D1"].Value = "SupplierID";
            Sheet.Cells["E1"].Value = "Quantity";
            Sheet.Cells["F1"].Value = "Unit Price";
            Sheet.Cells["G1"].Value = "Total Price";
            Sheet.Cells["H1"].Value = "Invoice No";
            Sheet.Cells["I1"].Value = "Staff Name";
            int row = 2;
            foreach (var item in SessionModel.PurchaseList)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.PurchaseID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.PDate;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.IngredientName;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.SupplierID;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Qty;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.UnitPrice;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.TotalPrice;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.InvoiceNo;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.StaffName;
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }

    }
}