using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Dish : BaseTB_DishEntity
    {
        #region Insert

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_DishEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Dishes] ");
            sql.AppendLine(" (MenuID, DishName, Picture, UnitPrice)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@MenuID, @DishName, @Picture, @UnitPrice);");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }

        #endregion Insert

        #region Get Data

        public virtual BaseTB_DishEntity GetData(int DishID)
        {
            var dic = new Dictionary<string, object>();
            var whereStr = new StringBuilder();

            dic["@DishID"] = DishID;

            whereStr.AppendLine(" DishID = @DishID");

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

        public virtual DataTable GetDataTable(
            string selectWhere,
            Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" select d.*, m.MenuName from TB_Dishes d join TB_Menus m on d.MenuID = m.MenuID");

            if (!string.IsNullOrEmpty(selectWhere))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(selectWhere);
            }


            var param = new QueryParamList();
            if (!string.IsNullOrEmpty(selectWhere))
            {
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
        public virtual List<BaseTB_DishEntity> GetDataList()
        {
            var list = new List<BaseTB_DishEntity>();
            Dictionary<string, object> dic = null;
            string where = "";
            var dt = this.GetDataTable(where, dic);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_DishEntity();

                this.SetDataForList(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region Get Data List for Dish Display
        public virtual List<BaseTB_DishEntity> GetDataListforDisplay(int menuID)
        {
            var list = new List<BaseTB_DishEntity>();
          
            var dt = this.GetDataTableforDisplay(menuID);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_DishEntity();

                this.SetData(entity, row);
                list.Add(entity);
            }
            return list;
        }

        public virtual DataTable GetDataTableforDisplay(int menuID)
         
        {
            var sql = new StringBuilder();
            switch (menuID)
            {
                case 1:
                    sql.AppendLine("select * from TB_Dishes where menuID = 1");
                    break;
                case 2:
                    sql.AppendLine("select * from TB_Dishes where menuID !=3");
                    break;
                case 3:
                    sql.AppendLine("select * from TB_Dishes ");
                    break;
            }

            return DataBase.ExecuteAdapter(sql.ToString());
        }

       





        #endregion




        #region "Update Data"

        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_DishEntity srcClass = null)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Dishes] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(" MenuID=@MenuID, DishName=@DishName, Picture=@Picture, UnitPrice=@UnitPrice");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     DishID = @DishID");

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
            sql.AppendLine(" DELETE FROM [TB_Dishes] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("     DishID = @DishID");

            var param = new QueryParamList();
            param.Add("@DishID", id);

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
          BaseTB_DishEntity targetClass,
          DataRow row)
        {
            targetClass.DishID = NullableValueExtension.DBNullToIntegerZero(row["DishID"]);
            targetClass.MenuID = NullableValueExtension.DBNullToIntegerZero(row["MenuID"]);
            targetClass.DishName = row["DishName"].ToString();
            targetClass.Picture = row["Picture"].ToString();
            targetClass.UnitPrice = NullableValueExtension.DBNullToIntegerZero(row["UnitPrice"]);
        }

        public virtual void SetDataForList(
         BaseTB_DishEntity targetClass,
         DataRow row)
        {
            targetClass.DishID = NullableValueExtension.DBNullToIntegerZero(row["DishID"]);
            targetClass.MenuID = NullableValueExtension.DBNullToIntegerZero(row["MenuID"]);
            targetClass.MenuName = row["MenuName"].ToString();
            targetClass.DishName = row["DishName"].ToString();
            targetClass.Picture = row["Picture"].ToString();
            targetClass.UnitPrice = NullableValueExtension.DBNullToIntegerZero(row["UnitPrice"]);
        }

        #endregion "SetData"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_DishEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@DishID", srcClass.DishID.ToNonNullable());
            param.Add("@MenuID", srcClass.MenuID.ToNonNullable());
            param.Add("@DishName", srcClass.DishName);
            param.Add("@Picture", srcClass.Picture);
            param.Add("@UnitPrice", srcClass.UnitPrice);
            return param;
        }

        #endregion "Get Parameter"
    }
}