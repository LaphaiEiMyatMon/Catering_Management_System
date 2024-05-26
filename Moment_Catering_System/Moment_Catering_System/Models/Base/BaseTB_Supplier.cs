using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Supplier : BaseTB_SupplierEntity
    {

        #region Get Data
        public virtual BaseTB_SupplierEntity GetData(int SupplierID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@SupplierID"] = SupplierID;

            whereStr.AppendLine(" SupplierID = @SupplierID");

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
            sql.AppendLine(" [TB_Suppliers] ");
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
        public virtual List<BaseTB_SupplierEntity> GetDataList()
        {
            var list = new List<BaseTB_SupplierEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_SupplierEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Data Table"
        public virtual DataTable GetDataTableForList()
        {

            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [TB_Suppliers]");


            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_SupplierEntity targetClass,
          DataRow row)
        {
            targetClass.SupplierID = NullableValueExtension.DBNullToIntegerZero(row["SupplierID"]);
            targetClass.Name = row["Name"].ToString();
            targetClass.ContactPerson = row["ContactPerson"].ToString();
            targetClass.ContactNumber = row["ContactNumber"].ToString();
            targetClass.Address = row["Address"].ToString();
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
           BaseTB_SupplierEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }
            #region Query Parameter
            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsNameNull())
            {
                columnList.Add("Name");
                paramList.Add("@Name");
            }
            if (!srcClass.IsContactPersonNull())
            {
                columnList.Add("ContactPerson");
                paramList.Add("@ContactPerson");
            }
            if (!srcClass.IsContactNumberNull())
            {
                columnList.Add("ContactNumber");
                paramList.Add("@ContactNumber");
            }
            if (!srcClass.IsAddressNull())
            {
                columnList.Add("Address");
                paramList.Add("@Address");
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
            #endregion
            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Suppliers] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");

            var param = this.GetParameter(srcClass);

            return DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_SupplierEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsNameNull())
            {
                setList.Add("Name=@Name");
            }
            if (!srcClass.IsContactPersonNull())
            {
                setList.Add("ContactPerson=@ContactPerson");
            }
            if (!srcClass.IsContactNumberNull())
            {
                setList.Add("ContactNumber=@ContactNumber");
            }
            if (!srcClass.IsAddressNull())
            {
                setList.Add("Address=@Address");
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
            sql.AppendLine("     [TB_Suppliers] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     SupplierID = @SupplierID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
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
            int SupplierID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Suppliers] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     SupplierID = @SupplierID");


            var param = new QueryParamList
            {
                { "@SupplierID", SupplierID }
            };


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
           BaseTB_SupplierEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList
            {
                { "@SupplierID", srcClass.SupplierID.ToNonNullable() },
                { "@Name", srcClass.Name.ToNonNullable() },
                { "@ContactPerson", srcClass.ContactPerson.ToNonNullable() },
                { "@ContactNumber", srcClass.ContactNumber.ToNonNullable() },
                { "@Address", srcClass.Address.ToNonNullable() },
                { "@CreatedAt", srcClass.CreatedAt },
                { "@CreatedBy", srcClass.CreatedBy.ToNonNullable() },
                { "@UpdatedAt", srcClass.UpdatedAt },
                { "@UpdatedBy", srcClass.UpdatedBy.ToNonNullable() }
            };

            return param;
        }
        #endregion
    }
}