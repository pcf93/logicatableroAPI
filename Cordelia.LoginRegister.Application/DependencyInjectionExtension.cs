using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Application.Services.Implementation;
using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Application.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cordelia.LoginRegister.Application;

public static class DependencyInjectionExtension
{

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IFriendRequestService, FriendRequestService>();

        return services;

    }

}
