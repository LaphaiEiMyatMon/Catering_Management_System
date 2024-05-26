using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models
{
    public class PassData
    {
        public List<ExtraDishEntity> ExtraDishList { get; set; }
        public List<string> StringExtraDishList { get; set; }
        public decimal TotalPrice { get; set; }
        public int SelectedPax { get; set; }
    }

    public class ExtraDishEntity
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public int Quantity { get; set; }

    }

}