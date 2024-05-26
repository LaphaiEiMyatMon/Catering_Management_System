using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_ExtraDish : BaseTB_ExtraDishEntity
    {
        #region Insert

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_ExtraDishEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_ExtraDish] ");
            sql.AppendLine(" (OrderID, DishID, Qty)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@OrderID, @DishID, @Qty);");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        #endregion Insert

        #region "Update Data"

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_ExtraDishEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_ExtraDish] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(" OrderID=@OrderID, DishID=@DishID, Qty=@Qty");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     OrderID = @OrderID");

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
            sql.AppendLine(" DELETE FROM [TB_ExtraDish] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     OrderID = @OrderID");

            var param = new QueryParamList();
            param.Add("@OrderID", id);

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
          BaseTB_ExtraDishEntity targetClass,
          DataRow row)
        {
            targetClass.OrderID = NullableValueExtension.DBNullToIntegerZero(row["OrderID"]);
            targetClass.DishID = NullableValueExtension.DBNullToIntegerZero(row["DishID"]);
            targetClass.Qty = NullableValueExtension.DBNullToIntegerZero(row["Qty"]);
            targetClass.DishName = row["DishName"].ToString();
        }

        #endregion "SetData"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_ExtraDishEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@OrderID", srcClass.OrderID);
            param.Add("@DishID", srcClass.DishID);
            param.Add("@Qty", srcClass.Qty);
         
            return param;
        }

        #endregion "Get Parameter"


        #region Get Data table

        public virtual DataTable GetDataTable(int orderID)
        {
            var sql = new StringBuilder();
            var parameters = new QueryParamList();
            sql.AppendLine(" select ed.*, d.DishName from tb_extradish ed join TB_Dishes d on ed.DishID = d.DishID");
            sql.AppendLine("WHERE ed.OrderID = @OrderID");
            parameters.Add("@OrderID", orderID);

            return DataBase.ExecuteAdapter(sql.ToString(), parameters);
        }

        #endregion Get Data table

        #region Get Data List
        public virtual List<BaseTB_ExtraDishEntity> GetDataList(int orderID)
        {
            var list = new List<BaseTB_ExtraDishEntity>();   
            var dt = this.GetDataTable(orderID);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_ExtraDishEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion
    }
}