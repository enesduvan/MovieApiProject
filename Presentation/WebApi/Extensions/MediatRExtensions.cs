using Application.Features.MediatorDesignPattern.Handlers.CastHandler;
using Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

namespace WebApi.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCastQueryHandler).Assembly));
            return services;
        }
    }
}
