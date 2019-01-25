<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

[![Build status](https://ci.appveyor.com/api/projects/status/github/TwilioDevEd/appointment-reminders-csharp?svg=true)](https://ci.appveyor.com/api/projects/status/github/TwilioDevEd/appointment-reminders-csharp)

## Apointment Reminders in ASP.NET MVC

This example demonstrates how to use Twilio to create automatic appointment reminders for your business users.

[Read the full tutorial here](https://www.twilio.com/docs/sms/tutorials/appointment-reminders-csharp-mvc)!

## Running Locally

To run this project locally you'll need to move/rename `AppointmentReminders.Web/Web.config.sample` to `AppointmentReminders.Web/Web.config`.

You'll need to change these values for the ones you need.

```xml
<appSettings>
  ...
  <add key="TwilioNumber" value="TWILIO_NUMBER"/>
  <add key="AccountSid" value="ACCOUNT_SID"/>
  <add key="AuthToken" value="AUTH_TOKEN"/>
</appSettings>
```

You might also need to run through the initial set of migrations for Entity Framework. In the NuGet Package Manager console, enter:

```bash
Update-Database
```

## Licence

MIT
