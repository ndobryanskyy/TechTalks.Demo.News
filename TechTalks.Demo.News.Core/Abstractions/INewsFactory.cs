using TechTalks.Demo.News.Core.Model.Drafting;

namespace TechTalks.Demo.News.Core.Abstractions
{
    public interface INewsFactory
    {
        ArticleDraft CreateArticleDraft();

        IArticleRecommendationsProvider CreateArticleRecommendationsProvider(OnArticleRecommendationAvailable onArticleRecommendationAvailable);
    }
}