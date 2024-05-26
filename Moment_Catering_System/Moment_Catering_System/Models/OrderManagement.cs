using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class OrderManagement : BaseDA
    {
        public OrderManagement()
        {
            this.MenuList = new List<BaseTB_MenuEntity>();
            this.DishList = new List<BaseTB_DishEntity>();
            this.ExtraDishList = new List<BaseTB_ExtraDishEntity>();
            this.PaymentEntity = new BaseTB_PaymentEntity();
            this.CustomerEntity = new BaseTB_CustomerEntity();
            this.OrderEntity = new BaseTB_OrderEntity();
            this.OrderList = new List<BaseTB_OrderEntity>();
            this.MenuEntity = new BaseTB_MenuEntity();
            this.PaymentMethodEntity = new BaseTB_PaymentMethodEntity();
        }

        public List<BaseTB_MenuEntity> MenuList { get; set; }
        public List<BaseTB_DishEntity> DishList { get; set; }
        public List<BaseTB_ExtraDishEntity> ExtraDishList { get; set; }
        public List<BaseTB_OrderEntity> OrderList { get; set; }
        public BaseTB_PaymentMethodEntity PaymentMethodEntity { get; set; }

        public BaseTB_OrderEntity OrderEntity { get; set; }
        public BaseTB_PaymentEntity PaymentEntity { get; set; }
        public BaseTB_CustomerEntity CustomerEntity { get; set; }
        public BaseTB_MenuEntity MenuEntity { get; set; }

        #region "Get Menu List DropDown"

        public Dictionary<string, string> GetMenuListDropDown()
        {
            BaseTB_Menu model = new BaseTB_Menu();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_MenuEntity> list = model.GetDataList();

            foreach (var row in list)
            {
                result[row.MenuID.ToString()] = row.MenuName;
            }
            return result;
        }

        #endregion "Get Menu List DropDown"

        #region Menu List

        public void GetMenuList()
        {
            BaseTB_Menu menu = new BaseTB_Menu();
            this.MenuList = menu.GetDataList();
        }

        #endregion Menu List

        #region Dish List

        public void GetDishList(int menuID)
        {
            BaseTB_Dish dish = new BaseTB_Dish();
            this.DishList = dish.GetDataListforDisplay(menuID);
        }

        #endregion Dish List

        #region Payment Method List

        public Dictionary<string, string> GetPaymentMethodList()
        {
            BaseTB_PaymentMethod model = new BaseTB_PaymentMethod();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_PaymentMethodEntity> list = model.GetDataList();

            foreach (var row in list)
            {
                result[row.PaymentMethodID.ToString()] = row.PaymentMethod;
            }
            return result;
        }

        #endregion Payment Method List

        #region "Add Data"

        public void AddData(OrderManagement model)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Order order = new BaseTB_Order();
            BaseTB_ExtraDish extra = new BaseTB_ExtraDish();
            BaseTB_Payment payment = new BaseTB_Payment();
            CustomerMaintenance cus = new CustomerMaintenance();

            //For order table
            int orderID = 0;
            model.OrderEntity.MenuID = SessionModel.MenuID;
            model.OrderEntity.TotalAmount = SessionModel.TotalPrice;
            model.OrderEntity.Status = "pending";
            model.OrderEntity.DishQuantity = SessionModel.SelectedPax;
            model.OrderEntity.CustomerID = Int32.Parse(LoginInfo.UserID);
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(model.OrderEntity);
                    orderID = order.DataInsert(con, tran, model.OrderEntity);

                    //for customer table
                    BaseTB_CustomerEntity customerEntity = new BaseTB_CustomerEntity
                    {
                        CustomerID = Int32.Parse(LoginInfo.UserID),
                        PhoneNo = model.CustomerEntity.PhoneNo
                    };


                    cus.UpdateData(customerEntity);

                    //for payment table
                    model.PaymentEntity.OrderID = orderID;
                    model.PaymentEntity.CustomerID = Int32.Parse(LoginInfo.UserID);
                    model.PaymentEntity.PaymentAmount = SessionModel.TotalPrice;
                    model.PaymentEntity.Status = "pending";
                    model.PaymentEntity.CreatedAt = model.OrderEntity.CreatedAt;
                    model.PaymentEntity.CreatedBy = model.OrderEntity.CreatedBy;
                    
                    payment.DataInsert(con, tran, model.PaymentEntity);

                    //for extra dish table
                    foreach (var item in SessionModel.ExtraDishList)
                    {
                        BaseTB_ExtraDishEntity extraDishEntity = new BaseTB_ExtraDishEntity
                        {
                            OrderID = orderID,
                            DishID = item.DishID,
                            Qty = item.Quantity
                        };
                        extra.DataInsert(con, tran, extraDishEntity);
                    }

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
   
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(OrderManagement model)
        {
            BaseTB_Order order = new BaseTB_Order();
            BaseTB_Payment payment = new BaseTB_Payment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(model.OrderEntity);
                    if (model.OrderEntity.Status !=null)
                    {
                        model.OrderEntity.StaffID = LoginInfo.UserID;
                    }
                    order.DataUpdate(con, tran, model.OrderEntity);

                    if(model.OrderEntity.Status == "approve")
                    {
                        BaseTB_PaymentEntity paymentEntity = new BaseTB_PaymentEntity
                        {
                            PaymentID = model.PaymentEntity.PaymentID,
                            UpdatedAt = System.DateTime.Today,
                            UpdatedBy = LoginInfo.UserID,
                            Status = "unpaid"

                        };
                        payment.DataUpdate(con, tran, paymentEntity);
                    }
                   
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    var msg = exp.Message;
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region "Get Data List"

        public void GetDataList(OrderManagement model)
        {
            BaseTB_Order order = new BaseTB_Order();
            this.OrderList = order.GetDataList(model);
            SessionModel.OrderList = this.OrderList;
        }

        #endregion "Get Data List"

        #region "Get Data List Noti"

        public List<BaseTB_OrderEntity> NotiDataList(OrderManagement model)
        {
            BaseTB_Order order = new BaseTB_Order();
            this.OrderList = order.GetDataList(model);
            return OrderList;
        }

        #endregion

        #region "Get Data"

        public void GetData(int orderID)
        {
            BaseTB_Order order = new BaseTB_Order();
            BaseTB_ExtraDish extra = new BaseTB_ExtraDish();
            BaseTB_Payment payment = new BaseTB_Payment();
            this.PaymentEntity = payment.GetDataDisplay(orderID);
            this.ExtraDishList = extra.GetDataList(orderID);
            this.OrderEntity = order.GetData(orderID);
        }

        #endregion "Get Data"

        #region "Customer Order Detail Data "

        public void CustomerOrder(int orderID, int menuID)
        {
            BaseTB_Order order = new BaseTB_Order();
            BaseTB_Payment payment = new BaseTB_Payment();
            BaseTB_ExtraDish extra = new BaseTB_ExtraDish();
            BaseTB_Dish dish = new BaseTB_Dish();

            this.PaymentEntity = payment.GetDataDisplay(orderID);
            this.GetDishList(menuID);
            this.ExtraDishList = extra.GetDataList(orderID);
            this.OrderEntity = order.GetData(orderID);
        }

        #endregion "Get Data"
    }
}