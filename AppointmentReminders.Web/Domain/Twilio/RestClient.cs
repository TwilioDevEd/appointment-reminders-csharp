using System.Web.Configuration;
using Twilio;

namespace AppointmentReminders.Web.Domain.Twilio
{
    public class RestClient
    {
        private readonly TwilioRestClient _client;

        private readonly string _accountSid = WebConfigurationManager.AppSettings["AccountSid"];
        private readonly string _authToken = WebConfigurationManager.AppSettings["AuthToken"];
        private readonly string _twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

        public RestClient()
        {
            _client = new TwilioRestClient(_accountSid, _authToken);
        }

        public void SendSmsMessage(string phoneNumber, string message)
        {
            _client.SendSmsMessage(_twilioNumber, phoneNumber, message);
        }
    }
}