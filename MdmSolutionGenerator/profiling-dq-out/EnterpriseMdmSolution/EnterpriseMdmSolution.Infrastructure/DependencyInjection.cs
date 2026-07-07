using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.Interfaces;
using EnterpriseMdmSolution.Infrastructure.Persistence;
using EnterpriseMdmSolution.Infrastructure.Repositories;

namespace EnterpriseMdmSolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAnalysisDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}