using System.Collections.Generic;
using Newtonsoft.Json;

namespace StockVisionConsole.Models
{
    public class ArticlesObj
    {
        
        [JsonProperty("sortBy")]
        public string SortBy { get; set; }

        [JsonProperty("articles")]
        public List<ArticleList> Article { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        
    }
}
public class ArticleList
{
    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("publishedAt")]
    public string PublishedAt { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("urlToImage")]
    public string UrlToImage { get; set; }
}