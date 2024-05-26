using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Moment_Catering_System.Extension;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_PaymentMethodEntity
    {
        #region "private"

        private int _paymentMethodID;

        private string _paymentMethod;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;

        #endregion

        #region "Public"

        public int PaymentMethodID { get { return this._paymentMethodID; } set { this._paymentMethodID = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PaymentMethod { get { return this._paymentMethod; } set { this._paymentMethod = value; } }


        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #endregion

        #region "IsNull"

        public bool IsPaymentMethodIDNull() { return this._paymentMethodID == 0; }

        public bool IsPaymentMethodNull() { return this._paymentMethod == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "SetNull"

        public void SetPaymentMethodIDNull() { this._paymentMethodID= 0; }

        public void SetPaymentMethodNull() { this._paymentMethod = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }

        #endregion
    }
}