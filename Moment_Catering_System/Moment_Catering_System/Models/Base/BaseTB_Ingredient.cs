using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Ingredient : BaseTB_IngredientEntity
    {
        #region Get Data
        public virtual BaseTB_IngredientEntity GetData(int IngredientID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@IngredientID"] = IngredientID;

            whereStr.AppendLine(" IngredientID = @IngredientID");

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
            sql.AppendLine(" [TB_Ingredients] ");
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
        public virtual List<BaseTB_IngredientEntity> GetDataList()
        {
            var list = new List<BaseTB_IngredientEntity>();
            var dt = this.GetDataTableForList();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_IngredientEntity();

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
            sql.AppendLine(" * FROM [TB_Ingredients]");


            return DataBase.ExecuteAdapter(sql.ToString());
        }
        #endregion

        #region "SetData"
        public virtual void SetData(
          BaseTB_IngredientEntity targetClass,
          DataRow row)
        {
            targetClass.IngredientID = NullableValueExtension.DBNullToIntegerZero(row["IngredientID"]);
            targetClass.IngredientName = row["IngredientName"].ToString();
            targetClass.StockQty = NullableValueExtension.DBNullToDecimalZero(row["StockQty"]);
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
           BaseTB_IngredientEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }
            #region Query Parameter
            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsIngredientNameNull())
            {
                columnList.Add("IngredientName");
                paramList.Add("@IngredientName");
            }
            if (!srcClass.IsStockQtyNull())
            {
                columnList.Add("StockQty");
                paramList.Add("@StockQty");
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
            sql.AppendLine(" INSERT INTO [TB_Ingredients] ");
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
           BaseTB_IngredientEntity srcClass = null)
        {
            #region Query Parameter
            if (srcClass == null)
            {
                srcClass = this;
            }

            var setList = new List<string>();

            if (!srcClass.IsIngredientNameNull())
            {
                setList.Add("IngredientName = @IngredientName");
            }
            if (!srcClass.IsStockQtyNull())
            {
                setList.Add("StockQty = @StockQty");
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
            #endregion
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Ingredients] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     IngredientID = @IngredientID");

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
            int IngredientID
           )
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [TB_Ingredients] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     IngredientID = @IngredientID");


            var param = new QueryParamList
            {
                { "@IngredientID", IngredientID }
            };


            int resultCount = DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
            if (resultCount != 1)
            {
                throw new Exception("Cannot Delete the data");
            }
            return resultCount;
        }
        #endregion

        #region "Get Parameter"
        private QueryParamList GetParameter(
           BaseTB_IngredientEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@IngredientID", srcClass.IngredientID.ToNonNullable());
            param.Add("@IngredientName", srcClass.IngredientName.ToNonNullable());
            param.Add("@StockQty", srcClass.StockQty.ToNonNullable());
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }
        #endregion
    }
}