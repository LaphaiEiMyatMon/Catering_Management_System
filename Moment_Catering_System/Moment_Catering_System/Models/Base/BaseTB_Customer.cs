using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Customer : BaseTB_CustomerEntity
    {
        #region Get Data

        public virtual BaseTB_CustomerEntity GetData(string customerID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@CustomerID"] = customerID;

            whereStr.AppendLine(" CustomerID = @CustomerID");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }
            return this;
        }

        #endregion Get Data

        #region login

        public virtual BaseTB_CustomerEntity Login(string Email)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@Email"] = Email;

            whereStr.AppendLine(" Email = @Email");

            var dt = this.GetDataTable(whereStr.ToString(), dic);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }
            return this;
        }

        #endregion login

        #region Get Data table

        public virtual DataTable GetDataTable(string selectWhere, Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT * ");
            sql.AppendLine(" FROM  ");
            sql.AppendLine(" [TB_Customers] ");
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

        public virtual List<BaseTB_CustomerEntity> GetDataList(CustomerMaintenance model)
        {
            var list = new List<BaseTB_CustomerEntity>();
            var dt = this.GetDataTableForList(model);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_CustomerEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        #endregion Get Data List

        #region "Get Data Table For List"

        public virtual DataTable GetDataTableForList(CustomerMaintenance model)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [TB_Customers]");
            sql.AppendLine(" WHERE 1=1");

            var parameters = new QueryParamList();

            if (model.CustomerEntity.CustomerID != null)
            {
                sql.AppendLine("AND CustomerID = @CustomerID");
                parameters.Add("@CustomerID", model.CustomerEntity.CustomerID);
            }
            else
            {

                if (!string.IsNullOrEmpty(model.CustomerEntity.FirstName))
                {
                    sql.AppendLine("AND FirstName LIKE @FirstName");
                    parameters.Add("@FirstName", "%" + model.CustomerEntity.FirstName);
                }

                if (model.CustomerEntity.IsActive != false)
                {
                    sql.AppendLine("AND IsActive = @IsActive");
                    parameters.Add("@IsActive", model.CustomerEntity.IsActive);
                }

                if (model.CustomerEntity.IsBlackListed != false)
                {
                    sql.AppendLine("AND IsBlackListed = @IsBlackListed");
                    parameters.Add("@IsBlackListed", model.CustomerEntity.IsBlackListed);
                }
            }

                return DataBase.ExecuteAdapter(sql.ToString(),parameters);
        }

        #endregion "Get Data Table For List"

        #region "SetData"

        public virtual void SetData(
          BaseTB_CustomerEntity targetClass,
          DataRow row)
        {
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            targetClass.FirstName = row["FirstName"].ToString();
            targetClass.LastName = row["LastName"].ToString();
            targetClass.Picture = row["Picture"].ToString();
            targetClass.Gender = row["Gender"].ToString();
            targetClass.NrcNo = row["NrcNo"].ToString();
            targetClass.Email = row["Email"].ToString();
            targetClass.Address = row["Address"].ToString();
            targetClass.PhoneNo = row["PhoneNo"].ToString();
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            targetClass.Password = row["Password"].ToString();
            targetClass.IsActive = row["IsActive"] != DBNull.Value ? (bool)row["IsActive"] : false;
            targetClass.IsBlackListed = row["IsBlackListed"] != DBNull.Value ? (bool)row["IsBlackListed"] : false;
            targetClass.BlackListedRemarks = row["BlackListedRemarks"].ToString();
            targetClass.LoginCount = NullableValueExtension.DBNullToIntegerZero(row["LoginCount"]);
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
           BaseTB_CustomerEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Customers] ");
            sql.AppendLine(" (FirstName, LastName, Picture, Gender, NRCNo, Email, Address, PhoneNo, Password, IsActive, IsBlackListed, BlackListedRemarks, LoginCount, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@FirstName, @LastName, @Picture, @Gender, @NRCNo, @Email, @Address, @PhoneNo, @Password, @IsActive, @IsBlackListed, @BlackListedRemarks, @LoginCount, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy) ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        #endregion "Insert Data"

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_CustomerEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

           
            if (!srcClass.IsFirstNameNull())
            {
                setList.Add("FirstName = @FirstName");
            }

            if (!srcClass.IsLastNameNull())
            {
                setList.Add("LastName = @LastName");
            }

            if (!srcClass.IsPictureNull())
            {
                setList.Add("Picture = @Picture");
            }

            if (!srcClass.IsGenderNull())
            {
                setList.Add("Gender = @Gender");
            }

            if (!srcClass.IsNrcNoNull())
            {
                setList.Add("NRCNo = @NRCNo");
            }

            if (!srcClass.IsEmailNull())
            {
                setList.Add("Email = @Email");
            }

            if (!srcClass.IsAddressNull())
            {
                setList.Add("Address = @Address");
            }

            if (!srcClass.IsPhoneNoNull())
            {
                setList.Add("PhoneNo = @PhoneNo");
            }

            if (!srcClass.IsRoleIDNull())
            {
                setList.Add("RoleID = @RoleID");
            }

            if (!srcClass.IsPasswordNull())
            {
                setList.Add("Password = @Password");
            }

            if (!srcClass.IsIsActiveNull())
            {
                setList.Add("IsActive = @IsActive");
            }

            if (!srcClass.IsIsBlackListedNull())
            {
                setList.Add("IsBlackListed = @IsBlackListed");
            }

            if (!srcClass.IsBlackListedRemarksNull())
            {
                setList.Add("BlackListedRemarks = @BlackListedRemarks");
            }

            if (!srcClass.IsLoginCountNull())
            {
                setList.Add("LoginCount = @LoginCount");
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
            sql.AppendLine("     [tb_Customers] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     CustomerID = @CustomerID");

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
            int customerID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Customers] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     CustomerID = @CustomerID");

            var param = new QueryParamList();
            param.Add("@CustomerID", customerID);

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
           BaseTB_CustomerEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@CustomerID", srcClass.CustomerID.ToNonNullable());
            param.Add("@FirstName", srcClass.FirstName);
            param.Add("@LastName", srcClass.LastName);
            param.Add("@Picture", srcClass.Picture);
            param.Add("@Gender", srcClass.Gender);
            param.Add("@NRCNo", srcClass.NrcNo);
            param.Add("@Email", srcClass.Email);
            param.Add("@Address", srcClass.Address);
            param.Add("@PhoneNo", srcClass.PhoneNo);
            param.Add("@RoleID", srcClass.RoleID);
            param.Add("@Password", srcClass.Password);
            param.Add("@IsActive", srcClass.IsActive);
            param.Add("@IsBlackListed", srcClass.IsBlackListed);
            param.Add("@BlackListedRemarks", srcClass.BlackListedRemarks);
            param.Add("@LoginCount", srcClass.LoginCount);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }

        #endregion "Get Parameter"

    }
}