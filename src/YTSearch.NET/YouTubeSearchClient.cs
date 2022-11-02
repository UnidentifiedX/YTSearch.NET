using System.Diagnostics;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Web;
using YTSearch.NET.Models;

namespace YTSearch.NET
{
    public class YouTubeSearchClient
    {
        public YouTubeSearchClient()
        {

        } 

        public async Task<YouTubeSearchResult> SearchYoutube(string query)
        {
            var searchResults = new List<YouTubeVideo>();

            var url = $"https://www.youtube.com/results?search_query={HttpUtility.UrlEncode(query)}&sp=EgIQAQ%253D%253D";
            var client = new HttpClient();

            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
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

                searchResults.Add(new YouTubeVideo(title, videoId, thumbnails, length, author, views, published));
            }

            return new YouTubeSearchResult(query, url, searchResults);
        }

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