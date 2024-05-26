using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class SupplierManagement : BaseDA
    {
        public SupplierManagement()
        {
            this.SupplierEntity = new BaseTB_SupplierEntity();
            this.SupplierList = new List<BaseTB_SupplierEntity>();
        }

        public BaseTB_SupplierEntity SupplierEntity { get; set; }

        public List<BaseTB_SupplierEntity> SupplierList { get; set; }

        #region "Get Data List"

        public void GetDataList()
        {
            BaseTB_Supplier Supplier = new BaseTB_Supplier();
            this.SupplierList = Supplier.GetDataList();
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(int SupplierID)
        {
            BaseTB_Supplier Supplier = new BaseTB_Supplier();
            this.SupplierEntity = Supplier.GetData(SupplierID);
        }

        #endregion "Get Data"

        #region "Add Data"

        public void AddData(BaseTB_SupplierEntity entityInfo)
        {
            BaseTB_Supplier Supplier = new BaseTB_Supplier();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    Supplier.DataInsert(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    tran.Rollback();
                }
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(BaseTB_SupplierEntity entityInfo)
        {
            BaseTB_Supplier Supplier = new BaseTB_Supplier();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    Supplier.DataUpdate(con, tran, entityInfo);

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

        public void DeleteData(int SupplierID)
        {
            BaseTB_Supplier Supplier = new BaseTB_Supplier();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    Supplier.DataDelete(
                        con, tran, SupplierID);

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