using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Web;
using YTSearch.NET.Models;

namespace YTSearch.NET
{
    public partial class YouTubeSearchClient
    {
        private HttpClient _httpClient;

        public YouTubeSearchClient()
        {
            _httpClient = new HttpClient();
        }

        #region YoutubeSearch
        /// <summary>
        /// Searches youtube for videos based on a given <paramref name="query"/>
        /// </summary>
        /// <param name="query">Query string</param>
        /// <returns><seealso cref="YouTubeSearchResult"/></returns>
        public async Task<YouTubeSearchResult> SearchYoutubeAsync(string query)
        {
            var searchResults = new List<SearchedYouTubeVideo>();

            var url = $"https://www.youtube.com/results?search_query={HttpUtility.UrlEncode(query)}&sp=EgIQAQ%253D%253D";

            var result = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var content = await result.Content.ReadAsStringAsync();
            var jsonString = Regex.Matches(content, @"var ytInitialData = (.+?);<\/script>")[0].Groups[1].Value;
            var json = JsonNode.Parse(jsonString);
            var videos = json?["contents"]?["twoColumnSearchResultsRenderer"]?["primaryContents"]?["sectionListRenderer"]?["contents"]?[0]?["itemSectionRenderer"]?["contents"]?.AsArray().Where(o => o?["videoRenderer"] != null);

            foreach (var v in videos)
            {
                var video = v?["videoRenderer"];

                var title = (string?)video?["title"]?["runs"]?[0]?["text"];
                var videoId = (string?)video?["videoId"];
                var thumbnails = ParseThumbnails(video?["thumbnail"]?["thumbnails"]);
                var length = ParseVideoLength((string?)video?["lengthText"]?["simpleText"]);
                var author = (string?)video?["ownerText"]?["runs"]?[0]?["text"];
                int? views = int.TryParse(((string?)video?["viewCountText"]?["simpleText"])?.Replace(",", "")?.Replace("views", ""), out int parsed) ? parsed : null;
                var published = (string?)video?["publishedTimeText"]?["simpleText"];

                searchResults.Add(new SearchedYouTubeVideo(title, videoId, thumbnails, length, author, views, published));
            }

            return new YouTubeSearchResult(query, url, searchResults);
        }
        #endregion

        #region VideoMetadata
        public Task<YouTubeVideoQueryResult> GetVideoMetadataAsync(string videoId)
        {
            return GetVideoMetadataAsync(new Uri($"https://www.youtube.com/watch?v={videoId}"));
        }

        public async Task<YouTubeVideoQueryResult> GetVideoMetadataAsync(Uri uri)
        {
            var result = await _httpClient.GetAsync(uri);
            var content = await result.Content.ReadAsStringAsync();
            var jsonString = Regex.Matches(content, @"var ytInitialPlayerResponse = (.+?);<\/script>")[0].Groups[1].Value;
            var json = JsonNode.Parse(jsonString);
            var videoDetail = json?["videoDetails"];
            var microFormatRenderer = json?["microformat"]?["playerMicroformatRenderer"];

            var title = (string?)videoDetail?["title"];
            var videoId = (string?)videoDetail?["videoId"];
            var thumbnails = ParseThumbnails(videoDetail?["thumbnail"]?["thumbnails"]);
            var length = TimeSpan.FromSeconds(int.Parse((string?)videoDetail?["lengthSeconds"]));
            var author = (string?)videoDetail?["author"];
            var views = int.Parse((string?)videoDetail?["viewCount"]);
            var keywords = videoDetail?["keywords"]?.Deserialize<string[]>();
            var description = (string?)videoDetail?["shortDescription"];
            var isCrawlable = (bool?)videoDetail?["isCrawlable"];
            var isRatingEnabled = (bool?)videoDetail?["allowRatings"];
            var isPrivate = (bool?)videoDetail?["isPrivate"];
            var isLiveContent = (bool?)videoDetail["isLiveContent"];
            var publishedDate = DateTime.ParseExact((string?)microFormatRenderer?["publishDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var uploadedDate = DateTime.ParseExact((string?)microFormatRenderer?["uploadDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var isFamilyFriendly = (bool?)microFormatRenderer?["isFamilySafe"];
            var availableCountries = microFormatRenderer?["availableCountries"].Deserialize<string[]>();
            var isUnlisted = (bool?)microFormatRenderer?["isUnlisted"];
            var category = (string?)microFormatRenderer?["category"];

            return new YouTubeVideoQueryResult(uri,
                new QueriedYouTubeVideo(
                title,
                videoId,
                thumbnails,
                length,
                author,
                views,
                keywords,
                description,
                isCrawlable,
                isRatingEnabled,
                isPrivate,
                isLiveContent,
                publishedDate,
                uploadedDate,
                isFamilyFriendly,
                availableCountries,
                isUnlisted,
                category
            ));

        }
        #endregion

        private Thumbnail[] ParseThumbnails(JsonNode? jsonNode)
        {
            var thumbnails = new List<Thumbnail>();
            foreach (var thumbnail in jsonNode?.AsArray())
            {
                var width = (int)thumbnail?["width"];
                var height = (int)thumbnail?["height"];
                var url = (string)thumbnail?["url"];
                thumbnails.Add(new Thumbnail(width, height, url));
            }

            return thumbnails.ToArray();
        }

        private TimeSpan ParseVideoLength(string? timespan)
        {
            try
            {
                return TimeSpan.ParseExact(timespan, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    return TimeSpan.ParseExact(timespan, "h\\:mm\\:ss", CultureInfo.InvariantCulture);
                }
                catch
                {
                    try
                    {
                        return TimeSpan.ParseExact(timespan, "mm\\:ss", CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        return TimeSpan.ParseExact(timespan, "m\\:ss", CultureInfo.InvariantCulture);
                    }
                }
            }
        }
    }
}