using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_PurchaseEntity
    {
        private int? _purchaseID;
        private int? _ingredientID;
        private int? _supplierID;
        private DateTime _pDate;
        private decimal _qty;
        private decimal _unitPrice;
        private string _invoiceNo;
        private decimal _totalPrice;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;

        public int? PurchaseID { get => _purchaseID; set => _purchaseID = value; }
        public int? IngredientID { get => _ingredientID; set => _ingredientID = value; }
        public int? SupplierID { get => _supplierID; set => _supplierID = value; }
        public DateTime PDate { get => _pDate; set => _pDate = value; }
        public decimal Qty { get => _qty; set => _qty = value; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
        public decimal TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
        public string UpdatedBy { get => _updatedBy; set => _updatedBy = value; }
        public string InvoiceNo { get => _invoiceNo; set => _invoiceNo = value; }

        public string Name { get; set; }
        public string StaffName { get; set; }
        public string IngredientName { get; set; }
       
    }
}