using System;
using System.Globalization;

namespace AppointmentReminders.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm tt", new CultureInfo("en-US"));
        }
    }
}