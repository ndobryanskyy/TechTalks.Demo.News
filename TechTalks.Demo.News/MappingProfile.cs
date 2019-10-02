using System;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TechTalks.Demo.News.Domain.Model;
using TechTalks.Demo.News.Domain.Model.Drafting;
using TechTalks.Demo.News.ViewModels;
using ArticleProto = Lohika.TechTalks.News.Article;

namespace TechTalks.Demo.News
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<CreateArticleViewModel, ArticleDraft>();
            CreateMap<Article, ArticleProto>()
                .ForMember(x => x.PublishedAt, opt => opt.ConvertUsing(new DateTimeToTimestampConverter()))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags));
        }

        private class DateTimeToTimestampConverter : IValueConverter<DateTime, Timestamp>
        {
            public Timestamp Convert(DateTime sourceMember, ResolutionContext context) 
                => Timestamp.FromDateTime(sourceMember.ToUniversalTime());
        }
    }
}