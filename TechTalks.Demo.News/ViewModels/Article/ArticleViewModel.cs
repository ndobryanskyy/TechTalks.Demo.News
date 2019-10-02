using System;

namespace TechTalks.Demo.News.ViewModels
{
    public sealed class ArticleViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedAt { get; set; }

        public string[] Tags { get; set; }
    }
}