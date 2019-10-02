using System.Collections.Generic;
using System.Threading;
using TechTalks.Demo.News.Domain.Model.Plagiarism;

namespace TechTalks.Demo.News.Domain.Abstractions
{
    public interface IArticlePlagiarismChecker
    {
        IAsyncEnumerable<PlagiarismCheckOperationProgress> CheckForPlagiarismAsync(
            string articleContent,
            PlagiarismCheckDesiredQuality checkQuality, 
            CancellationToken cancellationToken);
    }
}