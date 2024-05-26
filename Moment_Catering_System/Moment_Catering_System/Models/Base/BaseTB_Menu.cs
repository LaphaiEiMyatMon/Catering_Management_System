using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Menu : BaseTB_MenuEntity
    {
        #region "Get Data"

        public virtual BaseTB_MenuEntity GetData(
           int menuID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@MenuID"] = menuID;

            whereStr.AppendLine("     MenuID = @MenuID");

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
            sql.AppendLine(" SELECT *");
            sql.AppendLine(" FROM ");
            sql.AppendLine("     [TB_Menus]");

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

        public virtual List<BaseTB_MenuEntity> GetDataList()
        {
            var list = new List<BaseTB_MenuEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_MenuEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        #endregion "Get Data List"

        #region "Get Data Table For List"

        public virtual DataTable GetDataTableForList()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT");
            sql.AppendLine(" * FROM [TB_Menus]");

            return DataBase.ExecuteAdapter(sql.ToString());
        }

        #endregion "Get Data Table For List"

        #region "Set Data"

        public virtual void SetData(
            BaseTB_MenuEntity targetClass,
            DataRow row)
        {
            targetClass.MenuID = NullableValueExtension.DBNullToIntegerZero(row["MenuID"]);
            targetClass.MenuName = row["MenuName"].ToString();
            targetClass.Url = row["Url"].ToString();
            if (!DBNull.Value.Equals(row["MinPax"]))
                targetClass.MinPax = Convert.ToInt32(row["MinPax"]);
            else
                targetClass.MinPax = 0;
            if (!DBNull.Value.Equals(row["UnitPrice"]))
                targetClass.UnitPrice = Convert.ToDecimal(row["UnitPrice"]);
            else
                targetClass.UnitPrice = 0;
            if (!DBNull.Value.Equals(row["NoOfCourse"]))
                targetClass.NoOfCourse = Convert.ToInt32(row["NoOfCourse"]);
            else
                targetClass.NoOfCourse = 0;
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
            targetClass.Url = row["Url"].ToString();
        }

        #endregion "Set Data"

        #region "Data Insert"

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_MenuEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsMenuIDNull())
            {
                columnList.Add("MenuID");
                paramList.Add("@MenuID");
            }

            if (!srcClass.IsMenuNameNull())
            {
                columnList.Add("MenuName");
                paramList.Add("@MenuName");
            }
            if (!srcClass.IsMinPaxNull())
            {
                columnList.Add("MinPax");
                paramList.Add("@MinPax");
            }
            if (!srcClass.IsUnitPriceNull())
            {
                columnList.Add("UnitPrice");
                paramList.Add("@UnitPrice");
            }
            if (!srcClass.IsNoOfCourseNull())
            {
                columnList.Add("NoOfCourse");
                paramList.Add("@NoOfCourse");
            }

            if (!srcClass.IsUrlNull())
            {
                columnList.Add("Url");
                paramList.Add("@Url");
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
            sql.AppendLine(" INSERT INTO [TB_Menus] ");
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

        #endregion "Data Insert"

        #region "Data Update"

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_MenuEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsMenuNameNull())
            {
                setList.Add("MenuName = @MenuName");
            }
            if (!srcClass.IsMinPaxNull())
            {
                setList.Add("MinPax = @MinPax");
            }
            if (!srcClass.IsUnitPriceNull())
            {
                setList.Add("UnitPrice = @UnitPrice");
            }
            if (!srcClass.IsNoOfCourseNull())
            {
                setList.Add("NoOfCourse = @NoOfCourse");
            }

            if (!srcClass.IsUrlNull())
            {
                setList.Add("Url = @Url");
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
            sql.AppendLine("     [TB_Menus] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     MenuID = @MenuID");

            var param = this.GetParameter(srcClass, false);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }

        #endregion "Data Update"

        #region "Data Delete"

        public virtual int DataDelete(
           DbConnection con,
           DbTransaction tran,
           int MenuID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM [TB_Menus] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     MenuID = @MenuID");

            var param = new QueryParamList();
            param.Add("@MenuID", MenuID);

            int resultCount = (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception();
            }

            return resultCount;
        }

        #endregion "Data Delete"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_MenuEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@MenuID", srcClass.MenuID);
            param.Add("@MenuName", srcClass.MenuName.ToNonNullable());
            param.Add("@MinPax", srcClass.MinPax.DBNullToIntegerZero());
            param.Add("@UnitPrice", srcClass.UnitPrice.DBNullToDecimalZero());
            param.Add("@NoOfCourse", srcClass.NoOfCourse.DBNullToIntegerZero());
            param.Add("@Url", srcClass.Url.ToNonNullable());
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());
            return param;
        }

        #endregion "Get Parameter"
    }
}