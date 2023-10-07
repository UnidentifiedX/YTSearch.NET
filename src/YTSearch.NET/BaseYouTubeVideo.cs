using System;
using YTSearch.NET.Models;

namespace YTSearch.NET
{
    /// <summary>
    /// Abstract class <c>BaseYouTubeVideo</c> shows basic extracted information for a YouTube video
    /// </summary>
    
    public abstract class BaseYouTubeVideo
    {
        public BaseYouTubeVideo(string? title, string? videoId, Thumbnail[] thumbnails, TimeSpan length, string? author, int? views)
        {
            Title = title;
            VideoId = videoId;
            Thumbnails = thumbnails;
            Length = length;
            Author = author;
            Views = views;
        }
        /// <value><c>Title</c> is the title of the youtube video</value>
        public string? Title { get; }
        /// <value><c>VideoId</c> is the id of the youtube video</value>
        public string? VideoId { get; }
        /// <value><c>Url</c> is a derived property from the video id, which links to the video itself</value>
        public string? Url
        {
            get
            {
                return $"https://www.youtube.com/watch?v={VideoId}";
            }
        }
        /// <value><c>Thumbnails</c> is an array of <see cref="Thumbnail"/></value>
        public Thumbnail[] Thumbnails { get; }
        /// <value><c>Length</c> is the length of the video, in a <see cref="TimeSpan"/></value>
        public TimeSpan Length { get; }
        /// <value><c>Author</c> is the name of the youtube channel, i.e. the publisher of the video</value>
        public string? Author { get; }
        /// <value><c>Viers</c> is the number of views on the youtube video</value>
        public int? Views { get; }
    }
}