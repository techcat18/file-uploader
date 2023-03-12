using EmailFunction.Interfaces;
using EmailFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(EmailFunction.Startup))]
namespace EmailFunction;

public class Startup: FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();
    }
}