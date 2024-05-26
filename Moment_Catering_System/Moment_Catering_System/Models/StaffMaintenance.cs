using Moment_Catering_System.Common;
using Moment_Catering_System.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;

namespace Moment_Catering_System.Models
{
    public class StaffMaintenance : BaseDA
    {
        public StaffMaintenance()
        {
            this.StaffEntity = new BaseTB_StaffEntity();
            this.StaffList = new List<BaseTB_StaffEntity>();
            this.BranchList = this.GetBranchList();
            this.RoleList = this.GetRoleList();
        }

        public BaseTB_StaffEntity StaffEntity { get; set; }

        public List<BaseTB_StaffEntity> StaffList { get; set; }

        public Dictionary<string, string> BranchList { get; set; }

        public Dictionary<string, string> RoleList { get; set; }

        #region "Get Staff For Login"

        public ResultStatus GetUser(StaffMaintenance model)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Staff staff = new BaseTB_Staff();
            var entity = staff.GetData(model.StaffEntity.StaffID);

            if (!model.StaffEntity.StaffID.Equals(entity.StaffID))
            {
                result.Status = false;
                result.Message = "Invalid ID!!!";
                return result;
            }
            if (!model.StaffEntity.Password.Equals(entity.Password))
            {
                result.Status = false;
                result.Message = "Invalid Password!!!";
                return result;
            }

            if (model.StaffEntity.StaffID.Equals(entity.StaffID) && model.StaffEntity.Password.Equals(entity.Password))
            {
                LoginInfo.UserID = model.StaffEntity.StaffID.ToString();
                LoginInfo.UserName = string.IsNullOrEmpty(entity.StaffName) ? entity.StaffName : entity.StaffName;
                LoginInfo.RoleID = entity.RoleID.ToString();
                LoginInfo.ProfilePicture = string.IsNullOrEmpty(entity.ProfilePicture) ? entity.ProfilePicture : entity.ProfilePicture;
            }
            return result;
        }

        #endregion "Get Staff For Login"

        #region "Get Data List"

        public void GetDataList(StaffMaintenance model)
        {
            BaseTB_Staff staff = new BaseTB_Staff();
            this.StaffList = staff.GetDataList(model);
        }

        #endregion "Get Data List"

        #region "Get Data"

        public void GetData(string staffID)
        {
            BaseTB_Staff staff = new BaseTB_Staff();
            this.StaffEntity = staff.GetData(staffID);
            if (this.StaffEntity.IsActive == true)
            {
                this.StaffEntity.Active = "Yes";
            }
            else
            {
                this.StaffEntity.Active = "No";
            }
        }

        #endregion "Get Data"

        #region "Add Data"

        public ResultStatus AddData(BaseTB_StaffEntity entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Staff staff = new BaseTB_Staff();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    staff.DataInsert(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;
            }
        }

        #endregion "Add Data"

        #region "Update Data"

        public void UpdateData(BaseTB_StaffEntity entityInfo)
        {
            BaseTB_Staff staff = new BaseTB_Staff();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.StampCreated(entityInfo);
                    staff.DataUpdate(con, tran, entityInfo);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Update Data"

        #region "Delete Data"

        public void DeleteData(int staffID)
        {
            BaseTB_Staff staff = new BaseTB_Staff();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    staff.DataDelete(
                        con, tran, staffID);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        #endregion "Delete Data"

        #region "Get Branch List"

        public Dictionary<string, string> GetBranchList()
        {
            BaseTB_Branch branch = new BaseTB_Branch();
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<BaseTB_BranchEntity> list = branch.GetDataList();

            foreach (var row in list)
            {
                result[row.BranchNo.ToString()] = row.BranchName;
            }

            return result;
        }

        #endregion "Get Branch List"

        #region "Get Role List"

        public Dictionary<string, string> GetRoleList()
        {
            BaseTB_Role role = new BaseTB_Role();
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<BaseTB_RoleEntity> list = role.GetDataList();

            foreach (var row in list)
            {
                result[row.RoleID.ToString()] = row.RoleName;
            }

            return result;
        }

        #endregion "Get Role List"

        #region "Convert Base 64 string"

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "no problem")]
        private string GetResizePhotoData(string base64string)
        {
            const int Width = 320;
            const int Height = 320;

            // load image from string
            string resizeBase64 = string.Empty;
            byte[] imageBytes = Convert.FromBase64String(base64string);
            using (MemoryStream srcMs = new MemoryStream(imageBytes, 0, imageBytes.Length))
            using (MemoryStream dstMs = new MemoryStream())
            {
                // load original image
                srcMs.Write(imageBytes, 0, imageBytes.Length);
                using (Bitmap srcBmp = new Bitmap(srcMs))
                {
                    // get resize width and height
                    float scale = Math.Min((float)Width / (float)srcBmp.Width, (float)Height / (float)srcBmp.Height);
                    int resizeWidth = (int)(srcBmp.Width * scale);
                    int resizeHeigh = (int)(srcBmp.Height * scale);

                    // draw resize image
                    Bitmap dstBmp = new Bitmap(resizeWidth, resizeHeigh);
                    Graphics g = Graphics.FromImage(dstBmp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                    g.DrawImage(srcBmp, 0, 0, resizeWidth, resizeHeigh);

                    // convert to base64 string
                    dstBmp.Save(dstMs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    resizeBase64 = Convert.ToBase64String(dstMs.GetBuffer());
                }
            }

            return resizeBase64;
        }

        #endregion "Convert Base 64 string"
    }

    public enum Gender
    {
        Male,
        Female,
        LGBT
    }
}