using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models
{
    public class SessionModel
    {
        public static int MenuID
        {
            get
            {
                return (int)HttpContext.Current.Session[KeyName.MenuID];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.MenuID] = value;
            }
        }

        public static string MenuName
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.MenuName];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.MenuName] = value;
            }
        }

        public static int MinPax
        {
            get
            {
                return (int)HttpContext.Current.Session[KeyName.MinPax];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.MinPax] = value;
            }
        }

        public static int SelectedPax
        {
            get
            {
                return (int)HttpContext.Current.Session[KeyName.SelectedPax];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.SelectedPax] = value;
            }
        }

        public static int NoOfCourse
        {
            get
            {
                return (int)HttpContext.Current.Session[KeyName.NoOfCourse];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.NoOfCourse] = value;
            }
        }

        public static decimal UnitPrice
        {
            get
            {
                return (decimal)HttpContext.Current.Session[KeyName.UnitPrice];
            }

            set
            {
                HttpContext.Current.Session[SessionModel.KeyName.UnitPrice] = value;
            }
        }

        public static List<BaseTB_DishEntity> DishList
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.DishList] == null)
                {
                    // If DishList is not stored in session, initialize it
                    HttpContext.Current.Session[KeyName.DishList] = new List<BaseTB_DishEntity>();
                }
                return (List<BaseTB_DishEntity>)HttpContext.Current.Session[KeyName.DishList];
            }
            set
            {
                HttpContext.Current.Session[KeyName.DishList] = value;
            }
        }

        public static decimal TotalPrice
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session[KeyName.TotalPrice] != null)
                {
                    return (decimal)HttpContext.Current.Session[KeyName.TotalPrice];
                }
                else
                {
                    // Handle the case where the session or the key doesn't exist
                    return 0; // or any default value
                }
            }

            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session[KeyName.TotalPrice] = value;
                }
                else
                {
                    // Handle the case where HttpContext.Current is null
                    // You may want to log this issue or handle it appropriately
                }
            }
        }

        public static List<ExtraDishEntity> ExtraDishList
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.ExtraDishList] == null)
                {
                    // If DishList is not stored in session, initialize it
                    HttpContext.Current.Session[KeyName.ExtraDishList] = new List<ExtraDishEntity>();
                }
                return (List<ExtraDishEntity>)HttpContext.Current.Session[KeyName.ExtraDishList];
            }
            set
            {
                HttpContext.Current.Session[KeyName.ExtraDishList] = value;
            }
        }

        public static List<string> StringExtraDishList
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.StringExtraDishList] == null)
                {
                    // If DishList is not stored in session, initialize it
                    HttpContext.Current.Session[KeyName.StringExtraDishList] = new List<string>();
                }
                return (List<string>)HttpContext.Current.Session[KeyName.StringExtraDishList];
            }
            set
            {
                HttpContext.Current.Session[KeyName.StringExtraDishList] = value;
            }
        }

        public static List<BaseTB_OrderEntity> OrderList
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.OrderList] == null)
                {
                    HttpContext.Current.Session[KeyName.OrderList] = new List<BaseTB_OrderEntity>();
                }
                return (List<BaseTB_OrderEntity>)HttpContext.Current.Session[KeyName.OrderList];
            }
            set
            {
                HttpContext.Current.Session[KeyName.OrderList] = value;
            }
        }

        public static List<BaseTB_PurchaseEntity> PurchaseList
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.PurchaseList] == null)
                {
                    HttpContext.Current.Session[KeyName.PurchaseList] = new List<BaseTB_PurchaseEntity>();
                }
                return (List<BaseTB_PurchaseEntity>)HttpContext.Current.Session[KeyName.PurchaseList];
            }
            set
            {
                HttpContext.Current.Session[KeyName.PurchaseList] = value;
            }
        }


        public static void KillSession()
        {
            HttpContext.Current.Session.Abandon();
        }


        public class KeyName
        {

            public const string SessionModel = "SessionModel";

            public const string MenuID = "MenuID";

            public const string MenuName = "MenuName";

            public const string MinPax = "MinPax";

            public const string SelectedPax = "SelectedPax";

            public const string NoOfCourse = "NoOfCourse";

            public const string UnitPrice = "UnitPrice";

            public const string DishList = "DishList";

            public const string TotalPrice = "TotalPrice";

            public const string ExtraDishList = "ExtraDishList";

            public const string StringExtraDishList = "StringExtraDishList";

            public const string OrderList = "OrderList";

            public const string PurchaseList = "PurchaseList";
        }
    }
}