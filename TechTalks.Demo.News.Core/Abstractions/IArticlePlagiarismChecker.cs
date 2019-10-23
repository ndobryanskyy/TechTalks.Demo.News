using System.Collections.Generic;
using System.Threading;
using TechTalks.Demo.News.Core.Model.Plagiarism;

namespace TechTalks.Demo.News.Core.Abstractions
{
    public interface IArticlePlagiarismChecker
    {
        IAsyncEnumerable<PlagiarismCheckOperationProgress> CheckForPlagiarismAsync(
            string articleContent,
            PlagiarismCheckDesiredQuality checkQuality, 
            CancellationToken cancellationToken);
    }
}