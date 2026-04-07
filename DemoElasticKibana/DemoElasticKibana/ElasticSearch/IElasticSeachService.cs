namespace DemoElasticKibana.ElasticSearch
{
    public interface IElasticSeachService<T> where T : class
    {
        Task IndexDocumentAsync(string index, T document);
    }
}
