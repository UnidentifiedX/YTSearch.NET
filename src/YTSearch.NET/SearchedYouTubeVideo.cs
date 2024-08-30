using System;
using YTSearch.NET.Models;

namespace YTSearch.NET
{
    /// <summary>
    /// Class <c>SearchedYoutubeVideo</c> inherits from <seealso cref="BaseYouTubeVideo"/> and shows extra video information extracted from video searchess
    /// </summary>
    public class SearchedYouTubeVideo : BaseYouTubeVideo
    {
        public SearchedYouTubeVideo(string? title, string? videoId, Thumbnail[] thumbnails, TimeSpan length, string? author, long? views, string? published) 
            : base(title, videoId, thumbnails, length, author, views)
        {
            Published = published;
        }

        /// <value><c>Published</c> is the provided duration between now and the time of publishing the video, e.g. "1 year ago"</value>
        public string? Published { get; }
    }
}