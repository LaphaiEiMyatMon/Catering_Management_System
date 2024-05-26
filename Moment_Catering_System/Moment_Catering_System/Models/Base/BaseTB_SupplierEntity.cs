using Moment_Catering_System.Extension;
using System;
using System.ComponentModel.DataAnnotations;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_SupplierEntity
    {
        #region private
        private int? _supplierID;
        private string _name;
        private string _contactPerson;
        private string _contactNumber;
        private string _address;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        #endregion

        #region public
        public int? SupplierID { get { return this._supplierID.ToNonNullable(); } set { this._supplierID = value; } }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get => _name; set => _name = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactPerson { get => _contactPerson; set => _contactPerson = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactNumber { get => _contactNumber; set => _contactNumber = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get => _address; set => _address = value; }
        public DateTime? CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }
        public string UpdatedBy { get => _updatedBy; set => _updatedBy = value; }
        #endregion
        #region IsNull
        public bool IsSupplierIDNull() { return this._supplierID == null; }

        public bool IsNameNull() { return this._name == null; }

        public bool IsContactPersonNull() { return this._contactPerson == null; }

        public bool IsContactNumberNull() { return this._contactNumber == null; }
        public bool IsAddressNull() { return this._address == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion
        #region "SetNull"

        public void SetSupplierIDNull() { this._supplierID = null; }

        public void SetNameNull() { this._name = null; }

        public void SetContactPersonNull() { this._contactPerson = null; }

        public void SetContactNumberNull() { this._contactNumber = null; }

        public void SetAddressNull() { this._address = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }
}