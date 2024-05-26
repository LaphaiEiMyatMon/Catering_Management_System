using System;
using System.Web;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_CustomerEntity
    {
        private int? _customerID;
        private string _firstName;
        private string _lastName;
        private string _picture;
        private string _gender;
        private string _nrcNo;
        private string _email;
        private string _address;
        private string _phoneNo;
        private int _roleID;
        private string _password;
        private bool _isActive;
        private bool _isBlackListed;
        private string _blackListedRemarks;
        private int _loginCount;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;

        public int? CustomerID { get => _customerID; set => _customerID = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Picture { get => _picture; set => _picture = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string NrcNo { get => _nrcNo; set => _nrcNo = value; }
        public string Email { get => _email; set => _email = value; }
        public string Address { get => _address; set => _address = value; }
        public string PhoneNo { get => _phoneNo; set => _phoneNo = value; }
        public int RoleID { get => _roleID; set => _roleID = value; }
        public string Password { get => _password; set => _password = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public bool IsBlackListed { get => _isBlackListed; set => _isBlackListed = value; }
        public string BlackListedRemarks { get => _blackListedRemarks; set => _blackListedRemarks = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
        public string UpdatedBy { get => _updatedBy; set => _updatedBy = value; }
        public int LoginCount { get => _loginCount; set => _loginCount = value; }
        public HttpPostedFileBase FileBase { get; set; }

        #region "IsNull"

        public bool IsCustomerIDNull()
        {
            return this._customerID == null;
        }

        public bool IsFirstNameNull()
        {
            return this._firstName == null;
        }

        public bool IsLastNameNull()
        {
            return this._lastName == null;
        }

        public bool IsPictureNull()
        {
            return this._picture == null;
        }

        public bool IsGenderNull()
        {
            return this._gender == null;
        }

        public bool IsNrcNoNull()
        {
            return this._nrcNo == null;
        }

        public bool IsEmailNull()
        {
            return this._email == null;
        }

        public bool IsAddressNull()
        {
            return this._address == null;
        }

        public bool IsPhoneNoNull()
        {
            return this._phoneNo == null;
        }

        public bool IsRoleIDNull()
        {
            return this._roleID == 0;
        }

        public bool IsPasswordNull()
        {
            return this._password == null;
        }

        public bool IsIsActiveNull()
        {
            return this._isActive == false;
        }

        public bool IsIsBlackListedNull()
        {
            return this._isBlackListed == false;
        }

        public bool IsBlackListedRemarksNull()
        {
            return this._blackListedRemarks == null;
        }

        public bool IsLoginCountNull()
        {
            return this._loginCount == 0;
        }

        public bool IsCreatedAtNull()
        {
            return this._createdAt == null;
        }

        public bool IsCreatedByNull()
        {
            return this._createdBy == null;
        }

        public bool IsUpdatedAtNull()
        {
            return this._updatedAt == null;
        }

        public bool IsUpdatedByNull()
        {
            return this._updatedBy == null;
        }

        #endregion "IsNull"

        #region "SetNull"

        public void SetCustomerIDNull()
        {
            this._customerID = null;
        }

        public void SetFirstNameNull()
        {
            this._firstName = null;
        }

        public void SetLastNameNull()
        {
            this._lastName = null;
        }

        public void SetPictureNull()
        {
            this._picture = null;
        }

        public void SetGenderNull()
        {
            this._gender = null;
        }

        public void SetNRCNoNull()
        {
            this._nrcNo = null;
        }

        public void SetEmailNull()
        {
            this._email = null;
        }

        public void SetAddressNull()
        {
            this._address = null;
        }

        public void SetPhoneNoNull()
        {
            this._phoneNo = null;
        }

        public void SetRoleIDNull()
        {
            this._roleID = 0;
        }

        public void SetPasswordNull()
        {
            this._password = null;
        }

        public void SetIsActiveNull()
        {
            this._isActive = false;
        }

        public void SetIsBlackListedNull()
        {
            this._isBlackListed = false;
        }

        public void SetBlackListedRemarksNull()
        {
            this._blackListedRemarks = null;
        }

        public void SetLoginCountNull()
        {
            this._loginCount = 0;
        }

        public void SetCreatedAtNull()
        {
            this._createdAt = null;
        }

        public void SetCreatedByNull()
        {
            this._createdBy = null;
        }

        public void SetUpdatedAtNull()
        {
            this._updatedAt = null;
        }

        public void SetUpdatedByNull()
        {
            this._updatedBy = null;
        }

        #endregion "SetNull"
    }
}