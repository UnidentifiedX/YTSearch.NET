using System;

namespace YTSearch.NET.Models
{
    /// <summary>
    /// Class <c>SearchedYoutubeVideo</c> inherits from <seealso cref="YouTubeVideoBase"/> and shows extra video information extracted from video searchess
    /// </summary>
    public class SearchedYouTubeVideo : YouTubeVideoBase
    {
        public SearchedYouTubeVideo(string? title, string? videoId, Thumbnail[] thumbnails, TimeSpan length, string? author, int? views, string? published)
            : base(title, videoId, thumbnails, length, author, views)
        {
            Published = published;
        }

        /// <value><c>Published</c> is the provided duration between now and the time of publishing the video, e.g. "1 year ago"</value>
        public string? Published { get; }
    }
}