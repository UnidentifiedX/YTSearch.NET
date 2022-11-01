using YTSearch.NET.Models;

namespace YTSearch.NET
{
    public class YouTubeVideo
    {
        public YouTubeVideo(string title, string videoId, Thumbnail[] thumbnails, TimeSpan length, string author, int views, string published)
        {
            Title = title;
            VideoId = videoId;
            Thumbnails = thumbnails;
            Length = length;
            Author = author;
            Views = views;
            Published = published;
        }

        public string Title { get; }
        public string VideoId { get; }
        public string Url { get
            {
                return $"https://www.youtube.com/watch?v={VideoId}";
            }
        }
        public Thumbnail[] Thumbnails { get; }
        public TimeSpan Length { get; }
        public string Author { get; }
        public int Views { get; }
        public string Published { get; }
    }
}