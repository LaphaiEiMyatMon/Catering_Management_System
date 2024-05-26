using Moment_Catering_System.Extension;
using System;
using System.ComponentModel.DataAnnotations;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_IngredientEntity
    {
        #region private
        private int? _ingredientID;
        private string _ingredientName;
        private decimal? _stockQty;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        public int? IngredientID { get { return this._ingredientID.ToNonNullable(); } set { this._ingredientID = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IngredientName { get { return this._ingredientName; } set { _ingredientName = value; } }
        public decimal? StockQty { get { return this._stockQty; } set { _stockQty = value; } }
        public DateTime? CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #region "IsNull"
        public bool IsIngredientIDNull() { return this._ingredientID == null; }

        public bool IsIngredientNameNull() { return this._ingredientName == null; }

        public bool IsStockQtyNull() { return this._stockQty == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion

        #region "SetNull"

        public void SetIngredientIDNull() { this._ingredientID = null; }

        public void SetIngredientNameNull() { this._ingredientName = null; }

        public void SetStockQtyNull() { this._stockQty = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }
}