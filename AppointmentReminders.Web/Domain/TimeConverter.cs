using System;

namespace AppointmentReminders.Web.Domain
{
    public interface ITimeConverter
    {
        DateTime ToLocalTime(DateTime time, string timezone);
    }

    public class TimeConverter : ITimeConverter
    {
        public DateTime ToLocalTime(DateTime time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time,
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }
}