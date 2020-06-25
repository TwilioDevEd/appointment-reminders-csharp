<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>

## Apointment Reminders in ASP.NET MVC

![](https://github.com/TwilioDevEd/appointment-reminders-csharp/workflows/NetFx/badge.svg)
[![Build status](https://ci.appveyor.com/api/projects/status/github/TwilioDevEd/appointment-reminders-csharp?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/appointment-reminders-csharp)

> We are currently in the process of updating this sample template. If you are encountering any issues with the sample, please open an issue at [github.com/twilio-labs/code-exchange/issues](https://github.com/twilio-labs/code-exchange/issues) and we'll try to help you.

## About

This example demonstrates how to use Twilio to create automatic appointment reminders for your business users.

[Read the full tutorial here](https://www.twilio.com/docs/sms/tutorials/appointment-reminders-csharp-mvc)!

Implementations in other languages:

| PHP | Java | Python | Ruby | Node |
| :--- | :--- | :----- | :-- | :--- |
| [Done](https://github.com/TwilioDevEd/appointment-reminders-laravel)  | [Done](https://github.com/TwilioDevEd/appointment-reminders-java)  | [Done](https://github.com/TwilioDevEd/appointment-reminders-django)  | [Done](https://github.com/TwilioDevEd/appointment-reminders-rails) | [Done](https://github.com/TwilioDevEd/appointment-reminders-node)  |

<!--
### How it works

**TODO: Describe how it works**
-->

## Set up

### Requirements

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)

### Twilio Account Settings

This application should give you a ready-made starting point for writing your
own application. Before we begin, we need to collect
all the config values we need to run the application:

| Config&nbsp;Value | Description                                                                                                                                                  |
| :---------------- | :----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Account&nbsp;Sid  | Your primary Twilio account identifier - find this [in the Console](https://www.twilio.com/console).                                                         |
| Auth&nbsp;Token   | Used to authenticate - [just like the above, you'll find this here](https://www.twilio.com/console).                                                         |
| Phone&nbsp;number | A Twilio phone number in [E.164 format](https://en.wikipedia.org/wiki/E.164) - you can [get one here](https://www.twilio.com/console/phone-numbers/incoming) |

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
git clone git@github.com:TwilioDevEd/appointment-reminders-csharp.git
cd appointment-reminders-csharp
```

1. Set your configuration variables

```bash
copy AppointmentReminders.Web/Web.config.sample AppointmentReminders.Web/Web.config
```

See [Twilio Account Settings](#twilio-account-settings) to locate the necessary environment variables.

1. You might also need to run through the initial set of migrations for Entity Framework. In the NuGet Package Manager console, enter:

```bash
Update-Database
```

1. Build the solution

1. Run the application

1. Navigate to [http://localhost:1547](http://localhost:1547)

That's it!

## Resources

- The CodeExchange repository can be found [here](https://github.com/twilio-labs/code-exchange/).

## Contributing

This template is open source and welcomes contributions. All contributions are subject to our [Code of Conduct](https://github.com/twilio-labs/.github/blob/master/CODE_OF_CONDUCT.md).

[Visit the project on GitHub](https://github.com/twilio-labs/sample-template-dotnet)

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
