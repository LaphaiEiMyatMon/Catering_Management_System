using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class PaymentMaintenance : BaseDA
    {
        public PaymentMaintenance()
        {
            this.PaymentEntity = new BaseTB_PaymentEntity();
            this.PaymentList = new List<BaseTB_PaymentEntity>();
        }

        

        public BaseTB_PaymentEntity PaymentEntity { get; set; }

        public List<BaseTB_PaymentEntity> PaymentList { get; set; }

        #region "Get Data"

        public void GetData(int PaymentID)
        {
            BaseTB_Payment Payment = new BaseTB_Payment();
            this.PaymentEntity = Payment.GetData(PaymentID);
        }

        #endregion "Get Data"

        #region "Get Data List"

        public void GetDataList(PaymentMaintenance model)
        {
            BaseTB_Payment Payment = new BaseTB_Payment();
            this.PaymentList = Payment.GetDataList(model);
        }

        #endregion "Get Data List"

        #region "Add Data"

        public void AddData(BaseTB_PaymentEntity entity)
        {
            BaseTB_Payment basePayment = new BaseTB_Payment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entity);

                    basePayment.DataInsert(con, tran, entity);

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

        public void UpdateData(BaseTB_PaymentEntity entityInfo)
        {
            BaseTB_Payment Payment = new BaseTB_Payment();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(entityInfo);
                    Payment.DataUpdate(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"


    }
}