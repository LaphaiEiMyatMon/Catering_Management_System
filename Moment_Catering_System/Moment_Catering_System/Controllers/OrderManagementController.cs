using Moment_Catering_System.Models;
using OfficeOpenXml;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers
{
    public class OrderManagementController : Controller
    {
        // GET: OrderManagement
        public ActionResult DisplayMenu()
        {
            ViewBag.Message = TempData["Message"];
            OrderManagement model = new OrderManagement();
            model.GetMenuList();
            return View(model);
        }

        public ActionResult DisplayDish(int menuID, string menuName, int minPax, int noOfCourse, decimal unitPrice)
        {
            SessionModel.MenuID = menuID;
            SessionModel.MenuName = menuName;
            SessionModel.MinPax = minPax;
            SessionModel.NoOfCourse = noOfCourse;
            SessionModel.UnitPrice = unitPrice;
            OrderManagement model = new OrderManagement();
            model.GetDishList(menuID);
            SessionModel.DishList = model.DishList;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckandSaveSession(PassData passData)
        {
            SessionModel.TotalPrice = passData.TotalPrice;
            SessionModel.SelectedPax = passData.SelectedPax;
            SessionModel.ExtraDishList = passData.ExtraDishList;
            SessionModel.StringExtraDishList = passData.StringExtraDishList;

            return Json(new { success = true });
        }

        public ActionResult Checkout(OrderManagement model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderManagement model)
        {
            model.AddData(model);
            return RedirectToAction("CustomerOrderList", "CustomerMaintenance");
        }

        public ActionResult OrderList(OrderManagement model)
        {
            model.GetDataList(model);
            return View(model);
        }

        public ActionResult OrderDetail(int orderID)
        {
            OrderManagement model = new OrderManagement();
            model.GetData(orderID);
            model.OrderEntity.Date = model.OrderEntity.DeliveryDate.ToShortDateString();
            return View(model);
        }

        #region Update

        public ActionResult UpdateOrder(OrderManagement model)
        {
            model.UpdateData(model);
            return RedirectToAction("OrderList");
        }

        #endregion Update

        public ActionResult ShowNotification()
        {
            if (!string.IsNullOrEmpty(LoginInfo.UserID))
            {
                OrderManagement model = new OrderManagement();
                model.OrderEntity.CustomerID = Int32.Parse(LoginInfo.UserID);
                var dataList = model.NotiDataList(model);
                var filteredList = dataList.Where(item => item.Status != "pending").ToList();
                ViewBag.FilteredList = filteredList;
                return View();
            }
            else
            {
                return View();
            }
        }

        public void ExportExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "OrderID";
            Sheet.Cells["B1"].Value = "MenuName";
            Sheet.Cells["C1"].Value = "CustomerID";
            Sheet.Cells["D1"].Value = "FirstName";
            Sheet.Cells["E1"].Value = "LastName";
            Sheet.Cells["F1"].Value = "DeliveryDate";
            Sheet.Cells["G1"].Value = "DeliveryTime";
            Sheet.Cells["H1"].Value = "DeliveryAddress";
            Sheet.Cells["I1"].Value = "Note";
            Sheet.Cells["J1"].Value = "SelectedPax";
            Sheet.Cells["K1"].Value = "TotalAmount";
            Sheet.Cells["L1"].Value = "Status";
            Sheet.Cells["M1"].Value = "RejectReason";
            Sheet.Cells["N1"].Value = "CancelReason";
            Sheet.Cells["O1"].Value = "PaymentMethod";
            Sheet.Cells["P1"].Value = "PaymentStatus";
            Sheet.Cells["Q1"].Value = "PhoneNo";
            Sheet.Cells["R1"].Value = "Email";
            int row = 2;
            foreach (var item in SessionModel.OrderList)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.OrderID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.MenuEntity.MenuName;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.CustomerID;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.CustomerEntity.FirstName;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.CustomerEntity.LastName;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.DeliveryDate;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.DeliveryTime;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.DeliveryAddress;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.Note;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.DishQuantity;
                Sheet.Cells[string.Format("K{0}", row)].Value = item.TotalAmount;
                Sheet.Cells[string.Format("L{0}", row)].Value = item.Status;
                Sheet.Cells[string.Format("M{0}", row)].Value = item.RejectReason;
                Sheet.Cells[string.Format("N{0}", row)].Value = item.CancelReason;
                Sheet.Cells[string.Format("O{0}", row)].Value = item.PaymentMethodEntity.PaymentMethod;
                Sheet.Cells[string.Format("P{0}", row)].Value = item.PaymentEntity.Status;
                Sheet.Cells[string.Format("Q{0}", row)].Value = item.CustomerEntity.PhoneNo;
                Sheet.Cells[string.Format("R{0}", row)].Value = item.CustomerEntity.Email;

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