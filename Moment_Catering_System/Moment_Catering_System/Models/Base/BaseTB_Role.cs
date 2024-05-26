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
    public class BaseTB_Role : BaseTB_RoleEntity
    {
        #region Get Data
        public virtual BaseTB_RoleEntity GetData(int roleID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@RoleID"] = roleID;

            whereStr.AppendLine(" RoleID = @RoleID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }
            return this;
        }
        #endregion

        #region Get Data table
        public virtual DataTable GetDataTable(string selectWhere, Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * ");
            sql.AppendLine(" FROM  ");
            sql.AppendLine(" [TB_Role] ");
            var param = new QueryParamList();
            if (!string.IsNullOrEmpty(selectWhere))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(selectWhere);
                foreach (var key in whereParam.Keys)
                {
                    string k = key;
                    object value = whereParam[key];

                    param.Add(key, value);
                }
            }
            return DataBase.ExecuteAdapter(sql.ToString(), param);

        }
        #endregion

        #region Get Data List
        public virtual List<BaseTB_RoleEntity> GetDataList()
        {
            var list = new List<BaseTB_RoleEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_RoleEntity();

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
            sql.AppendLine(" * FROM [TB_Role]");
            

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_RoleEntity targetClass,
          DataRow row)
        {
            targetClass.RoleID = NullableValueExtension.DBNullToIntegerZero(row["RoleID"]);
            targetClass.RoleName = row["RoleName"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();         
        }
        #endregion

        #region "Insert Data"
        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RoleEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsRoleIDNull())
            {
                columnList.Add("RoleID");
                paramList.Add("@RoleID");
            }

            if (!srcClass.IsRoleNameNull())
            {
                columnList.Add("RoleName");
                paramList.Add("@RoleName");
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
            sql.AppendLine(" INSERT INTO [TB_Role] ");
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

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_RoleEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsRoleNameNull())
            {
                setList.Add("RoleName = @RoleName");
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
            sql.AppendLine("     [TB_Role] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     RoleID = @RoleID");        

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }
        #endregion

        #region "Delete Data"
        public virtual int DataDelete(
            DbConnection con,
            DbTransaction tran,
            int roleID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Role] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     RoleId = @RoleId");
          

            var param = new QueryParamList();
            param.Add("@RoleID", roleID);
            

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
           BaseTB_RoleEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@RoleID", srcClass.RoleID.ToNonNullable());
            param.Add("@RoleName", srcClass.RoleName.ToNonNullable());
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());
  
            return param;
        }
        #endregion




    }
}