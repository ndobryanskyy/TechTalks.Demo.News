using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Abstractions
{
    public interface INewsFactory
    {
        ArticleDraft CreateArticleDraft();
    }
}