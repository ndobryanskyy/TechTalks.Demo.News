using TechTalks.Demo.News.Domain.Abstractions;
using TechTalks.Demo.News.Domain.Internal.Validation;
using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Internal.Services
{
    internal sealed class NewsFactory : INewsFactory
    {
        public ArticleDraft CreateArticleDraft() 
            => new ArticleDraft(Validators.ArticleDraftValidator);

        public IArticleRecommendationsProvider CreateArticleRecommendationsProvider(OnArticleRecommendationAvailable onArticleRecommendationAvailable)
            => new DummyArticleRecommendationsProvider(onArticleRecommendationAvailable);
    }
}