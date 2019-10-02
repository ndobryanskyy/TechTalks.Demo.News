using System.Threading;
using System.Threading.Tasks;
using TechTalks.Demo.News.Domain.Model;
using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Abstractions
{
    public interface IArticlesService
    {
        Task<Article?> FindArticleByIdAsync(int articleId, CancellationToken cancellationToken);

        Task<Article> PublishArticleAsync(ArticleDraft articleDraft, CancellationToken cancellationToken);

        Task DeleteArticleAsync(int articleId, CancellationToken cancellationToken);
    }
}