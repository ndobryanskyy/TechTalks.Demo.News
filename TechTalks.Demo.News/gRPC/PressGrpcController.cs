using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Lohika.TechTalks.News;
using Microsoft.Extensions.Logging;
using TechTalks.Demo.News.Domain.Abstractions;

namespace TechTalks.Demo.News.gRPC
{
    internal sealed class PressGrpcController : Press.PressBase
    {
        private readonly IArticlesService _articlesService;
        private readonly IMapper _mapper;
        private readonly ILogger<PressGrpcController> _logger;

        public PressGrpcController(
            IArticlesService articlesService,
            IMapper mapper,
            ILogger<PressGrpcController> logger)
        {
            _articlesService = articlesService;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<GetArticleByIdResponse> GetArticleById(
            GetArticleByIdRequest request, 
            ServerCallContext context)
        {
            _logger.LogInformation($"Getting the article with id: {request.ArticleId}");

            var article = await _articlesService.FindArticleByIdAsync(
                request.ArticleId, 
                context.CancellationToken);

            var mappedArticle = _mapper.Map<Article>(article);

            return new GetArticleByIdResponse
            {
                Article = mappedArticle
            };
        }
    }
}