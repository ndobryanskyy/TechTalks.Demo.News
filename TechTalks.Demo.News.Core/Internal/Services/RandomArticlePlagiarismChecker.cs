using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechTalks.Demo.News.Core.Abstractions;
using TechTalks.Demo.News.Core.Model.Plagiarism;

namespace TechTalks.Demo.News.Core.Internal.Services
{
    internal sealed class RandomArticlePlagiarismChecker : IArticlePlagiarismChecker
    {
        private static readonly TimeSpan LowQualityCheckTime = TimeSpan.FromSeconds(2);
        private static readonly TimeSpan StandardQualityCheckTime = LowQualityCheckTime * 2;
        private static readonly TimeSpan HighQualityCheckTime = StandardQualityCheckTime * 1.5;
        private static readonly TimeSpan HighestQualityCheckTime = HighQualityCheckTime * 2;

        private readonly Random _rng;

        public RandomArticlePlagiarismChecker()
        {
            _rng = new Random();
        }

        public async IAsyncEnumerable<PlagiarismCheckOperationProgress> CheckForPlagiarismAsync(
            string articleContent, 
            PlagiarismCheckDesiredQuality checkQuality,
            CancellationToken cancellationToken)
        {
            var analysisTime = checkQuality switch
            {
                PlagiarismCheckDesiredQuality.Low => LowQualityCheckTime,
                PlagiarismCheckDesiredQuality.Standard => StandardQualityCheckTime,
                PlagiarismCheckDesiredQuality.High => HighQualityCheckTime,
                PlagiarismCheckDesiredQuality.Highest => HighestQualityCheckTime,
                _ => StandardQualityCheckTime
            };

            const int fractions = 10;
            var fractionTime = analysisTime / 10;

            for (int i = 0; i < fractions; i++)
            {
                await Task.Delay(fractionTime, cancellationToken);
                yield return PlagiarismCheckOperationProgress.InProgress((double)i / fractions);
            }

            yield return PlagiarismCheckOperationProgress.Completed(_rng.NextDouble());
        }
    }
}