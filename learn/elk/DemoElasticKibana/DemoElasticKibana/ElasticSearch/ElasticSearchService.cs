
using Nest;

namespace DemoElasticKibana.ElasticSearch
{
    public class ElasticSearchService<T> : IElasticSeachService<T> where T : class
    {
        private readonly IElasticClient _client;
        public ElasticSearchService(IElasticClient client)
        {
            _client = client;
        }

        public async Task IndexDocumentAsync(string index, T document)
        {
            var response = await _client.IndexAsync(document, i => i.Index(index));
            if (response.IsValid)
            {
                Console.WriteLine("Document indexed successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to index document: {response.OriginalException.Message}");
            }
        }
    }
}
