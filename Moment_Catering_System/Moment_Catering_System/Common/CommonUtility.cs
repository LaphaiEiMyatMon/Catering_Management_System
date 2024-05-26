namespace Moment_Catering_System.Common
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Web;

    public static class CommonUtility
    {
        public static string AddTimestamp(string url)
        {
            var path = HttpContext.Current.Server.MapPath(url);
            var timestamp = File.GetLastWriteTime(path).ToString("yyyyMMddHHmmss");
            return url + "?" + timestamp;
        }

        public static void StampCreated(
           object targetClass,
           DateTime createdAt,
           string createdBy
          )
        {
            PropertyInfo propCreatedAt = targetClass.GetType().GetProperty("CreatedAt");
            PropertyInfo propCreatedBy = targetClass.GetType().GetProperty("CreatedBy");

            propCreatedAt.SetValue(targetClass, createdAt);
            propCreatedBy.SetValue(targetClass, createdBy);
        }

        public static void StampUpdated(
            object targetClass,
            DateTime updatedAt,
            string updatedBy
           )
        {
            PropertyInfo propUpdatedAt = targetClass.GetType().GetProperty("UpdatedAt");
            PropertyInfo propUpdatedBy = targetClass.GetType().GetProperty("UpdatedBy");

            propUpdatedAt.SetValue(targetClass, updatedAt);
            propUpdatedBy.SetValue(targetClass, updatedBy);
        }
    }
}