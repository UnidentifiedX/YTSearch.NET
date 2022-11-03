using YTSearch.NET.Models;

namespace YTSearch.NET
{
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

        public DateTime DatePublished { get; }
        public string[]? Keywords { get; }
        public string? Description { get; }
        public bool? IsCrawlable { get; }
        public bool? IsRatingEnabled { get; }
        public bool? IsPrivate { get; }
        public bool? IsLiveContent { get; }
        public DateTime PublishedDate { get; }
        public DateTime UploadedDate { get; }
        public bool? IsFamilyFriendly { get; }
        public string[]? AvailableCountries { get; }
        public bool? IsUnlisted { get; }
        public string? Category { get; }
    }
}