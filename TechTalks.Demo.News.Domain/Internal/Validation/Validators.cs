using FluentValidation;
using TechTalks.Demo.News.Domain.Model.Drafting;

namespace TechTalks.Demo.News.Domain.Internal.Validation
{
    internal static class Validators
    {
        public static AbstractValidator<ArticleDraft> ArticleDraftValidator { get; } =
            new ArticleDraftValidator();
    }
}