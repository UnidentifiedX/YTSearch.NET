using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTSearch.NET
{
    public abstract class YouTubeSearchResult
    {
        public YouTubeSearchResult(string query, string url)
        {
            Query = query;
            Url = url;
        }

        /// <value>Query string</value>
        public string Query { get; }
        /// <value>Search url based on query string, url encoded</value>
        public string Url { get; }
    }
}
