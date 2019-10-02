using Microsoft.Extensions.DependencyInjection;
using TechTalks.Demo.News.Domain.Abstractions;
using TechTalks.Demo.News.Domain.Internal.Services;

namespace TechTalks.Demo.News.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddSingleton<INewsFactory, NewsFactory>();
            services.AddSingleton<IArticlesService, InMemoryArticlesService>();

            return services;
        }
    }
}