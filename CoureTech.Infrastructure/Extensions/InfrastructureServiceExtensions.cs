using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoureTech.Application.Interfaces;
using CoureTech.Application.Services;
using CoureTech.Domain.Interfaces;
using CoureTech.Infrastructure.Data;
using CoureTech.Infrastructure.Repositories;

namespace CoureTech.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string databaseName = "CoureTechDb")
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(databaseName));

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddSingleton<IScoreCalculatorService, ScoreCalculatorService>();
        services.AddScoped<IPhoneLookupService, PhoneLookupService>();

        return services;
    }
}
