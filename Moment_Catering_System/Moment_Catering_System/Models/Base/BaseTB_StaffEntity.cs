using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Moment_Catering_System.Extension;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_StaffEntity
    {
        #region "Private"
        private string _staffID;

        private int? _roleID;

        private int? _branchNo;

        private string _staffName;

        private string _password;   

        private string _profilePicture;

        private string _active;

        private Boolean _isActive;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;
        #endregion

        #region "Public"

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string StaffID { get { return this._staffID; } set { this._staffID = value; } }

        public int? RoleID { get { return this._roleID; } set { this._roleID = value; } }

        public int? BranchNo { get { return this._branchNo; } set { this._branchNo = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string StaffName { get { return this._staffName; } set { this._staffName = value; } }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Password { get { return this._password; } set { this._password = value; } }

        public string Active { get { return this._active; } set { this._active = value; } }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProfilePicture { get { return this._profilePicture; } set { this._profilePicture = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Boolean IsActive { get { return this._isActive; } set { this._isActive = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        public int RowKey { get; set; }

        public HttpPostedFileBase FileBase { get; set; }

        public string BranchName { get; set; }

        public string RoleName { get; set; }
        #endregion

        #region "Is Null"
        public bool IsStaffIDNull() { return this._staffID == null; }
        public bool IsRoleIDNull() { return this._roleID == null; }
        public bool IsBranchNoNull() { return this._branchNo == null; }
        public bool IsStaffNameNull() { return this._staffName == null; }
        public bool IsPasswordNull() { return this._password == null; }
      
        public bool IsProfilePictureNull() { return this._profilePicture == null; }
        public bool IsIsActiveNull() { return this._isActive == false; }
        public bool IsCreatedAtNull() { return this._createdAt == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsUpdatedAtNull() { return this._updatedAt == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        #endregion

        #region "Set Null"
        public void SetStaffIDNull() { this._staffID = null; }
        public void SetRoleIDNull() { this._createdAt = null; }
        public void SetBranchNoNull() { this._createdAt = null; }
        public void SetStaffNameNull() { this._staffName = null; }
        public void SetPasswordNull() { this._password = null; }
     
        public void SetProfilePictureNull() { this._profilePicture = null; }
        public void SetActiveNull() { this._isActive = false; }
        public void SetCreatedAtNull() { this._createdAt = null; }
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetUpdatedAtNull() { this._updatedAt = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion

    }
}