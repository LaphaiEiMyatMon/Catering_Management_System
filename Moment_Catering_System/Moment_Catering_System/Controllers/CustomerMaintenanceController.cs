using Moment_Catering_System.Models;
using Moment_Catering_System.Models.Base;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Web.Mvc;

namespace Moment_Catering_System.Controllers
{
    public class CustomerMaintenanceController : Controller
    {
        // GET: CustomerMaintenance
        #region Register
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(CustomerMaintenance customer)
        {
            ResultStatus result = new ResultStatus();
            result = customer.CheckDuplicate(customer);

            if (result.Status == false)
            {
                ViewBag.Message = "false";
                return View();
            }
            else
            {
                customer.AddData(customer.CustomerEntity);
                
            }

            if (LoginInfo.UserID != null && LoginInfo.UserID.StartsWith("S"))
            {
                return View("CustomerList");
            }
            TempData["Message"] = "true";
            return RedirectToAction("Login");
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            ViewBag.Message = TempData["Message"];
            LoginInfo.LoginErrorCount = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerMaintenance customer)
        {
            ResultStatus result = customer.GetUser(customer);

            if (!result.Status)
            {
                // Increment login count stored in session
                LoginInfo.LoginErrorCount++;
                if (LoginInfo.LoginErrorCount > 3)
                {
                    return View();
                }
                ViewBag.Message = result.Message;
                return View();
            }

            // Reset login count if login is successful
            LoginInfo.LoginErrorCount = 0;

            if (SessionModel.TotalPrice != 0)
            {
                return RedirectToAction("Checkout", "OrderManagement");
            }
            else
           
            {
                TempData["Message"] = "true";
                return RedirectToAction("DisplayMenu", "OrderManagement");
            }
        }
        #endregion


        public ActionResult Logout()
        {
            SessionModel.KillSession();
            LoginInfo.KillSession();
            Session.Clear();
            ViewBag.Message = "true";
            return View("Login");
        }

        #region "List"

        public ActionResult CustomerList(CustomerMaintenance model)
        {
            model.GetDataList(model);
            ViewBag.Msg = ViewBag.Message;
            return View(model);
        }

        #endregion "List"

        #region "Update"

        public ActionResult EditCustomer(string customerID)
        {
            var customer = new CustomerMaintenance();
            customer.GetData(customerID);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(BaseTB_CustomerEntity customerEntity)
        {
            var customer = new CustomerMaintenance();
            if (customerEntity.FileBase != null)
            {
                byte[] imageBytes;
                using (var binaryReader = new BinaryReader(customerEntity.FileBase.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(customerEntity.FileBase.ContentLength);
                }

                string base64String = Convert.ToBase64String(imageBytes);
                customerEntity.Picture = base64String;
            }

            customer.UpdateData(customerEntity);
            if (LoginInfo.UserID.StartsWith("S"))
            {
                return RedirectToAction("/CustomerList");
            }
            else
            {
                return RedirectToAction("EditCustomer", new { customerID = LoginInfo.UserID });
            }
            
        }

        #endregion "Update"

        #region "Delete"

        public ActionResult DeleteCustomer(int customerID)
        {
            var customer = new CustomerMaintenance();
            customer.DeleteData(customerID);
            return RedirectToAction("CustomerList");
        }

        #endregion "Delete"

        #region Customer Order

        public ActionResult CustomerOrder(int orderID, int menuID)
        {
            OrderManagement order = new OrderManagement();

            order.CustomerOrder(orderID, menuID);
            return View(order);
        }

        #endregion Customer Order

        #region Customer Order List

        public ActionResult CustomerOrderList()
        {
            OrderManagement model = new OrderManagement();
            model.OrderEntity.CustomerID = Int32.Parse(LoginInfo.UserID);
            model.GetDataList(model);
            return View(model);
        }

        #endregion Customer Order List
    }
}