using Nest;

namespace DemoElasticKibana.ElasticSearch
{
    public static class ElasticSearchClient
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ElasticSearch:Url"];
            var settings = new ConnectionSettings(new Uri(url));
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
        }
    }
}
