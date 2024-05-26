using Moment_Catering_System.Extension;
using System;
using System.ComponentModel.DataAnnotations;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_MenuTCEntity
    {
        #region "private"

        private int? _TCID;

        private int? _menuID;

        private string _TCDetail;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;
        #endregion
        #region public
        public int TCID { get { return this._TCID.ToNonNullable(); } set { this._TCID = value; } }
        public int MenuID { get { return this._menuID.ToNonNullable(); } set { this._menuID = value; } }
        public string TCDetail { get { return this._TCDetail; } set { this._TCDetail = value; } }
        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        #endregion
        #region "IsNull"
        public bool IsTCIDNull() { return this._TCID == null; }

        public bool IsMenuIDNull() { return this._menuID == null; }

        public bool IsTCDetailNull() { return this._TCDetail == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion
        #region "SetNull"

        public void SetTCIDNull() { this._TCID = null; }

        public void SetMenuIDNull() { this._menuID = null; }

        public void SetTCDetailNull() { this._TCDetail = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }
}