using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;
using System.Web;

namespace Moment_Catering_System.Models
{
    public class DishMaintenance : BaseDA
    {
        public DishMaintenance()
        {
            this.DishEntity = new BaseTB_DishEntity();
            this.DishList = new List<BaseTB_DishEntity>();
        }

        public BaseTB_DishEntity DishEntity { get; set; }
        public List<BaseTB_DishEntity> DishList { get; set; }

        #region "Get Menu List"

        public Dictionary<string, string> GetMenuList()
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

        #endregion "Get Menu List"

        #region "Get Data List"

        public void GetDataList()
        {
            BaseTB_Dish model = new BaseTB_Dish();
            this.DishList = model.GetDataList();
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(int dishID)
        {
            BaseTB_Dish role = new BaseTB_Dish();
            this.DishEntity = role.GetData(dishID);
        }

        #endregion "Get Data"

        #region "Add Data"

        public void AddData(BaseTB_DishEntity entityInfo)
        {
            BaseTB_Dish role = new BaseTB_Dish();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    role.DataInsert(con, tran, entityInfo);
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    var msg = exp.Message;
                    tran.Rollback();
                }
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(BaseTB_DishEntity entityInfo)
        {
            BaseTB_Dish role = new BaseTB_Dish();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    role.DataUpdate(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region "Delete Data"

        public void DeleteData(int roleID)
        {
            BaseTB_Dish role = new BaseTB_Dish();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    role.DataDelete(
                        con, tran, roleID);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Delete Data"

        #region Get Data List for Display
        public void GetDataList(int menuID)
        {
            BaseTB_Dish model = new BaseTB_Dish();
            this.DishList = model.GetDataListforDisplay(menuID);
        }
        #endregion
    }
}