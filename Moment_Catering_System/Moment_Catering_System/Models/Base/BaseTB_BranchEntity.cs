using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Moment_Catering_System.Extension;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_BranchEntity
    {
        #region "private"

        private int? _branchNo;

        private string _branchName;

        private string _address;

        private string _callCenterPhoneNo;

        private string _email;

        private DateTime? _createdAt;

        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;
        #endregion

       
        public int BranchNo { get { return this._branchNo.ToNonNullable(); } set { this._branchNo = value; } }
     
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BranchName { get { return this._branchName; } set { this._branchName = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get { return this._address; } set { this._address = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CallCenterPhoneNo { get { return this._callCenterPhoneNo; } set { this._callCenterPhoneNo = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get { return this._email; } set { this._email = value; } }

        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

       
        #region "IsNull"
        public bool IsBranchNoNull() { return this._branchNo == null; }

        public bool IsBranchNameNull() { return this._branchName == null; }

        public bool IsAddressNull() { return this._address == null; }
    
        public bool IsCallCenterPhoneNoNull() { return this._callCenterPhoneNo == null; }
        
        public bool IsEmailNull() { return this._email == null; }
        
        public bool IsCreatedAtNull() { return this._createdAt == null; }
        
        public bool IsCreatedByNull() { return this._createdBy == null; }
                
        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }
       #endregion

        #region "SetNull"
        
        public void SetBranchNoNull() { this._branchNo = null; }

        public void SetBranchNameNull() { this._branchName = null; }

        public void SetAddressNull() { this._address = null; }

        public void SetCallCenterPhoneNoNull() { this._callCenterPhoneNo = null; }

        public void SetEmailNull() { this._email = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }
}