using FluentValidation;
using TechTalks.Demo.News.Core.Model.Drafting;

namespace TechTalks.Demo.News.Core.Internal.Validation
{
    internal static class Validators
    {
        public static AbstractValidator<ArticleDraft> ArticleDraftValidator { get; } =
            new ArticleDraftValidator();
    }
}