using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalks.Demo.News.Domain.Abstractions;

namespace TechTalks.Demo.News.Domain.Internal.Services
{
    internal sealed class DummyArticleRecommendationsProvider : IArticleRecommendationsProvider
    {
        private readonly HashSet<int> _articlesViewed = new HashSet<int>();

        private readonly OnArticleRecommendationAvailable _onArticleRecommendationAvailable;

        public DummyArticleRecommendationsProvider(OnArticleRecommendationAvailable onArticleRecommendationAvailable)
        {
            _onArticleRecommendationAvailable = onArticleRecommendationAvailable;
        }

        public async Task TrackViewedArticleAsync(int articleId)
        {
            if (_articlesViewed.Add(articleId))
            {
                await Task.Delay(200);

                if (_articlesViewed.Count % 3 == 0)
                {
                    var recommendation = _articlesViewed.Max() + 1;
                    _articlesViewed.Add(recommendation);

                    await _onArticleRecommendationAvailable(recommendation);
                }
            }
        }
    }
}