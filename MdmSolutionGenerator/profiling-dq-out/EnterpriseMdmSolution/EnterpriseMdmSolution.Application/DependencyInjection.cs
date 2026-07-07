using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Services;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Services;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Services;

namespace EnterpriseMdmSolution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, typeof(DependencyInjection).Assembly);
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<ICustomerRunService, CustomerRunService>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerProfiler>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerDataQualityRuleExecutor>();
        services.AddScoped<IMaterialRunService, MaterialRunService>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialProfiler>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialDataQualityRuleExecutor>();
        services.AddScoped<IVendorRunService, VendorRunService>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorProfiler>();
        services.AddScoped<EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorDataQualityRuleExecutor>();
        return services;
    }
}