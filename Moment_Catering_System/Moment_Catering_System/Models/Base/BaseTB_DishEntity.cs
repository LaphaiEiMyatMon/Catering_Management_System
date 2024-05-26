using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_DishEntity
    {
        private int? _dishID;
        private int? _menuID;
        private string _dishName;
        private string _picture;
        private decimal _unitPrice;

        public int? DishID { get => _dishID; set => _dishID = value; }
        public int? MenuID { get => _menuID; set => _menuID = value; }
        public string DishName { get => _dishName; set => _dishName = value; }
        public string Picture { get => _picture; set => _picture = value; }
        public HttpPostedFileBase FileBase { get; set; }
        public string MenuName { get; set; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
    }
}