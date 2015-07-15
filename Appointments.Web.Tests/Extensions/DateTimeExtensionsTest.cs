using NUnit.Framework;
using System;
using AppointmentReminders.Web.Extensions;


namespace Appointments.Web.Tests.Extensions
{
    public class DateTimeExtensionsTest
    {
        [Test]
        public void ToCustomDateString_returns_a_given_date_in_a_custom_format()
        {
            var date = new DateTime(2015, 07, 15, 14, 14, 00);
            var result = date.ToCustomDateString();
            Assert.That(result, Is.EqualTo("07/15/2015 02:14 PM"));
        }
    }
}
