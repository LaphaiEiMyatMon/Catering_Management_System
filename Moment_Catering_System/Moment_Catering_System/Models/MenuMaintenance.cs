using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class MenuMaintenance : BaseDA
    {
        public MenuMaintenance()
        {
            this.MenuEntity = new BaseTB_MenuEntity();
            this.MenuList = new List<BaseTB_MenuEntity>();
        }

        public BaseTB_MenuEntity MenuEntity { get; set; }

        public List<BaseTB_MenuEntity> MenuList { get; set; }

        #region "Get Data"

        public void GetData(int MenuID)
        {
            var menu = new BaseTB_Menu();
            this.MenuEntity = menu.GetData(MenuID);
        }

        #endregion "Get Data"

        #region "Get Data List"

        public void GetDataList()
        {
            var menu = new BaseTB_Menu();
            this.MenuList = menu.GetDataList();
        }

        #endregion "Get Data List"

        #region "Add Data"

        public void AddData(BaseTB_MenuEntity entityInfo)
        {
            var menuEntity = new BaseTB_Menu();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    entityInfo.CreatedAt = DateTime.Now;
                    menuEntity.DataInsert(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(BaseTB_MenuEntity entityInfo)
        {
            var menuEntity = new BaseTB_Menu();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(entityInfo);
                    menuEntity.DataUpdate(con, tran, entityInfo);

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

        public void DeleteData(int menuID)
        {
            var menu = new BaseTB_Menu();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    menu.DataDelete(
                        con, tran, menuID);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Delete Data"
    }
}