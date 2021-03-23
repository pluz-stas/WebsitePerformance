using System;
using System.ComponentModel.DataAnnotations;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Annotations
{
    public class HostNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string uri && Uri.CheckHostName(uri) == UriHostNameType.Unknown)
            {
                return false;
            }
            return true;
        }   
    }
}