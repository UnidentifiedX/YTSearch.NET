using System.Collections.Generic;

namespace YTSearch.NET
{
    public class YouTubeVideoSearchResult : YouTubeSearchResult
    {
        #region Search result
        /// <summary>
        /// Search result class
        /// </summary>
        public YouTubeVideoSearchResult(string query, string url, ICollection<SearchedYouTubeVideo> results) 
            :base(query, url)
        {
            Results = results;
        }

        /// <value>An <see cref="ICollection{YouTubeVideo}"/> of search results</value>
        public ICollection<SearchedYouTubeVideo> Results { get; }
        #endregion
    }
}