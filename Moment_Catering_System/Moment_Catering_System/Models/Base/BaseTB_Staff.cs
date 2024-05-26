using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Staff : BaseTB_StaffEntity
    {
        #region Get Data

        public virtual BaseTB_StaffEntity GetData(string staffID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@StaffID"] = staffID;

            whereStr.AppendLine(" StaffID = @StaffID");

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

        public virtual DataTable GetDataTable(string selectWhere, Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * ");
            sql.AppendLine(" FROM  ");
            sql.AppendLine(" [VW_FullStaffInfo] ");
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

        #endregion Get Data table

        #region Get Data List

        public virtual List<BaseTB_StaffEntity> GetDataList(StaffMaintenance model)
        {
            var list = new List<BaseTB_StaffEntity>();
            var dt = this.GetDataTableForList(model);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_StaffEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        #endregion Get Data List

        #region "Get Data Table"

        public virtual DataTable GetDataTableForList(StaffMaintenance model)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [VW_FullStaffInfo]");
            sql.AppendLine(" WHERE 1=1");

            var parameters = new QueryParamList();

            if (!string.IsNullOrEmpty(model.StaffEntity.StaffID))
             {
                sql.AppendLine("AND StaffID = @StaffID");
                parameters.Add("@StaffID", model.StaffEntity.StaffID);
            }
            else
            {

                if (!string.IsNullOrEmpty(model.StaffEntity.StaffName))
                {
                    sql.AppendLine("AND StaffName LIKE @StaffName");
                    parameters.Add("@StaffName", "%" + model.StaffEntity.StaffName);
                }
            }
                return DataBase.ExecuteAdapter(sql.ToString(),parameters);
        }

        #endregion "Get Data Table"

        #region "SetData"

        public virtual void SetData(
          BaseTB_StaffEntity targetClass,
          DataRow row)
        {
            targetClass.StaffID = row["StaffID"].ToString();
            targetClass.RoleID = NullableValueExtension.DBNullToIntegerZero(row["RoleID"]);
            targetClass.BranchNo = NullableValueExtension.DBNullToIntegerZero(row["BranchNo"]);
            targetClass.StaffName = row["StaffName"].ToString();
            targetClass.Password = row["Password"].ToString();
            targetClass.BranchName = row["BranchName"].ToString();
            targetClass.RoleName = row["RoleName"].ToString();
            targetClass.ProfilePicture = row["ProfilePicture"].ToString();
            targetClass.IsActive = row["IsActive"] != DBNull.Value ? (bool)row["IsActive"] : false;
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }

        #endregion "SetData"

        #region "Insert Data"

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_StaffEntity srcClass = null)
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

            if (!srcClass.IsBranchNoNull())
            {
                columnList.Add("BranchNo");
                paramList.Add("@BranchNo");
            }

            if (!srcClass.IsStaffNameNull())
            {
                columnList.Add("StaffName");
                paramList.Add("@StaffName");
            }

            if (!srcClass.IsPasswordNull())
            {
                columnList.Add("Password");
                paramList.Add("@Password");
            }

            if (!srcClass.IsProfilePictureNull())
            {
                columnList.Add("ProfilePicture");
                paramList.Add("@ProfilePicture");
            }

            if (!srcClass.IsIsActiveNull())
            {
                columnList.Add("IsActive");
                paramList.Add("@IsActive");
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
            sql.AppendLine(" INSERT INTO [TB_Staff] ");
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

        #endregion "Insert Data"

        #region "Update Data"

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_StaffEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Staff] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(" BranchNo=@BranchNo, RoleID=@RoleID,StaffName = @StaffName,Password = @Password, ProfilePicture = @ProfilePicture, IsActive = @IsActive ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     StaffID = @StaffID");

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
            int StaffID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Staff] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     StaffID = @StaffID");

            var param = new QueryParamList();
            param.Add("@StaffID", StaffID);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }

        #endregion "Delete Data"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_StaffEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();
            param.Add("@RowKey", srcClass.RowKey);
            param.Add("@StaffID", srcClass.StaffID);
            param.Add("@RoleID", srcClass.RoleID.ToNonNullable());
            param.Add("@BranchNo", srcClass.BranchNo.ToNonNullable());
            param.Add("@StaffName", srcClass.StaffName);
            param.Add("@Password", srcClass.Password);
            param.Add("@ProfilePicture", srcClass.ProfilePicture);
            param.Add("@IsActive", srcClass.IsActive);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }

        #endregion "Get Parameter"
    }
}