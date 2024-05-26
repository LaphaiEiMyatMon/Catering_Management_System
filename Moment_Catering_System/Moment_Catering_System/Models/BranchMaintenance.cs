using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class BranchMaintenance : BaseDA
    {
        public BranchMaintenance()
        {
            this.BranchEntity = new BaseTB_BranchEntity();
            this.BranchList = new List<BaseTB_BranchEntity>();
        }

        public BaseTB_BranchEntity BranchEntity { get; set; }

        public List<BaseTB_BranchEntity> BranchList { get; set; }

        #region "Get Data"

        public void GetData(int branchNo)
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            this.BranchEntity = branch.GetData(branchNo);
        }

        #endregion "Get Data"

        #region "Get Data List"

        public void GetDataList()
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            this.BranchList = branch.GetDataList();
        }

        #endregion "Get Data List"

        #region "Add Data"

        public void AddData(BaseTB_BranchEntity entityInfo)
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    entityInfo.CreatedAt = DateTime.Now;
                    branch.DataInsert(con, tran, entityInfo);

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

        public void UpdateData(BaseTB_BranchEntity entityInfo)
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    branch.DataUpdate(con, tran, entityInfo);

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

        public void DeleteData(int branchNo)
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    branch.DataDelete(
                        con, tran, branchNo);

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