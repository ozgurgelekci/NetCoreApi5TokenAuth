using Microsoft.Extensions.DependencyInjection;
using NetCoreApi5TokenAuth.Core.Repositories.Abstract;
using NetCoreApi5TokenAuth.Core.Services.Abstract;
using NetCoreApi5TokenAuth.Core.UnitOfWork.Abstract;
using NetCoreApi5TokenAuth.Data.Repositories;
using NetCoreApi5TokenAuth.Data.UnitOfWorks;
using NetCoreApi5TokenAuth.Service.Services;

namespace NetCoreApi5TokenAuth.Service.DependencyResolvers.MicrosoftIoC
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            #region Generic Repository

            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region GenericService

            service.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            #endregion

            #region Authentication

            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();

            #endregion

            #region Unit of Work

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion
        }
    }
}
