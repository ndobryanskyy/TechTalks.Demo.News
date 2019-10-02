using System;
using System.ComponentModel.DataAnnotations;

namespace TechTalks.Demo.News.ViewModels
{
    public sealed class CreateArticleViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string[]? Tags { get; set; }

        public DateTime? PublishAt { get; set; }
    }
}