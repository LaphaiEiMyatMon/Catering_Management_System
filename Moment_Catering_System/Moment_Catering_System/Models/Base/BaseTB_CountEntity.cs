using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_CountEntity
    {
        public int CustomerCount { get; set; }
        public int StaffCount { get; set; }
        public int OrderCount { get; set; }
        public int PurchaseCount { get; set; }
        public int TotalIncome { get; set; }
        public int TotalExpense { get; set; }
    }
}