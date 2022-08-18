using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PYP_Task_One.Aplication;

public static class ServiceRegistration
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
    }
}
