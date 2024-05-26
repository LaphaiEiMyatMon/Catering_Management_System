using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_ExtraDishEntity
    {
        private int _orderID;
        private int _dishID;
        private int _qty;
        private string _dishName;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int DishID { get => _dishID; set => _dishID = value; }
        public int Qty { get => _qty; set => _qty = value; }
        public string DishName { get => _dishName; set => _dishName = value; }
    }
}