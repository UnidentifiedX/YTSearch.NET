namespace YTSearch.NET
{
    public class YouTubeSearchResult
    {
        /// <summary>
        /// Search result class
        /// </summary>
        public YouTubeSearchResult(string query, string url, ICollection<YouTubeVideo> results)
        {
            Query = query;
            Url = url;
            Results = results;
        }

        /// <value>Query string</value>
        public string Query { get; }
        /// <value>Search url based on query string, url encoded</value>
        public string Url { get; }
        /// <value>An <see cref="ICollection{YouTubeVideo}"/> of search results</value>
        public ICollection<YouTubeVideo> Results { get; }
    }
}