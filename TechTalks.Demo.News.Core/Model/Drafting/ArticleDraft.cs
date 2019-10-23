using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace TechTalks.Demo.News.Core.Model.Drafting
{
    public sealed class ArticleDraft
    {
        private readonly AbstractValidator<ArticleDraft> _validator;

        internal ArticleDraft(AbstractValidator<ArticleDraft> validator)
        {
            _validator = validator;
        }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime? PublishAt { get; set; }

        public HashSet<string> Tags { get; } = new HashSet<string>();

        public ArticleDraftValidationResult Validate()
        {
            var results = _validator.Validate(this);

            if (results.IsValid)
            {
                return ArticleDraftValidationResult.Success;
            }
            else
            {
                var mappedErrors = results.Errors.Select(x => new ArticleDraftValidationError(
                    $"Invalid {x.PropertyName}", x.ErrorMessage));

                return ArticleDraftValidationResult.Failure(mappedErrors);
            }
        }

        public Article CreateArticle()
        {
            var validationResult = Validate();

            if (!validationResult.IsValid)
            {
                throw new InvalidOperationException("Draft is not valid!");
            }

            var publishDate = PublishAt ?? DateTime.UtcNow;

            return new Article(Title!, publishDate, Content!, Tags);
        }
    }
}