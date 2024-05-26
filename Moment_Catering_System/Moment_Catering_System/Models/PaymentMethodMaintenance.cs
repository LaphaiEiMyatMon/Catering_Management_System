using Moment_Catering_System.Models.Base;
using System;
using Moment_Catering_System.Common;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class PaymentMethodMaintenance : BaseDA
    {
        public PaymentMethodMaintenance()
        {
            this.PaymentMethodEntity = new BaseTB_PaymentMethodEntity();
            this.PaymentMethodList = new List<BaseTB_PaymentMethodEntity>();
        }

        public BaseTB_PaymentMethodEntity PaymentMethodEntity { get; set; }

        public List<BaseTB_PaymentMethodEntity> PaymentMethodList { get; set; }

        #region "Get Data"

        public void GetData(int PaymentMethodID)
        {
            BaseTB_PaymentMethod PaymentMethod = new BaseTB_PaymentMethod();
            this.PaymentMethodEntity = PaymentMethod.GetData(PaymentMethodID);
        }

        #endregion "Get Data"

        #region "Get Data List"

        public void GetDataList()
        {
            BaseTB_PaymentMethod PaymentMethod = new BaseTB_PaymentMethod();
            this.PaymentMethodList = PaymentMethod.GetDataList();
        }

        #endregion "Get Data List"

        #region "Add Data"

        public void AddData(BaseTB_PaymentMethodEntity entity)
        {
           
            BaseTB_PaymentMethod basePaymentMethod = new BaseTB_PaymentMethod();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entity);

                    basePaymentMethod.DataInsert(con, tran, entity);

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

        public void UpdateData(BaseTB_PaymentMethodEntity entityInfo)
        {
            BaseTB_PaymentMethod PaymentMethod = new BaseTB_PaymentMethod();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(entityInfo);
                    PaymentMethod.DataUpdate(con, tran, entityInfo);

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

        public void DeleteData(int PaymentMethodID)
        {
            BaseTB_PaymentMethod PaymentMethod = new BaseTB_PaymentMethod();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    PaymentMethod.DataDelete(
                        con, tran, PaymentMethodID);

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