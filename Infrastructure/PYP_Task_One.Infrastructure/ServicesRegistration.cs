using Microsoft.Extensions.DependencyInjection;
using PYP_Task_One.Aplication.Services;
using PYP_Task_One.Infrastructure.Services;

namespace PYP_Task_One.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
      services.AddScoped<IFileService, FileService>();
      services.AddScoped<IEmailSenderService, EmailSenderService>();
    }
}