using System.Collections.Generic;

namespace YTSearch.NET.Models
{
    public class YouTubeChannelSearchResult : YouTubeSearchResult
    {
        public YouTubeChannelSearchResult(string query, string url, ICollection<SearchedYouTubeChannel> results)
            : base(query, url)
        {
            Results = results;
        }

        public ICollection<SearchedYouTubeChannel> Results { get; }
    }
}
