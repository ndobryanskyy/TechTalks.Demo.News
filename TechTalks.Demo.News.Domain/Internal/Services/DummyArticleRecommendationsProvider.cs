using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalks.Demo.News.Domain.Abstractions;

namespace TechTalks.Demo.News.Domain.Internal.Services
{
    internal sealed class DummyArticleRecommendationsProvider : IArticleRecommendationsProvider
    {
        private readonly HashSet<int> _articlesViewed = new HashSet<int>();

        private readonly OnArticleRecommendationAvailable _onArticleRecommendationAvailable;
        private readonly ILogger<DummyArticleRecommendationsProvider> _logger;
        private readonly Random _rng;

        public DummyArticleRecommendationsProvider(
            OnArticleRecommendationAvailable onArticleRecommendationAvailable, 
            ILogger<DummyArticleRecommendationsProvider> logger)
        {
            _onArticleRecommendationAvailable = onArticleRecommendationAvailable;
            _logger = logger;
            _rng = new Random();
        }

        public Task TrackViewedArticleAsync(int articleId)
        {
            if (_articlesViewed.Add(articleId))
            {
                var suggestionsCount = _rng.Next(1, _articlesViewed.Count);

                _logger.LogInformation($"Going to send {suggestionsCount} suggestions...");

                for (int i = 0; i < suggestionsCount; i++)
                {
                    var suggestionDelaySeconds = _rng.Next(2, 10);

                    Task.Delay(TimeSpan.FromSeconds(suggestionDelaySeconds))
                        .ContinueWith(async t => {
                            try
                            {
                                await _onArticleRecommendationAvailable(_rng.Next(1000, 100000));
                            }
                            catch (Exception)
                            {
                            }
                        });
                }
            }

            return Task.CompletedTask;
        }
    }
}