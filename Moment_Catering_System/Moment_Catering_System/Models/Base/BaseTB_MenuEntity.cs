using Moment_Catering_System.Extension;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_MenuEntity
    {
        #region "private"

        private int? _menuID;

        private string _menuName;

        private int? _minPax;

        private decimal _unitPrice;

        private int? _noOfCourse;

        private string _url;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;
        #endregion

        #region public
        public int MenuID { get { return this._menuID.ToNonNullable(); } set { this._menuID = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MenuName { get { return this._menuName; } set { this._menuName = value; } }
        public int MinPax { get { return this._minPax.ToNonNullable(); } set { this._minPax = value; } }

        public decimal UnitPrice { get { return this._unitPrice; } set { this._unitPrice = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int NoOfCourse { get { return this._noOfCourse.ToNonNullable(); } set { this._noOfCourse = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        public string Url { get => _url; set => _url = value; }
        #endregion

        #region "IsNull"
        public bool IsMenuIDNull() { return this._menuID == null; }

        public bool IsMenuNameNull() { return this._menuName == null; }

        public bool IsUrlNull() { return this._url == null; }

        public bool IsMinPaxNull() { return this._minPax == null; }

        public bool IsUnitPriceNull() { return this._unitPrice == 0; }

        public bool IsNoOfCourseNull() { return this._noOfCourse == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion

        #region "SetNull"

        public void SetMenuIDNull() { this._menuID = null; }

        public void SetBranchNameNull() { this._menuName = null; }

        public void SetMinPaxNull() { this._minPax = null; }

        public void SetUnitPriceNull() { this._unitPrice = 0; }

        public void SetNoOfCourseNull() { this._noOfCourse = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion

        public HttpPostedFileBase ImageFile { get; set; }

    }
}