using Moment_Catering_System.Common;
using Moment_Catering_System.Extension;
using System.Data;
using System.Text;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_Count : BaseTB_CountEntity
    {
        #region "Get Data List"

        #region "Get Data"

        public virtual BaseTB_CountEntity GetData()
        {
            var dt = this.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetData(this, row);
            }

            return this;
        }

        #endregion "Get Data"

        #endregion "Get Data List"

        #region "Get Data Table For List"

        public virtual DataTable GetDataTable()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("(SELECT COUNT(CustomerID) FROM tb_Customers) AS CustomerCount,");
            sql.AppendLine("(SELECT COUNT(StaffID) FROM TB_Staff) AS StaffCount,");
            sql.AppendLine("(SELECT COUNT(OrderID) FROM TB_Orders) AS OrderCount,");
            sql.AppendLine("(SELECT COUNT(PurchaseID) FROM TB_Purchase) AS PurchaseCount,");
            sql.AppendLine("(SELECT SUM(TotalAmount) FROM TB_Orders) AS TotalIncome,");
            sql.AppendLine("(SELECT SUM(TotalPrice) FROM TB_Purchase) AS TotalExpense;");
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        #endregion "Get Data Table For List"

        public virtual void SetData(
            BaseTB_CountEntity targetClass,
            DataRow row)
        {
            targetClass.CustomerCount = NullableValueExtension.DBNullToIntegerZero(row["CustomerCount"]);
            targetClass.StaffCount = NullableValueExtension.DBNullToIntegerZero(row["StaffCount"]);
            targetClass.OrderCount = NullableValueExtension.DBNullToIntegerZero(row["OrderCount"]);
            targetClass.PurchaseCount = NullableValueExtension.DBNullToIntegerZero(row["PurchaseCount"]);
            targetClass.TotalIncome = NullableValueExtension.DBNullToIntegerZero(row["TotalIncome"]);
            targetClass.TotalExpense = NullableValueExtension.DBNullToIntegerZero(row["TotalExpense"]);
        }
    }
}