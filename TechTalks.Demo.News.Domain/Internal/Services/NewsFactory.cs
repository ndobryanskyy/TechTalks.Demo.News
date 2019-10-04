using Microsoft.Extensions.Logging;
using TechTalks.Demo.News.Domain.Abstractions;
using TechTalks.Demo.News.Domain.Internal.Validation;
using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Internal.Services
{
    internal sealed class NewsFactory : INewsFactory
    {
        private readonly ILoggerFactory _loggerFactory;

        public NewsFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ArticleDraft CreateArticleDraft() 
            => new ArticleDraft(Validators.ArticleDraftValidator);

        public IArticleRecommendationsProvider CreateArticleRecommendationsProvider(OnArticleRecommendationAvailable onArticleRecommendationAvailable)
            => new DummyArticleRecommendationsProvider(onArticleRecommendationAvailable, _loggerFactory.CreateLogger<DummyArticleRecommendationsProvider>());
    }
}