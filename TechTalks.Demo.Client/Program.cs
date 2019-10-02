using System;
using Lohika.TechTalks.News;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TechTalks.Demo.Client
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddLogging(options => { options.AddConsole(); });
            services.AddGrpcClient<Press.PressClient>(options =>
                {
                    options.Address = new Uri("https://localhost:5001");
                });

            var container = services.BuildServiceProvider();

            var logger = container.GetRequiredService<ILogger<Program>>();
            var client = container.GetRequiredService<Press.PressClient>();

            var response = client.GetArticleById(new GetArticleByIdRequest
            {
                ArticleId = 1
            });

            logger.LogInformation($"Got the article: {response.Article.Id}");

            Console.ReadKey();
        }
    }
}
