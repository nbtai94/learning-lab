namespace DemoElasticKibana.Models
{
    public class AppSetting
    {
        public ElasticSearch Elasticsearch { get; set; }
    }

    public class ElasticSearch
    {
        public ElasticSearch()
        {
            Url = string.Empty;
        }
        public string Url { get; set; }
    }
}
