using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moment_Catering_System.Models
{
    public class MenuTCMaintenance:BaseDA
    {
        public MenuTCMaintenance()
        {
            this.MenuTCEntity = new BaseTB_MenuTCEntity();
            this.MenuTCList = new List<BaseTB_MenuTCEntity>();
        }

        public BaseTB_MenuTCEntity MenuTCEntity { get; set; }

        public List<BaseTB_MenuTCEntity> MenuTCList { get; set; }

        #region "Get Data"

        public void GetData(int TCID)
        {
            var menutc = new BaseTB_MenuTC();
            this.MenuTCEntity = menutc.GetData(TCID);
        }

        #endregion "Get Data"

        #region "Get Data List"

        public void GetDataList()
        {
            var menutc = new BaseTB_MenuTC();
            this.MenuTCList = menutc.GetDataList();
        }

        #endregion "Get Data List"

        #region "Add Data"

        public void AddData(BaseTB_MenuTCEntity entityInfo)
        {
            var menutcEntity = new BaseTB_MenuTC();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    entityInfo.CreatedAt = DateTime.Now;
                    menutcEntity.DataInsert(con, tran, entityInfo);

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

        public void UpdateData(BaseTB_MenuTCEntity entityInfo)
        {
            var menutcEntity = new BaseTB_MenuTC();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    menutcEntity.DataUpdate(con, tran, entityInfo);

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

        public void DeleteData(int TCID)
        {
            var menutc = new BaseTB_MenuTC();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    menutc.DataDelete(
                        con, tran, TCID);

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