using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime? time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time.Value,
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }
}