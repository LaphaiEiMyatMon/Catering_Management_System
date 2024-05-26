using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Payment : BaseTB_PaymentEntity
    {
        #region "Insert Data"

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_PaymentEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Payments] ");
            sql.AppendLine(" (OrderID, CustomerID, PaymentMethodID, PaymentAmount, Status, Notes, CardNumber, CardHolderName, ExpirationDate, CVV, AccountNumber, BillingAddress, MobileWalletAcc, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@OrderID, @CustomerID, @PaymentMethodID, @PaymentAmount, @Status, @Notes, @CardNumber, @CardHolderName, @ExpirationDate, @CVV, @AccountNumber, @BillingAddress, @MobileWalletAcc, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy) ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        #endregion "Insert Data"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_PaymentEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@PaymentID", srcClass.PaymentID);
            param.Add("@OrderID", srcClass.OrderID);
            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@PaymentMethodID", srcClass.PaymentMethodID);
            param.Add("@PaymentAmount", srcClass.PaymentAmount);
            param.Add("@Status", srcClass.Status);
            param.Add("@Notes", srcClass.Notes);
            param.Add("@CardNumber", srcClass.CardNumber);
            param.Add("@CardHolderName", srcClass.CardHolderName);
            param.Add("@ExpirationDate", srcClass.ExpirationDate);
            param.Add("@CVV", srcClass.CVV);
            param.Add("@AccountNumber", srcClass.AccountNumber);
            param.Add("@BillingAddress", srcClass.BillingAddress);
            param.Add("@MobileWalletAcc", srcClass.MobileWalletAcc);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }

        #endregion "Get Parameter"

        #region "Get Data"

        public virtual BaseTB_PaymentEntity GetDataDisplay(
           int orderID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@OrderID"] = orderID;

            whereStr.AppendLine("     OrderID = @OrderID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }

        #endregion "Get Data"

        #region "Get Data"

        public virtual BaseTB_PaymentEntity GetData(
           int paymentID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@PaymentID"] = paymentID;

            whereStr.AppendLine("     PaymentID = @PaymentID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }

        #endregion "Get Data"

        #region "Get Data Table"

        public virtual DataTable GetDataTable(
        string selectWhere,
        Dictionary<string, object> whereParam,
        string strOrderBy = null)
        {
            var sql = new StringBuilder();

            sql.AppendLine("SELECT * FROM TB_Payments");

            if (!string.IsNullOrEmpty(selectWhere))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(selectWhere);
            }

            if (!string.IsNullOrEmpty(strOrderBy))
            {
                sql.AppendLine(" ORDER BY ");
                sql.AppendLine(strOrderBy);
            }

            var param = new QueryParamList();
            foreach (var key in whereParam.Keys)
            {
                string k = key;
                object value = whereParam[key];

                param.Add(key, value);
            }

            return DataBase.ExecuteAdapter(sql.ToString(), param);
        }

        #endregion "Get Data Table"

        #region "Get Data List"

        public virtual List<BaseTB_PaymentEntity> GetDataList(PaymentMaintenance model)
        {
            var list = new List<BaseTB_PaymentEntity>();
            var dt = this.GetDataTableForList(model);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_PaymentEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        #endregion "Get Data List"

        #region "Get Data Table For List"

        public virtual DataTable GetDataTableForList(PaymentMaintenance model)
        {
            var sql = new StringBuilder();
            var parameters = new QueryParamList();

            if (string.IsNullOrEmpty(LoginInfo.UserID) || !LoginInfo.UserID.StartsWith("S"))
            {
                model.PaymentEntity.CustomerID = Int32.Parse(LoginInfo.UserID);
                model.PaymentEntity.Status = "paid";
            }

            sql.AppendLine("SELECT * FROM TB_Payments WHERE Status != 'pending'");

            if (model.PaymentEntity.PaymentID != 0)
            {
                sql.AppendLine("AND PaymentID = @PaymentID");
                parameters.Add("@PaymentID", model.PaymentEntity.PaymentID);
            }
            else
            {
                if (model.PaymentEntity.CustomerID != 0)
                {
                    sql.AppendLine("AND CustomerID = @CustomerID");
                    parameters.Add("@CustomerID", model.PaymentEntity.CustomerID);
                }
                if (model.PaymentEntity.Status != null)
                {
                    sql.AppendLine("AND Status = @Status");
                    parameters.Add("@Status", model.PaymentEntity.Status);
                }
            }

                return DataBase.ExecuteAdapter(sql.ToString(), parameters);
        }

        #endregion "Get Data Table For List"

        public virtual void SetData(
            BaseTB_PaymentEntity targetClass,
            DataRow row)
        {
            targetClass.PaymentID = NullableValueExtension.DBNullToIntegerZero(row["PaymentID"]);
            targetClass.OrderID = NullableValueExtension.DBNullToIntegerZero(row["OrderID"]);
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            targetClass.PaymentMethodID = NullableValueExtension.DBNullToIntegerZero(row["PaymentMethodID"]);
            targetClass.PaymentAmount = NullableValueExtension.DBNullToDecimalZero(row["PaymentAmount"]);
            targetClass.Status = row["Status"].ToString();
            targetClass.Notes = row["Notes"].ToString();

            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_PaymentEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsOrderIDNull())
            {
                setList.Add("OrderID = @OrderID");
            }

            if (!srcClass.IsCustomerIDNull())
            {
                setList.Add("CustomerID = @CustomerID");
            }

            if (!srcClass.IsPaymentMethodIDNull())
            {
                setList.Add("PaymentMethodID = @PaymentMethodID");
            }

            if (!srcClass.IsPaymentAmountNull())
            {
                setList.Add("PaymentAmount = @PaymentAmount");
            }

            if (!srcClass.IsStatusNull())
            {
                setList.Add("Status = @Status");
            }

            if (!srcClass.IsNotesNull())
            {
                setList.Add("Notes = @Notes");
            }

            if (!srcClass.IsCardNumberNull())
            {
                setList.Add("CardNumber = @CardNumber");
            }

            if (!srcClass.IsCardHolderNameNull())
            {
                setList.Add("CardHolderName = @CardHolderName");
            }
            if (!srcClass.IsExpirationDateNull())
            {
                setList.Add("ExpirationDate = @ExpirationDate");
            }

            if (!srcClass.IsCVVNull())
            {
                setList.Add("CVV = @CVV");
            }

            if (!srcClass.IsAccountNumberNull())
            {
                setList.Add("AccountNumber = @AccountNumber");
            }

            if (!srcClass.IsBillingAddressNull())
            {
                setList.Add("BillingAddress = @BillingAddress");
            }

            if (!srcClass.IsMobileWalletAccNull())
            {
                setList.Add("MobileWalletAcc = @MobileWalletAcc");
            }

            if (!srcClass.IsCreatedAtNull())
            {
                setList.Add("CreatedAt = @CreatedAt");
            }

            if (!srcClass.IsCreatedByNull())
            {
                setList.Add("CreatedBy = @CreatedBy");
            }

            if (!srcClass.IsUpdatedAtNull())
            {
                setList.Add("UpdatedAt = @UpdatedAt");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                setList.Add("UpdatedBy = @UpdatedBy");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Payments] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     PaymentID = @PaymentID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
    }
}