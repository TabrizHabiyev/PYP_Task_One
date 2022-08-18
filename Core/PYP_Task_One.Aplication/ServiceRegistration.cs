using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PYP_Task_One.Aplication.AutoMapper;

namespace PYP_Task_One.Aplication;

public static class ServiceRegistration
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));

        services.AddAutoMapper(typeof(AutoMapperProfile));
    }
}
