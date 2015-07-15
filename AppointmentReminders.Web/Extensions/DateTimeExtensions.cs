using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace AppointmentReminders.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm tt");
        }
    }
}