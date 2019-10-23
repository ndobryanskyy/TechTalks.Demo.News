using System.Threading.Tasks;

namespace TechTalks.Demo.News.Core.Abstractions
{
    public delegate Task OnArticleRecommendationAvailable(int suggestedArticleId);

    public interface IArticleRecommendationsProvider
    {
        Task TrackViewedArticleAsync(int articleId);
    }
}