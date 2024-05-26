using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class PurchaseSearchModel
    {
        public int? PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public int IngredientID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string InvoiceNo { get; set; }
        public int RowCount { get; set; }

    }
}