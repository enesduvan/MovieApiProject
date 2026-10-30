using Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace WebApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {


        public static IServiceCollection AddApplicationServer(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();

            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<CreateSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();
            services.AddScoped<RemoveSeriesCommandHandler>();

            services.AddScoped<CreateUserRegisterCommandHandler>();
            return services;
        }
    }
}
