using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTalks.Demo.News.Domain.Abstractions;
using TechTalks.Demo.News.ViewModels;

namespace TechTalks.Demo.News.Controllers
{
    [Route("articles")]
    public sealed class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        private readonly INewsFactory _newsFactory;
        private readonly IMapper _mapper;

        public ArticlesController(
            IArticlesService articlesService,
            INewsFactory newsFactory,
            IMapper mapper)
        {
            _articlesService = articlesService;
            _newsFactory = newsFactory;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{articleId}", Name = RouteNames.GetByIdRoute)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArticleViewModel>> GetByIdAsync(
            int articleId,
            CancellationToken cancellationToken)
        {
            var article = await _articlesService.FindArticleByIdAsync(articleId, cancellationToken);

            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticleViewModel>(article);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ArticleViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewAsync(
            CreateArticleViewModel viewModel,
            CancellationToken cancellationToken)
        {
            var draft = _newsFactory.CreateArticleDraft();
            _mapper.Map(viewModel, draft);

            var validationResult = draft.Validate();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.Summary, error.Details);
                }

                return BadRequest(ModelState);
            }

            var createdArticle = await _articlesService.PublishArticleAsync(draft, cancellationToken);

            return CreatedAtRoute(
                RouteNames.GetByIdRoute,
                new { articleId = createdArticle.Id },
                createdArticle);
        }

        [HttpDelete]
        [Route("{articleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteArticleByIdAsync(
            int articleId,
            CancellationToken cancellationToken)
        {
            await _articlesService.DeleteArticleAsync(articleId, cancellationToken);

            return NoContent();
        }

        private static class RouteNames
        {
            public const string GetByIdRoute = nameof(ArticlesController) + "." + nameof(GetByIdAsync);
        }
    }
}