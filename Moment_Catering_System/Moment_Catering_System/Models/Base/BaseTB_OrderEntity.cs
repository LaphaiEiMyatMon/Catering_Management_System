using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_OrderEntity
    {

        public BaseTB_OrderEntity()
        {
            this.CustomerEntity = new BaseTB_CustomerEntity();
            this.MenuEntity = new BaseTB_MenuEntity();
            this.PaymentMethodEntity = new BaseTB_PaymentMethodEntity();
            this.PaymentEntity = new BaseTB_PaymentEntity();
        }
        private int _orderID;
        private int _menuID;
        private int _customerID;
        private DateTime _deliveryDate;
        private string _deliveryTime;
        private string _deliveryAddress;
        private string _note;
        private int _dishQuantity;
        private decimal _discount;
        private decimal _totalAmount;
        private string _status;
        private string _rejectReason;
        private string _cancelReason;
        private string _staffID;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int MenuID { get => _menuID; set => _menuID = value; }
        public int CustomerID { get => _customerID; set => _customerID = value; }
        public DateTime DeliveryDate { get => _deliveryDate; set => _deliveryDate = value; }
        public string DeliveryTime { get => _deliveryTime; set => _deliveryTime = value; }
        public string DeliveryAddress { get => _deliveryAddress; set => _deliveryAddress = value; }
        public string Note { get => _note; set => _note = value; }
        public int DishQuantity { get => _dishQuantity; set => _dishQuantity = value; }
        public decimal Discount { get => _discount; set => _discount = value; }
        public decimal TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        
        public string RejectReason { get => _rejectReason; set => _rejectReason = value; }
        public string CancelReason { get => _cancelReason; set => _cancelReason = value; }
        public string StaffID { get => _staffID; set => _staffID = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
        public string UpdatedBy { get => _updatedBy; set => _updatedBy = value; }

        public string Date { get; set; }
        public BaseTB_CustomerEntity CustomerEntity { get; set; }
        public BaseTB_PaymentMethodEntity PaymentMethodEntity { get; set; }
        public BaseTB_PaymentEntity PaymentEntity { get; set; }
        public BaseTB_MenuEntity MenuEntity { get; set; }
        public string Status { get => _status; set => _status = value; }

        public int Count { get; set; }
    }
}