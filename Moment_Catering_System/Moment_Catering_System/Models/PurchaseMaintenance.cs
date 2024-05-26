using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class PurchaseMaintenance : BaseDA
    {
        public PurchaseMaintenance()
        {
            this.PurchaseEntity = new BaseTB_PurchaseEntity();
            this.Purchase = new BaseTB_Purchase();
            this.SearchEntity = new PurchaseSearchModel();

        }

        public PurchaseSearchModel SearchEntity { get; set; }
        public BaseTB_PurchaseEntity PurchaseEntity { get; set; }
        public List<BaseTB_PurchaseEntity> PurchaseList { get; set; }
        public BaseTB_Purchase Purchase { get; set; }
        public string PDateFormatted { get; set; }
        public Dictionary<string, string> IngredientList { get; set; }

        #region "Get Ingredient List"

        public Dictionary<string, string> GetIngredientList()
        {
            BaseTB_Ingredient ingredient = new BaseTB_Ingredient();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_IngredientEntity> list = ingredient.GetDataList();

            foreach (var row in list)
            {
                result[row.IngredientID.ToString()] = row.IngredientName;
            }
            return result;
        }

        #endregion "Get Ingredient List"

        #region "Get Supplier List"

        public Dictionary<string, string> GetSupplierList()
        {
            BaseTB_Supplier supplier = new BaseTB_Supplier();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_SupplierEntity> list = supplier.GetDataList();

            foreach (var row in list)
            {
                result[row.SupplierID.ToString()] = row.Name;
            }
            return result;
        }

        #endregion "Get Supplier List"

        #region "Add Data"

        public ResultStatus AddData(List<BaseTB_PurchaseEntity> data)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Purchase model = new BaseTB_Purchase();
            BaseTB_PurchaseEntity entity = new BaseTB_PurchaseEntity();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    foreach (var item in data)
                    {
                        entity.SupplierID = item.SupplierID;
                        entity.IngredientID = item.IngredientID;
                        entity.PDate = item.PDate;
                        entity.UnitPrice = item.UnitPrice;
                        entity.Qty = item.Qty;
                        entity.TotalPrice = item.TotalPrice;
                        entity.InvoiceNo = item.InvoiceNo;
                        this.StampCreated(entity);
                        model.DataInsert(con, tran, entity);
                    }
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;
            }
        }

        #endregion "Add Data"

        #region "Get Data List"

        public void GetDataList(PurchaseSearchModel param)
        {
            BaseTB_Purchase model = new BaseTB_Purchase();
            this.PurchaseList = model.GetDataList(param);
            SessionModel.PurchaseList = this.PurchaseList;
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(int id)
        {
            BaseTB_Purchase model = new BaseTB_Purchase();
            this.PurchaseEntity = model.GetData(id);
        }

        #endregion "Get Data"

        #region "Update Data"

        public void UpdateData(BaseTB_PurchaseEntity entityInfo)
        {
            BaseTB_Purchase role = new BaseTB_Purchase();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    entityInfo.TotalPrice = entityInfo.UnitPrice * entityInfo.Qty;
                    this.StampUpdated(entityInfo);
                    role.DataUpdate(con, tran, entityInfo);
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    var ex = exp.Message;
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region "Delete Data"

        public void DeleteData(int id)
        {
            BaseTB_Purchase role = new BaseTB_Purchase();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    role.DataDelete(
                        con, tran, id);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Delete Data"
    }
}