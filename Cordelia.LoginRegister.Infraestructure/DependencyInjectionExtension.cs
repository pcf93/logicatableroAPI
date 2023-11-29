using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Application.Services.Implementation;
using Cordelia.LoginRegister.Domain.Model;

using Cordelia.LoginRegister.Infraestructure.Data;
using Cordelia.LoginRegister.Infraestructure.Repository;
using Enfonsalaflota.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cordelia.LoginRegister.Infraestructure;

public static class DependencyInjectionExtension
{

    //el método devuelve una configuración del contenedor de dependencias. es un método de extensión que solo aplica para IServiceCollection
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        //configuramos el contexto
        services.AddDbContext<ApplicationContext>((sp, options) =>
        {

            options.UseNpgsql(configuration.GetConnectionString("Connection"), opt =>
            {
                opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

        }, ServiceLifetime.Scoped);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        services.AddScoped<IGenericRepository<Message>, GenericRepository<Message>>();
        services.AddScoped<IGenericRepository<MatchMessage>, GenericRepository<MatchMessage>>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;

    }

}
