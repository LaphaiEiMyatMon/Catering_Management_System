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
    public class BaseTB_Branch:BaseTB_BranchEntity
    {
        #region "Get Data"
        public virtual BaseTB_BranchEntity GetData(
           int branchNo)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@BranchNo"] = branchNo;

            whereStr.AppendLine("     BranchNo = @BranchNo");

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
            sql.AppendLine("     [TB_Branch]");

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
        public virtual List<BaseTB_BranchEntity> GetDataList()
        {
            var list = new List<BaseTB_BranchEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_BranchEntity();

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
            sql.AppendLine(" * FROM [TB_Branch]");

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "Set Data"
        public virtual void SetData(
            BaseTB_BranchEntity targetClass,
            DataRow row)
        {
            targetClass.BranchNo = NullableValueExtension.DBNullToIntegerZero(row["BranchNo"]);
            targetClass.BranchName = row["BranchName"].ToString();          
            targetClass.Address = row["Address"].ToString();        
            targetClass.CallCenterPhoneNo = row["CallCenterPhoneNo"].ToString();
            targetClass.Email = row["Email"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }
        #endregion

        #region "Data Insert"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_BranchEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsBranchNoNull())
            {
                columnList.Add("BranchNo");
                paramList.Add("@BranchNo");
            }

            if (!srcClass.IsBranchNameNull())
            {
                columnList.Add("BranchName");
                paramList.Add("@BranchName");
            }
            if (!srcClass.IsEmailNull())
            {
                columnList.Add("Email");
                paramList.Add("@Email");
            }


            if (!srcClass.IsAddressNull())
            {
                columnList.Add("Address");
                paramList.Add("@Address");
            }
   

            if (!srcClass.IsCallCenterPhoneNoNull())
            {
                columnList.Add("CallCenterPhoneNo");
                paramList.Add("@CallCenterPhoneNo");
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
            sql.AppendLine(" INSERT INTO [TB_Branch] ");
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

        #endregion

        #region "Data Update"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_BranchEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsBranchNameNull())
            {
                setList.Add("BranchName = @BranchName");
            }
            if (!srcClass.IsEmailNull())
            {
                setList.Add("Email = @Email");
            }

            if (!srcClass.IsAddressNull())
            {
                setList.Add("Address = @Address");
            }

            if (!srcClass.IsCallCenterPhoneNoNull())
            {
                setList.Add("CallCenterPhoneNo = @CallCenterPhoneNo");
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
            sql.AppendLine("     [TB_Branch] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     BranchNo = @BranchNo");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Data Delete"
        public virtual int DataDelete(
           DbConnection con,
           DbTransaction tran,
           int branchNo)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Branch] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     BranchNo = @BranchNo");

            var param = new QueryParamList();
            param.Add("@BranchNo", branchNo);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Get Parameter"
        private QueryParamList GetParameter(
           BaseTB_BranchEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@BranchNo", srcClass.BranchNo);
            param.Add("@BranchName", srcClass.BranchName.ToNonNullable());
            param.Add("@Address", srcClass.Address.ToNonNullable());
            param.Add("@CallCenterPhoneNo", srcClass.CallCenterPhoneNo.ToNonNullable());
            param.Add("@Email", srcClass.Email.ToNonNullable());
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());
            return param;
        }
        #endregion

    }
}