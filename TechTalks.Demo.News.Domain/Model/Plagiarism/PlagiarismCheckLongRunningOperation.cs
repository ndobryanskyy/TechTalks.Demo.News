namespace TechTalks.Demo.News.Domain.Model.Plagiarism
{
    public sealed class PlagiarismCheckOperationProgress
    {
        public static PlagiarismCheckOperationProgress InProgress(double percentsCompleted)
            => new PlagiarismCheckOperationProgress(percentsCompleted, null);

        public static PlagiarismCheckOperationProgress Completed(double result)
            => new PlagiarismCheckOperationProgress(1.0, result);

        private PlagiarismCheckOperationProgress(double percents, double? result)
        {
            PercentsCompleted = percents;
            PlagiarismRatioResult = result;
        }

        public double PercentsCompleted { get; }

        public double? PlagiarismRatioResult { get; }
    }
}