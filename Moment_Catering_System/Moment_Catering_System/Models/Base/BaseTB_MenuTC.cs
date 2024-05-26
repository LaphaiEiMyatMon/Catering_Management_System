using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_MenuTC: BaseTB_MenuTCEntity
    {
        #region "Get Data"
        public virtual BaseTB_MenuTCEntity GetData(
           int TCID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@TCID"] = TCID;

            whereStr.AppendLine("     TCID = @TCID");

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
            sql.AppendLine("     [TB_MenuTCs]");

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
        public virtual List<BaseTB_MenuTCEntity> GetDataList()
        {
            var list = new List<BaseTB_MenuTCEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_MenuTCEntity();

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
            sql.AppendLine(" * FROM [TB_MenuTCs]");

            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "Set Data"
        public virtual void SetData(
            BaseTB_MenuTCEntity targetClass,
            DataRow row)
        {
            targetClass.TCID = NullableValueExtension.DBNullToIntegerZero(row["TCID"]);
            targetClass.MenuID = NullableValueExtension.DBNullToIntegerZero(row["MenuID"]);
            targetClass.TCDetail = row["TCDetail"].ToString();
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
           BaseTB_MenuTCEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsTCIDNull())
            {
                columnList.Add("TCID");
                paramList.Add("@TCID");
            }
            if (!srcClass.IsMenuIDNull())
            {
                columnList.Add("MenuID");
                paramList.Add("@MenuID");
            }
            if (!srcClass.IsTCDetailNull())
            {
                columnList.Add("TCDetail");
                paramList.Add("@TCDetail");
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
            sql.AppendLine(" INSERT INTO [TB_MenuTCs] ");
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
           BaseTB_MenuTCEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsTCIDNull())
            {
                setList.Add("TCID = @TCID");
            }
            if (!srcClass.IsMenuIDNull())
            {
                setList.Add("MenuID = @MenuID");
            }
            if (!srcClass.IsTCDetailNull())
            {
                setList.Add("TCDetail = @TCDetail");
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
            sql.AppendLine("     [TB_MenuTCs] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     TCID = @TCID");

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
           int MenuID)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM [TB_MenuTCs] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     TCID = @TCID");

            var param = new QueryParamList
            {
                { "@TCID", TCID }
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
           BaseTB_MenuTCEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList
            {
                { "@TCID", srcClass.TCID },
                { "@MenuID", srcClass.MenuID },
                { "@TCDetail", srcClass.TCDetail.DBNullToNothing() },
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