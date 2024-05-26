using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Purchase : BaseTB_PurchaseEntity
    {
        #region Insert

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_PurchaseEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Purchase] ");
            sql.AppendLine(" (IngredientID, SupplierID, Date, Qty, UnitPrice, TotalPrice, InvoiceNo, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@IngredientID, @SupplierID, @Date, @Qty, @UnitPrice, @TotalPrice, @InvoiceNo, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy);");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        #endregion Insert

        #region Get Data

        public virtual BaseTB_PurchaseEntity GetData(int PurchaseID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@PurchaseID"] = PurchaseID;

            whereStr.AppendLine(" PurchaseID = @PurchaseID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }
            return this;
        }

        #endregion Get Data

        #region Get Data table

        public virtual DataTable GetDataTable(
            string selectWhere,
            Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * FROM [VW_FullPurchaseInfo]");

            if (!string.IsNullOrEmpty(selectWhere))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(selectWhere);
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

        #endregion Get Data table

        #region Get Data List

        public virtual List<BaseTB_PurchaseEntity> GetDataList(PurchaseSearchModel param)
        {
            var list = new List<BaseTB_PurchaseEntity>();
            var dt = this.GetDataTableForList(param);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_PurchaseEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        #endregion Get Data List

        #region "Get Data Table For List"

        public virtual DataTable GetDataTableForList(PurchaseSearchModel param)
        {
            if (param.ToDate == DateTime.MinValue)
            {
                param.ToDate = System.DateTime.Today;
            }

            var sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM [VW_FullPurchaseInfo] WHERE 1 = 1");

            var parameters = new QueryParamList();

            if (param.PurchaseID.HasValue)
            {
                sql.AppendLine("AND PurchaseID = @PurchaseID");
                parameters.Add("@PurchaseID", param.PurchaseID);
            }
            else
            {
                if (param.SupplierID != 0)
                {
                    sql.AppendLine("AND SupplierID = @SupplierID");
                    parameters.Add("@SupplierID", param.SupplierID);
                }

                if (param.IngredientID != 0)
                {
                    sql.AppendLine("AND IngredientID = @IngredientID");
                    parameters.Add("@IngredientID", param.IngredientID);
                }

                if (!string.IsNullOrEmpty(param.InvoiceNo))
                {
                    sql.AppendLine("AND InvoiceNo = @InvoiceNo");
                    parameters.Add("@InvoiceNo", param.InvoiceNo);
                }

                if (param.FromDate != DateTime.MinValue)
                {
                    sql.AppendLine("AND Date BETWEEN @FromDate AND @ToDate");
                    parameters.Add("@FromDate", param.FromDate);
                    parameters.Add("@ToDate", param.ToDate);
                }

               
            }

           

            return DataBase.ExecuteAdapter(sql.ToString(), parameters);
        }


        #endregion "Get Data Table For List"

        #region "Update Data"

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_PurchaseEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Purchase] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(" IngredientID=@IngredientID, SupplierID=@SupplierID, Date=@Date, Qty=@Qty, UnitPrice=@UnitPrice, TotalPrice=@TotalPrice, InvoiceNo=@InvoiceNo, CreatedAt=@CreatedAt, CreatedBy=@CreatedBy, UpdatedAt=@UpdatedAt, UpdatedBy=@UpdatedBy ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     PurchaseID = @PurchaseID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }

        #endregion "Update Data"

        #region "Delete Data"

        public virtual int DataDelete(
            DbConnection con,
            DbTransaction tran,
            int id
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM [TB_Purchase] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     PurchaseID = @PurchaseID");

            var param = new QueryParamList();
            param.Add("@PurchaseID", id);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }

        #endregion "Delete Data"

        #region "SetData"

        public virtual void SetData(
          BaseTB_PurchaseEntity targetClass,
          DataRow row)
        {
            targetClass.PurchaseID = NullableValueExtension.DBNullToIntegerZero(row["PurchaseID"]);
            if (!DBNull.Value.Equals(row["Date"]))
                targetClass.PDate = (DateTime)row["Date"];
            targetClass.InvoiceNo = row["InvoiceNo"].ToString();
            targetClass.UnitPrice = NullableValueExtension.DBNullToDecimalZero(row["UnitPrice"]);
            targetClass.Qty = NullableValueExtension.DBNullToDecimalZero(row["Qty"]);
            targetClass.TotalPrice = NullableValueExtension.DBNullToDecimalZero(row["TotalPrice"]);
            targetClass.IngredientID = NullableValueExtension.DBNullToIntegerZero(row["IngredientID"]);
            targetClass.IngredientName = row["IngredientName"].ToString();
            targetClass.SupplierID = NullableValueExtension.DBNullToIntegerZero(row["SupplierID"]);
            targetClass.Name = row["Name"].ToString();
            targetClass.StaffName = row["StaffName"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }

        #endregion "SetData"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_PurchaseEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@PurchaseID", srcClass.PurchaseID.ToNonNullable());
            param.Add("@IngredientID", srcClass.IngredientID.ToNonNullable());
            param.Add("@SupplierID", srcClass.SupplierID.ToNonNullable());
            param.Add("@Date", srcClass.PDate);
            param.Add("@Qty", srcClass.Qty);
            param.Add("@UnitPrice", srcClass.UnitPrice);
            param.Add("@TotalPrice", srcClass.TotalPrice);
            param.Add("@InvoiceNo", srcClass.InvoiceNo);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());
            return param;
        }

        #endregion "Get Parameter"
    }
}