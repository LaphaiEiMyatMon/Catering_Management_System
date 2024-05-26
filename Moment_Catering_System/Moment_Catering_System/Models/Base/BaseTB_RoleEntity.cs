using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Moment_Catering_System.Extension;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_RoleEntity
    {
        #region "private"
     
        private int? _roleID;
      
        private string _roleName;
   
        private DateTime? _createdAt;
    
        private string _createdBy;

        private DateTime? _updatedAt;

        private string _updatedBy;

        #endregion


        #region "public"
        public int? RoleID { get { return this._roleID; } set { this._roleID = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RoleName { get { return this._roleName; } set { this._roleName = value; } }
   
        public DateTime CreatedAt { get { return this._createdAt.ToNonNullable(); } set { this._createdAt = value; } }
     
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }

        public DateTime UpdatedAt { get { return this._updatedAt.ToNonNullable(); } set { this._updatedAt = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }

        #endregion


        #region "IsNull"

        public bool IsRoleIDNull() { return this._roleID == null; }

        public bool IsRoleNameNull() { return this._roleName == null; }
    
        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }
    
        public bool IsUpdatedAtNull() { return this._updatedAt == null; }
     
        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion

        #region "SetNull"
       
        public void SetRoleIDNull() { this._roleID = null; }

        public void SetRoleNameNull() { this._roleName = null; }

        public void SetCreatedAtNull() { this._createdAt = null; }

        public void SetCreatedByNull() { this._createdBy = null; }

        public void SetUpdatedAtNull() { this._updatedAt = null; }

        public void SetUpdatedByNull() { this._updatedBy = null; }
        #endregion
    }
}