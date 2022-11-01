namespace YTSearch.NET
{
    public class YouTubeSearchResult
    {
        public YouTubeSearchResult(string query, string url, ICollection<YouTubeVideo> results)
        {
            Query = query;
            Url = url;
            Results = results;
        }

        public string Query { get; }
        public string Url { get; }
        public ICollection<YouTubeVideo> Results { get; }
    }
}