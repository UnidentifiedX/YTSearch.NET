using System;

namespace YTSearch.NET
{
    public partial class YouTubeSearchClient
    {
        public class YouTubeVideoQueryResult
        {
            public YouTubeVideoQueryResult(Uri uri, QueriedYouTubeVideo result)
            {
                Uri = uri;
                Result = result;
            }

            public Uri Uri { get; }
            public QueriedYouTubeVideo Result { get; }
        }
    }
}