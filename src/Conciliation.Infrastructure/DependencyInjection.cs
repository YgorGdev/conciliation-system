using Conciliation.Application.Abstractions;
using Conciliation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Conciliation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(connectionString));

        // Repository da conciliação (Application -> Abstraction)
        services.AddScoped<IConciliationRepository, ConciliationRepository>();

        return services;
    }
}
