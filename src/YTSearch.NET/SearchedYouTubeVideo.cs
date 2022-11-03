using YTSearch.NET.Models;

namespace YTSearch.NET
{
    public class SearchedYouTubeVideo : BaseYouTubeVideo
    {
        public SearchedYouTubeVideo(string title, string videoId, Thumbnail[] thumbnails, TimeSpan length, string author, int? views, string published) 
            : base(title, videoId, thumbnails, length, author, views)
        {
            Published = published;
        }

        /// <value><c>Published</c> is the provided duration between now and the time of publishing the video, e.g. "1 year ago"</value>
        public string Published { get; }
    }
}