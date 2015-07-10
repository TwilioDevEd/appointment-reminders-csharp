using System;

namespace AppointmentReminders.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time,
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }
}