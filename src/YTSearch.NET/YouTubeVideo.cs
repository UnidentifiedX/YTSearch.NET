namespace YTSearch.NET
{
    public class YouTubeVideo
    {
        public YouTubeVideo(string title, string videoId)
        {
            Title = title;
            VideoId = videoId;
        }

        public string Title { get; }
        public string VideoId { get; }
    }
}