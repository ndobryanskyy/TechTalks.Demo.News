using System.Collections.Generic;
using System.Linq;

namespace TechTalks.Demo.News.Core.Model.Drafting
{
    public sealed class ArticleDraftValidationResult
    {
        public static ArticleDraftValidationResult Success { get; } = new ArticleDraftValidationResult(true, null);

        public static ArticleDraftValidationResult Failure(IEnumerable<ArticleDraftValidationError> errors)
            => new ArticleDraftValidationResult(false, errors);

        private ArticleDraftValidationResult(
            bool isValid,
            IEnumerable<ArticleDraftValidationError>? errors)
        {
            IsValid = isValid;
            Errors = errors?.ToArray() ?? new ArticleDraftValidationError[0];
        }

        public bool IsValid { get; }

        public IReadOnlyCollection<ArticleDraftValidationError> Errors { get; }
    }
}