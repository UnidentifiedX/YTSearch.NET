using System;
using YTSearch.NET.Models;

namespace YTSearch.NET
{
    /// <summary>
    /// Class <c>QueriedYouTubeVideo</c> inherits from <seealso cref="BaseYouTubeVideo"/> and shows extra video information extracted from a YouTube video
    /// </summary>
    public class QueriedYouTubeVideo : BaseYouTubeVideo
    {
        public QueriedYouTubeVideo(string title, string videoId, Thumbnail[] thumbnails, TimeSpan length, string author, int? views, string[]? keywords, string? description, bool? isCrawlable, bool? isRatingEnabled, bool? isPrivate, bool? isLiveContent, DateTime publishedDate, DateTime uploadedDate, bool? isFamilyFriendly, string[]? availableCountries, bool? isUnlisted, string? category) 
            : base(title, videoId, thumbnails, length, author, views)
        {
            Keywords = keywords;
            Description = description;
            IsCrawlable = isCrawlable;
            IsRatingEnabled = isRatingEnabled;
            IsPrivate = isPrivate;
            IsLiveContent = isLiveContent;
            PublishedDate = publishedDate;
            UploadedDate = uploadedDate;
            IsFamilyFriendly = isFamilyFriendly;
            AvailableCountries = availableCountries;
            IsUnlisted = isUnlisted;
            Category = category;
        }

        /// <value><c>Keywords</c> is the search keywords for the specified YouTube video in a <seealso cref="string[]"/>
        public string[]? Keywords { get; }
        /// <value><c>Description</c> is the description of the YouTube video</value>
        public string? Description { get; }
        /// <value><c>IsCrawlable</c> specifies if the video is crawlable</value>
        public bool? IsCrawlable { get; }
        /// <value><c>IsRatingEnabled</c> specifies if the video can be rated</value>
        public bool? IsRatingEnabled { get; }
        /// <value><c>IsPrivate</c> specifies if the video is private</value>
        public bool? IsPrivate { get; }
        /// <value><c>IsLiveContent</c> specifies if the video is a live video</value>
        public bool? IsLiveContent { get; }
        /// <value><c>PublishedDate</c> is a <seealso cref="DateTime"/> object of the published date of the video</value>
        public DateTime PublishedDate { get; }
        /// <value><c>UploadedDate</c> is a <seealso cref="DateTime"/> object of the uploaded date of the video</value>
        public DateTime UploadedDate { get; }
        /// <value><c>IsFamilyFriendly</c> specifies if the video is family-friendly</value>
        public bool? IsFamilyFriendly { get; }
        /// <value><c>AvailableCountries</c> is a <seealso cref="string[]"/> of country codes where the video is available</value>
        public string[]? AvailableCountries { get; }
        /// <value><c>IsUnlisted</c> specifies if the video is unlisted</value>
        public bool? IsUnlisted { get; }
        /// <value><c>Category</c> is the category the YouTube video falls under</value>
        public string? Category { get; }
    }
}