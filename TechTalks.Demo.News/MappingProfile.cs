using AutoMapper;
using TechTalks.Demo.News.Core.Model;
using TechTalks.Demo.News.Core.Model.Drafting;
using TechTalks.Demo.News.ViewModels;

namespace TechTalks.Demo.News
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<CreateArticleViewModel, ArticleDraft>();

            //CreateMap<Core.Model.Article, Lohika.TechTalks.News.Article>()
            //    .ForMember(x => x.Tags, options => options.MapFrom(x => x.Tags));
        }
    }
}