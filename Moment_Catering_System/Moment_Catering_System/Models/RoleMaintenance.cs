using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class RoleMaintenance : BaseDA
    {
        public RoleMaintenance()
        {
            this.RoleEntity = new BaseTB_RoleEntity();
            this.RoleList = new List<BaseTB_RoleEntity>();
        }

        public BaseTB_RoleEntity RoleEntity { get; set; }

        public List<BaseTB_RoleEntity> RoleList { get; set; }

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
            BaseTB_Role role = new BaseTB_Role();
            this.RoleList = role.GetDataList();
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(int roleID)
        {
            BaseTB_Role role = new BaseTB_Role();
            this.RoleEntity = role.GetData(roleID);
        }

        #endregion "Get Data"

        #region "Add Data"

        public void AddData(BaseTB_RoleEntity entityInfo)
        {
            BaseTB_Role role = new BaseTB_Role();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    role.DataInsert(con, tran, entityInfo);

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

        public void UpdateData(BaseTB_RoleEntity entityInfo)
        {
            BaseTB_Role role = new BaseTB_Role();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
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
            BaseTB_Role role = new BaseTB_Role();
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
    }
}