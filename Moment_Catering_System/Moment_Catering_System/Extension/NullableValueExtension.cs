using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moment_Catering_System.Common;

namespace Moment_Catering_System.Extension
{
    public static class NullableValueExtension
    {
        public static object NothingToDBNull(this object param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }
            else
            {
                return param;
            }
        }

        
        public static object DBNullToNothing(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return null;
            }
            else
            {
                return param;
            }
        }

        
        public static T DBNullToNothing<T>(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)param;
            }
        }

        
        public static decimal DBNullToDecimalZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0.0m;
            }
            else
            {
                return Convert.ToDecimal(param);
            }
        }

        
        public static int DBNullToIntegerZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(param);
            }
        }

       
        public static long DBNullToLongZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(param);
            }
        }

       
        public static int ToNonNullable(this int? param)
        {
            if (param == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(param);
            }
        }

        
        public static string ToNonNullable(this string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return string.Empty;
            }

            return param;
        }

     
        public static DateTime ToNonNullable(this DateTime? param)
        {
            DateTime defaultDate = SystemDate.DefaultDate;
            if (param == null)
            {
                return defaultDate;
            }
            else
            {
                if (param < defaultDate)
                {
                    return defaultDate;
                }
                else
                {
                    return Convert.ToDateTime(param);
                }
            }
        }

        
        public static DateTime ToForceDateTime(this string param)
        {
            DateTime ret = SystemDate.DefaultDate;
            DateTime.TryParse(param, out ret);
            return ret;
        }

       
        public static int ToForceInteger(this string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);
            return ret;
        }

       
        public static long ToForceLong(this string param)
        {
            long ret = 0L;
            long.TryParse(param, out ret);
            return ret;
        }

       
        public static decimal ToForceDecimal(this string param)
        {
            decimal ret = 0M;
            decimal.TryParse(param, out ret);
            return ret;
        }

        internal static DateTime? ToNonNullable(object v)
        {
            throw new NotImplementedException();
        }
    }
}