using Microsoft.Extensions.DependencyInjection;
using TechTalks.Demo.News.Core.Abstractions;
using TechTalks.Demo.News.Core.Internal.Services;

namespace TechTalks.Demo.News.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddSingleton<INewsFactory, NewsFactory>();
            services.AddSingleton<IArticlesService, InMemoryArticlesService>();
            services.AddSingleton<IArticlePlagiarismChecker, RandomArticlePlagiarismChecker>();

            return services;
        }
    }
}