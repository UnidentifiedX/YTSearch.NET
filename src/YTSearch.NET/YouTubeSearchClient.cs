using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        public async Task<YouTubeVideoSearchResult> SearchYoutubeVideoAsync(string query)
        {
            var searchResults = new List<SearchedYouTubeVideo>();
            query = HttpUtility.UrlEncode(query);

            var url = $"https://www.youtube.com/results?search_query={query}&sp=EgIQAQ%253D%253D";

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
                int? views = int.TryParse(((string?)video?["viewCountText"]?["simpleText"])?.Replace(",", "")?.Replace("views", ""), out int parsed) ? parsed : (int?)null; // (int?) cast to target netstandard2.1
                var published = (string?)video?["publishedTimeText"]?["simpleText"];

                searchResults.Add(new SearchedYouTubeVideo(title, videoId, thumbnails, length, author, views, published));
            }

            return new YouTubeVideoSearchResult(query, url, searchResults);
        }

        public async Task<YouTubeChannelSearchResult> SearchYouTubeChannelAsync(string query)
        {
            throw new NotImplementedException();

            var searchResults = new List<SearchedYouTubeChannel>();
            query = HttpUtility.UrlEncode(query);

            var url = $"https://www.youtube.com/results?search_query={query}&sp=EgIQAg%253D%253D";

            var result = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var content = await result.Content.ReadAsStringAsync();
            var jsonString = Regex.Matches(content, @"var ytInitialData = (.+?);<\/script>")[0].Groups[1].Value;
            var json = JsonNode.Parse(jsonString);
            var channels = json?["contents"]?["twoColumnSearchResultsRenderer"]?["primaryContents"]?["sectionListRenderer"]?["contents"]?[0]?["itemSectionRenderer"]?["contents"]?.AsArray();

            foreach (var c in channels)
            {
                var channel = c?["channelRenderer"];

                var channelId = (string?)channel?["channelId"];
                var name = (string?)channel?["title"]?["simpleText"];
                var thumbnails = ParseThumbnails(channel?["thumbnail"]?["thumbnails"]);
                var descriptionSnippet = channel?["descriptionSnippet"]?["runs"]?[0]?["text"];
                int? videoCount = int.TryParse((string?)channel?["videoCountText"]?["runs"]?[0]?["text"], out int parsed) ? parsed : (int?)null; // (int?) cast to target netstandard2.1
                int? subscribers = KMBToInt(((string?)channel?["subscriberCountText"]?["simpleText"])?.Replace("subscribers", ""));

                searchResults.Add(new SearchedYouTubeChannel(channelId, name, thumbnails, descriptionSnippet, videoCount, subscribers));
            }

            return new YouTubeChannelSearchResult(query, url, searchResults);
        }
        #endregion

        #region VideoMetadata
        /// <summary>
        /// Gets video metadata from a video id
        /// </summary>
        /// <param name="videoId">Video id</param>
        /// <returns><seealso cref="YouTubeVideoQueryResult"/></returns>
        public Task<YouTubeVideoQueryResult> GetVideoMetadataAsync(string videoId)
        {
            return GetVideoMetadataAsync(new Uri($"https://www.youtube.com/watch?v={videoId}"));
        }

        /// <summary>
        /// Gets video metadata from a video uri
        /// </summary>
        /// <param name="uri">Video uri</param>
        /// <returns><seealso cref="YouTubeVideoQueryResult"/></returns>
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

        private static Thumbnail[] ParseThumbnails(JsonNode? jsonNode)
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

        private static TimeSpan ParseVideoLength(string? timespan)
        {
            var output = TimeSpan.Zero;
            if (timespan != null)
            {
                try
                {
                    switch (timespan.Split(':').Length)
                    {
                        case 1:
                            output = TimeSpan.ParseExact(timespan, "%s", CultureInfo.InvariantCulture);
                            break;
                        case 2:
                            output = TimeSpan.ParseExact(timespan, @"m\:ss", CultureInfo.InvariantCulture);
                            break;
                        default:
                            output = TimeSpan.ParseExact(timespan, "g", CultureInfo.InvariantCulture);
                            break;
                    }
                }
                catch
                {
                    output = TimeSpan.Zero;
                }
            }

            return output;
        }

        private static int? KMBToInt(string? kmb)
        {
            if(kmb == null) return null;

            try
            {
                if (kmb.ToLower().Contains('k'))
                {
                    return (int)float.Parse(kmb.ToLower().Replace("k", "")) * 1000;
                }
                else if (kmb.ToLower().Contains('m'))
                {
                    return (int)float.Parse(kmb.ToLower().Replace("m", "")) * 1000000;
                }
                else if (kmb.ToLower().Contains('b'))
                {
                    return (int)float.Parse(kmb.ToLower().Replace("b", "")) * 1000000000;
                }
                else
                {
                    return int.Parse(kmb);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}