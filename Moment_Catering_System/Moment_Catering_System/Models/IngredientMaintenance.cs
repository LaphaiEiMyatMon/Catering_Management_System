using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Moment_Catering_System.Models
{
    public class IngredientMaintenance : BaseDA
    {
        public IngredientMaintenance()
        {
            this.IngredientEntity = new BaseTB_IngredientEntity();
            this.IngredientList = new List<BaseTB_IngredientEntity>();
        }

        #region Var
        public BaseTB_IngredientEntity IngredientEntity { get; set; }

        public List<BaseTB_IngredientEntity> IngredientList { get; set; }
        #endregion

        #region List
        public void GetDataList()
        {
            var ingredient = new BaseTB_Ingredient();
            this.IngredientList = ingredient.GetDataList();
        }
        #endregion
        #region "Get Data"

        public void GetData(int ingredientID)
        {
            var ingredient = new BaseTB_Ingredient();
            this.IngredientEntity = ingredient.GetData(ingredientID);
        }

        #endregion "Get Data"

        #region Create
        public ResultStatus AddData(BaseTB_IngredientEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Ingredient ingredient = new BaseTB_Ingredient();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    ingredient.DataInsert(con, tran, entityInfo);

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
        #endregion
        #region "Update Data"

        public void UpdateData(BaseTB_IngredientEntity entityInfo)
        {
            BaseTB_Ingredient ingredient = new BaseTB_Ingredient();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(entityInfo);
                    ingredient.DataUpdate(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region Delete
        public void DeleteData(int ingredientID)
        {
            var ingredient = new BaseTB_Ingredient();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    ingredient.DataDelete(con, tran, ingredientID);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }
        #endregion
    }
}