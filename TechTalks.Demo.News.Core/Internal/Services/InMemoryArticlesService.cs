using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TechTalks.Demo.News.Core.Abstractions;
using TechTalks.Demo.News.Core.Model;
using TechTalks.Demo.News.Core.Model.Drafting;

namespace TechTalks.Demo.News.Core.Internal.Services
{
    internal sealed class InMemoryArticlesService : IArticlesService
    {
        private readonly ConcurrentDictionary<int, Article> _articlesStorage =
            new ConcurrentDictionary<int, Article>();

        public InMemoryArticlesService()
        {
            SeedData();
        }

        public Task<Article?> FindArticleByIdAsync(
            int articleId, 
            CancellationToken cancellationToken)
        {
            _articlesStorage.TryGetValue(articleId, out var article);

            return Task.FromResult(article switch
            {
                { IsDeleted: false } => article,
                _ => null
            });
        }

        public Task<Article> PublishArticleAsync(
            ArticleDraft articleDraft, 
            CancellationToken cancellationToken)
        {
            var article = articleDraft.CreateArticle();

            while (true)
            {
                var nextId = _articlesStorage.Count + 1;
                if (_articlesStorage.TryAdd(nextId, article))
                {
                    article.Id = nextId;
                    break;
                }
            }

            return Task.FromResult(article);
        }

        public Task DeleteArticleAsync(int articleId, CancellationToken cancellationToken)
        {
            if (_articlesStorage.TryGetValue(articleId, out var article))
            {
                article.MarkDeleted();
            }

            return Task.CompletedTask;
        }

        private void SeedData()
        {
            var article1 = CreateNullableFeatureArticle();
            article1.Id = 1;

            _articlesStorage[article1.Id] = article1;

            var article2 = CreateGrpcDotnetArticle();
            article2.Id = 2;

            _articlesStorage[article2.Id] = article2;
        }

        private static Article CreateGrpcDotnetArticle()
        {
            var article = new Article(
                ".NET Core Loves gRPC",
                DateTime.UtcNow.AddDays(-1).Date,
                "Now fully supported since VS 2019 16.3",
                new[] { "Announce", "ASP.NET Core", "gRPC" });

            return article;
        }

        private static Article CreateNullableFeatureArticle()
        {
            var article = new Article(
                "C# 8.0 Safer Nulls With Nullable Reference Types",
                    DateTime.UtcNow.AddDays(-2).Date,
                "Try out new syntax!",
                new []{ "Announce", "Feature", "C# 8.0" });

            return article;
        }
    }
}