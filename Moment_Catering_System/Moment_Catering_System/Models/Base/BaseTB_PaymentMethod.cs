using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_PaymentMethod : BaseTB_PaymentMethodEntity
    {
        #region "Get Data"
        public virtual BaseTB_PaymentMethodEntity GetData(
           int PaymentMethodID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@PaymentMethodID"] = PaymentMethodID;

            whereStr.AppendLine("     PaymentMethodID = @PaymentMethodID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }
        #endregion

        #region "Get Data Table"
        public virtual DataTable GetDataTable(
        string selectWhere,
        Dictionary<string, object> whereParam,
        string strOrderBy = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT *");
            sql.AppendLine(" FROM ");
            sql.AppendLine("     [TB_PaymentMethods]");

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
        #endregion

        #region "Get Data List"
        public virtual List<BaseTB_PaymentMethodEntity> GetDataList()
        {
            var list = new List<BaseTB_PaymentMethodEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_PaymentMethodEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Data Table For List"
        public virtual DataTable GetDataTableForList()
        {

            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [TB_PaymentMethods]");

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        public virtual void SetData(
            BaseTB_PaymentMethodEntity targetClass,
            DataRow row)
        {
            targetClass.PaymentMethodID = NullableValueExtension.DBNullToIntegerZero(row["PaymentMethodID"]);
            targetClass.PaymentMethod = row["PaymentMethod"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }


        public virtual int DataInsert(
            DbConnection con,
            DbTransaction tran,
            BaseTB_PaymentMethodEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsPaymentMethodIDNull())
            {
                columnList.Add("PaymentMethodID");
                paramList.Add("@PaymentMethodID");
            }

            if (!srcClass.IsPaymentMethodNull())
            {
                columnList.Add("PaymentMethod");
                paramList.Add("@PaymentMethod");
            }


            if (!srcClass.IsCreatedAtNull())
            {
                columnList.Add("CreatedAt");
                paramList.Add("@CreatedAt");
            }

            if (!srcClass.IsCreatedByNull())
            {
                columnList.Add("CreatedBy");
                paramList.Add("@CreatedBy");
            }


            if (!srcClass.IsUpdatedAtNull())
            {
                columnList.Add("UpdatedAt");
                paramList.Add("@UpdatedAt");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                columnList.Add("UpdatedBy");
                paramList.Add("@UpdatedBy");
            }



            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_PaymentMethods] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        public virtual int DataUpdate(
            DbConnection con,
            DbTransaction tran,
            BaseTB_PaymentMethodEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsPaymentMethodNull())
            {
                setList.Add("PaymentMethod = @PaymentMethod");
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
            sql.AppendLine("     [TB_PaymentMethods] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     PaymentMethodID = @PaymentMethodID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }


        public virtual int DataDelete(
            DbConnection con,
            DbTransaction tran,
            int PaymentMethodID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_PaymentMethods] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     PaymentMethodID = @PaymentMethodID");

            var param = new QueryParamList();
            param.Add("@PaymentMethodID", PaymentMethodID);


            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }


        private QueryParamList GetParameter(
            BaseTB_PaymentMethodEntity srcClass,
            bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@PaymentMethodID", srcClass.PaymentMethodID);
            param.Add("@PaymentMethod", srcClass.PaymentMethod);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
    }
}