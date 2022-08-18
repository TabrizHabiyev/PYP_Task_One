using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Persistence.Contexts;
using PYP_Task_One.Persistence.Repositories.File;

namespace PYP_Task_One.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        #region Connection String
        services.AddDbContext<PYP_Task_OneDBContext>(options => options.UseSqlServer(Configuration.ConnectionString, b => b.MigrationsAssembly(typeof(PYP_Task_OneDBContext).Assembly.FullName)));
        #endregion

        services.AddScoped<IExcelDataReadRepository, ExcelDataReadRepository>();
        services.AddScoped<IExcelDataWriteRepository, ExcelDataWriteRepository>();

    }
}
