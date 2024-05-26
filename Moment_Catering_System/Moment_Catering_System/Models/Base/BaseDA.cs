using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Moment_Catering_System.Common;

namespace Moment_Catering_System.Models
{
    public abstract class BaseDA
    {

        public string ScreenTitle { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Src { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsExecuteInitialSearch { get; set; }


        // public SearchResultObject GridData { get; set; }


        public bool IsError { get; set; }


        public bool IsUpdateSucceeded { get; set; }


        public virtual void InitialValueSetting()
        {
            // no-op
        }


        public virtual void Validate(ref ModelStateDictionary modelState)
        {
            // no-op
        }


        public virtual void StampCreated(object targetClass)
        {
            CommonUtility.StampCreated(
                targetClass,
                DateTime.Now,
                LoginInfo.UserID);
        }


        public virtual void StampUpdated(object targetClass)
        {
            CommonUtility.StampUpdated(
                targetClass,
                DateTime.Now,
                LoginInfo.UserID);
        }
    }
}