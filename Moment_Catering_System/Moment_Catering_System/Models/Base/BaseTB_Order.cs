using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Order : BaseTB_OrderEntity
    {
        #region "Insert Data"

        public virtual int DataInsert(
           DbConnection con,
           DbTransaction tran,
           BaseTB_OrderEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [TB_Orders] ");
            sql.AppendLine(" (MenuID, CustomerID, DeliveryDate, DeliveryTime, DeliveryAddress, Note, SelectedPax, Discount, TotalAmount, Status, RejectReason, CancelReason, StaffID, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (@MenuID, @CustomerID, @DeliveryDate, @DeliveryTime, @DeliveryAddress, @Note, @SelectedPax, @Discount, @TotalAmount, @Status, @RejectReason, @CancelReason, @StaffID, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy) ");
            sql.AppendLine(" SELECT CAST(SCOPE_IDENTITY() AS int)");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteScalar(con, sql.ToString(), param, tran);
        }

        #endregion "Insert Data"

        #region "Get Parameter"

        private QueryParamList GetParameter(
           BaseTB_OrderEntity srcClass,
           bool createMode = true)
        {
            var param = new QueryParamList();

            param.Add("@OrderID", srcClass.OrderID);
            param.Add("@MenuID", srcClass.MenuID);
            param.Add("@CustomerID", srcClass.CustomerID);
            param.Add("@DeliveryDate", srcClass.DeliveryDate);
            param.Add("@DeliveryTime", srcClass.DeliveryTime);
            param.Add("@DeliveryAddress", srcClass.DeliveryAddress);
            param.Add("@Note", srcClass.Note);
            param.Add("@SelectedPax", srcClass.DishQuantity);
            param.Add("@Discount", srcClass.Discount);
            param.Add("@TotalAmount", srcClass.TotalAmount);
            param.Add("@Status", srcClass.Status);
            param.Add("@RejectReason", srcClass.RejectReason);
            param.Add("@CancelReason", srcClass.CancelReason);
            param.Add("@StaffID", srcClass.StaffID);
            param.Add("@CreatedAt", srcClass.CreatedAt);
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@UpdatedAt", srcClass.UpdatedAt);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());

            return param;
        }

        #endregion "Get Parameter"

        #region Get All

        public virtual List<BaseTB_OrderEntity> GetDataList(OrderManagement model)
        {
            var list = new List<BaseTB_OrderEntity>();
            var dt = this.GetDataTableForList(model);
            
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_OrderEntity();

                this.SetDataDetail(entity, row);
                list.Add(entity);
            }
            return list;
        }

        public virtual DataTable GetDataTableForList(OrderManagement model)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT  o.*, p.PaymentID, m.MenuName, m.UnitPrice, pm.PaymentMethod, c.FirstName, c.LastName, c.Email, c.PhoneNo, p.Status as PaymentStatus");
            sql.AppendLine(" FROM TB_Orders o ");
            sql.AppendLine(" join TB_Menus m on o.MenuID = m.MenuID");
            sql.AppendLine(" join TB_Payments p on o.OrderID = p.OrderID");
            sql.AppendLine(" join TB_PaymentMethods pm on p.PaymentMethodID =  pm.PaymentMethodID");
            sql.AppendLine(" join TB_Customers c on  o.CustomerID = c.CustomerID");
            sql.AppendLine(" WHERE 1=1");
            var parameters = new QueryParamList();

            if (model.OrderEntity.OrderID!=0)
            {
                sql.AppendLine("AND o.OrderID = @OrderID");
                parameters.Add("@OrderID", model.OrderEntity.OrderID);
            }
            else
            {
                if (model.OrderEntity.CustomerID != 0)
                {
                    sql.AppendLine("AND o.CustomerID = @CustomerID");
                    parameters.Add("@CustomerID", model.OrderEntity.CustomerID);
                }
                if (!string.IsNullOrEmpty(model.OrderEntity.DeliveryTime))
                {
                    sql.AppendLine("AND o.DeliveryTime = @DeliveryTime");
                    parameters.Add("@DeliveryTime", model.OrderEntity.DeliveryTime);
                }

                if (model.OrderEntity.DeliveryDate != DateTime.MinValue)
                {
                    sql.AppendLine("AND o.DeliveryDate = @DeliveryDate");
                    parameters.Add("@DeliveryDate", model.OrderEntity.DeliveryDate);
                }

                if (model.OrderEntity.MenuID!=0)
                {
                    sql.AppendLine("AND o.MenuID = @MenuID");
                    parameters.Add("@MenuID", model.OrderEntity.MenuID);
                }

                if (model.OrderEntity.Status != null)
                {
                    sql.AppendLine("AND o.Status = @Status");
                    parameters.Add("@Status", model.OrderEntity.Status);
                }

                sql.AppendLine("order by o.CreatedAt desc");
            }

            return DataBase.ExecuteAdapter(sql.ToString(),parameters);
        }

        #endregion Get All

        #region Get Detail

        public virtual BaseTB_OrderEntity GetData(int orderID)
        {
            var dt = this.GetDataTable(orderID);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetDataDetail(this, row);
            }
            return this;
        }

        public virtual DataTable GetDataTable(int orderID)
        {
            var sql = new StringBuilder();
            var parameters = new QueryParamList();
            sql.AppendLine(" SELECT  o.*, p.PaymentID, m.MenuName, m.UnitPrice, pm.PaymentMethod, c.FirstName, c.LastName, c.Email, c.PhoneNo, p.Status as PaymentStatus");
            sql.AppendLine(" FROM TB_Orders o ");
            sql.AppendLine(" join TB_Menus m on o.MenuID = m.MenuID");
            sql.AppendLine(" join TB_Payments p on o.OrderID = p.OrderID");
            sql.AppendLine(" join TB_PaymentMethods pm on p.PaymentMethodID =  pm.PaymentMethodID");
            sql.AppendLine(" join TB_Customers c on  o.CustomerID = c.CustomerID");
            sql.AppendLine("WHERE o.OrderID = @OrderID");
            parameters.Add("@OrderID", orderID);
            sql.AppendLine("order by o.CreatedAt desc");
            return DataBase.ExecuteAdapter(sql.ToString(), parameters);
        }

        public virtual void SetDataDetail(
         BaseTB_OrderEntity targetClass,
         DataRow row)
        {
            targetClass.OrderID = NullableValueExtension.DBNullToIntegerZero(row["OrderID"]);
            targetClass.MenuID = NullableValueExtension.DBNullToIntegerZero(row["MenuID"]);
            targetClass.CustomerID = NullableValueExtension.DBNullToIntegerZero(row["CustomerID"]);
            if (!DBNull.Value.Equals(row["DeliveryDate"]))
                targetClass.DeliveryDate = ((DateTime)row["DeliveryDate"]);
            targetClass.Date = targetClass.DeliveryDate.ToShortDateString();

            targetClass.DeliveryTime = row["DeliveryTime"].ToString();
            targetClass.DeliveryAddress = row["DeliveryAddress"].ToString();
            targetClass.Note = row["Note"].ToString();
            targetClass.DishQuantity = NullableValueExtension.DBNullToIntegerZero(row["SelectedPax"]);
            targetClass.Discount = NullableValueExtension.DBNullToIntegerZero(row["Discount"]);
            targetClass.TotalAmount = NullableValueExtension.DBNullToDecimalZero(row["TotalAmount"]);
            targetClass.Status = row["Status"].ToString();
            targetClass.RejectReason = row["RejectReason"].ToString();
            targetClass.CancelReason = row["CancelReason"].ToString();
            targetClass.StaffID = row["StaffID"].ToString();
            if (!DBNull.Value.Equals(row["CreatedAt"]))
                targetClass.CreatedAt = (DateTime)row["CreatedAt"];
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            if (!DBNull.Value.Equals(row["UpdatedAt"]))
                targetClass.UpdatedAt = (DateTime)row["UpdatedAt"];
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();

            targetClass.CustomerEntity.FirstName = row["FirstName"].ToString();
            targetClass.CustomerEntity.LastName = row["LastName"].ToString();
            targetClass.CustomerEntity.Email = row["Email"].ToString();
            targetClass.CustomerEntity.PhoneNo = row["PhoneNo"].ToString();
       

            targetClass.MenuEntity.MenuName = row["MenuName"].ToString();
            targetClass.MenuEntity.UnitPrice = NullableValueExtension.DBNullToDecimalZero(row["UnitPrice"]);

            targetClass.PaymentEntity.PaymentID = NullableValueExtension.DBNullToIntegerZero(row["PaymentID"]);
            targetClass.PaymentEntity.Status = row["PaymentStatus"].ToString();

            targetClass.PaymentMethodEntity.PaymentMethod = row["PaymentMethod"].ToString();
        }

        #endregion Get Detail

        #region "Update Data"
        public virtual int DataUpdate(
           DbConnection con,
           DbTransaction tran,
           BaseTB_OrderEntity srcClass = null)
        {
            
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine("     [TB_Orders] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(" MenuID =@MenuID , CustomerID =@CustomerID , DeliveryDate =@DeliveryDate , DeliveryTime =@DeliveryTime , DeliveryAddress =@DeliveryAddress , Note =@Note , SelectedPax =@SelectedPax , Discount =@Discount , TotalAmount =@TotalAmount , Status =@Status , RejectReason =@RejectReason , CancelReason =@CancelReason , StaffID =@StaffID, CreatedAt =@CreatedAt, CreatedBy =@CreatedBy, UpdatedAt =@UpdatedAt, UpdatedBy =@UpdatedBy");
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
        #endregion

        #region Customer Order
        public virtual List<BaseTB_OrderEntity> CustomerOrder(OrderManagement model)
        {
            var list = new List<BaseTB_OrderEntity>();
            var dt = this.GetDataTableForList(model);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_OrderEntity();

                this.SetDataDetail(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion
    }
}