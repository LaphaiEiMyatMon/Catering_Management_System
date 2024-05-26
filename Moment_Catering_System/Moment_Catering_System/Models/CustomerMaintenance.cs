using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Moment_Catering_System.Models
{
    public class CustomerMaintenance : BaseDA
    {
        public CustomerMaintenance()
        {
            this.CustomerEntity = new BaseTB_CustomerEntity();
            this.CustomerList = new List<BaseTB_CustomerEntity>();
        }

        public BaseTB_CustomerEntity CustomerEntity { get; set; }

        public List<BaseTB_CustomerEntity> CustomerList { get; set; }

        #region "Get Data List"

        public void GetDataList(CustomerMaintenance model)
        {
            BaseTB_Customer cus = new BaseTB_Customer();
            this.CustomerList = cus.GetDataList(model);
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(string customerID)
        {
            BaseTB_Customer model = new BaseTB_Customer();
            this.CustomerEntity=model.GetData(customerID);
        }

        #endregion "Get Data"


        public ResultStatus CheckDuplicate(CustomerMaintenance model)
        {
            BaseTB_Customer cus = new BaseTB_Customer();
            var entity = cus.Login(model.CustomerEntity.Email);
            var result = new ResultStatus();

            if(entity.Email == model.CustomerEntity.Email)
            {
                result.Status = false;
                result.Message = "This email is already in use!!!";
                return result;
            }
            else
            {
                result.Status = true;
            }
            return result;
        }

        public void Encrypt(string password)
        {
            var _tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            var _tmpHash = new MD5CryptoServiceProvider().ComputeHash(_tmpSource);
            this.CustomerEntity.Password = ByteArrayToString(_tmpHash);
        }

        #region "Add Data"

        public void AddData(BaseTB_CustomerEntity entityInfo)
        {     
            this.Encrypt(entityInfo.Password);
            BaseTB_Customer model = new BaseTB_Customer();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    /*
                     * Ref Link(for Hash function)
                     * https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values
                    */
                    entityInfo.RoleID = 5;
                    if(LoginInfo.UserID == null)
                    {
                        entityInfo.CreatedBy = "system";
                    }
                    entityInfo.IsActive = true;
                    model.DataInsert(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    var msg = exp.Message;
                    tran.Rollback();
                }
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(BaseTB_CustomerEntity entityInfo)
        {
            BaseTB_Customer model = new BaseTB_Customer();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampUpdated(entityInfo);
                    model.DataUpdate(con, tran, entityInfo);
                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region "Delete Data"

        public void DeleteData(int roleID)
        {
            BaseTB_Customer model = new BaseTB_Customer();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    model.DataDelete(
                        con, tran, roleID);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Delete Data"

        #region Login
        public ResultStatus GetUser(CustomerMaintenance model)
        {
            var result = new ResultStatus();
            var customer = new BaseTB_Customer();
            this.Encrypt(model.CustomerEntity.Password);

            var entity = customer.Login(model.CustomerEntity.Email);

            if (!model.CustomerEntity.Email.Equals(entity.Email))
            {
                result.Status = false;
                result.Message = "Invalid Email!";
                return result;
            }
            if (!model.CustomerEntity.Password.Equals(entity.Password))
            {
                result.Status = false;
                result.Message = "Invalid Password!";
                return result;
            }

            if (model.CustomerEntity.Email.Equals(entity.Email) && model.CustomerEntity.Password.Equals(entity.Password))
            {
        
                LoginInfo.UserID = entity.CustomerID.ToString();
                LoginInfo.UserName = entity.FirstName + " " + entity.LastName;
                LoginInfo.DisplayName = entity.FirstName;
                LoginInfo.Email = entity.Email;
                LoginInfo.RoleID = entity.RoleID.ToString();
                LoginInfo.ProfilePicture = string.IsNullOrEmpty(entity.Picture) ? entity.Picture : entity.Picture;
            }
            return result;
        }
        #endregion

        public static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}