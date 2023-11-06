using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uanion.Application.Contracts.Persistence;
using Uanion.Persistence.Repositories;

namespace Uanion.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UanionDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("UanionConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IProfileRepository, ProfileRepository>();

        return services;
    }
}
