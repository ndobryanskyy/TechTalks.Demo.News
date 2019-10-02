using AutoMapper;
using TechTalks.Demo.News.Domain.Model;
using TechTalks.Demo.News.Domain.Model.Drafting;
using TechTalks.Demo.News.ViewModels;

namespace TechTalks.Demo.News
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<CreateArticleViewModel, ArticleDraft>();
        }
    }
}