using System.Web;

namespace Moment_Catering_System.Models
{
    public class LoginInfo
    {
        public static string UserID
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.UserID];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.UserID] = value;
            }
        }

        public static string UserName
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.UserName];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.UserName] = value;
            }
        }

        public static string DisplayName
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.DisplayName];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.DisplayName] = value;
            }
        }

        public static string Email
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.Email];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.Email] = value;
            }
        }

        public static string RoleID
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.RoleID];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.RoleID] = value;
            }
        }

        public static string ProfilePicture
        {
            get
            {
                return (string)HttpContext.Current.Session[KeyName.ProfilePicture];
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.ProfilePicture] = value;
            }
        }

        public static int LoginErrorCount
        {
            get
            {
                if (HttpContext.Current.Session[KeyName.LoginErrorCount] != null)
                {
                    return (int)HttpContext.Current.Session[KeyName.LoginErrorCount];
                }
                else
                {
                    // Return a default value when the session variable is null
                    return 0; // Or any other default value you prefer
                }
            }

            set
            {
                HttpContext.Current.Session[LoginInfo.KeyName.LoginErrorCount] = value;
            }
        }


        public static void KillSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        public class KeyName
        {
            public const string LoginInfo = "LoginInfo";

            public const string UserID = "UserId";

            public const string UserName = "UserName";

            public const string RoleID = "RoleID";

            public const string ProfilePicture = "ProfilePicture";

            public const string Email = "Email";

            public const string LoginErrorCount = "LoginErrorCount";

            public const string DisplayName = "DisplayName";
        }
    }
}