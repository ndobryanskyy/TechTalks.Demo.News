using System;
using FluentValidation;
using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Internal.Validation
{
    internal sealed class ArticleDraftValidator : AbstractValidator<ArticleDraft>
    {
        public ArticleDraftValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.PublishAt)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .When(x => x.PublishAt.HasValue);

            RuleFor(x => x.Tags.Count)
                .LessThanOrEqualTo(5);
        }
    }
}