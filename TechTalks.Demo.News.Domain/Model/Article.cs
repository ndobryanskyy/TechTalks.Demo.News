using System;
using System.Collections.Generic;
using System.Linq;

namespace TechTalks.Demo.News.Domain.Model
{
    public sealed class Article
    {
        internal Article(
            string title,
            DateTime publishedAt,
            string content,
            IEnumerable<string> tags)
        {
            Title = title;
            PublishedAt = publishedAt;
            Content = content;
            Tags = tags.ToArray();
        }

        public int Id { get; internal set; }

        public bool IsDeleted { get; private set; }

        public string Title { get; }

        public DateTime PublishedAt { get; }

        public string Content { get; }

        public IReadOnlyCollection<string> Tags { get; }

        public void MarkDeleted()
        {
            IsDeleted = true;
        }
    }
}