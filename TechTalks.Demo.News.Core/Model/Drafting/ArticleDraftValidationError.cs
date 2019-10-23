namespace TechTalks.Demo.News.Core.Model.Drafting
{
    public sealed class ArticleDraftValidationError
    {
        public ArticleDraftValidationError(string summary, string details)
        {
            Summary = summary;
            Details = details;
        }

        public string Summary { get; }

        public string Details { get; }
    }
}