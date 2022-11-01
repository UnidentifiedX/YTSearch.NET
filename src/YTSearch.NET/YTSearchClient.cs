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

        public async Task<YouTubeSearchResult> SearchYouTube(string query)
        {
            var url = $"https://youtube.com/results?search_query={HttpUtility.UrlEncode(query)}";
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

                Debugger.Break();
            }

            Debugger.Break();

            return new YouTubeSearchResult("a", "a", new List<YouTubeVideo>());
        }

        private List<Thumbnail> ParseThumbnails(JsonNode? jsonNode)
        {
            var thumbnails = new List<Thumbnail>();
            foreach (var thumbnail in jsonNode?.AsArray())
            {
                var width = (int)thumbnail?["width"];
                var height = (int)thumbnail?["height"];
                var url = (string)thumbnail?["url"];
                thumbnails.Add(new Thumbnail(width, height, url));
            }

            return thumbnails;
        }

        private int ParseVideoLength(string? timespan)
        {
            try
            {
                return (int)TimeSpan.ParseExact(timespan, "hh\\:mm\\:ss", CultureInfo.InvariantCulture).TotalSeconds;
            }
            catch
            {
                return (int)TimeSpan.ParseExact(timespan, "mm\\:ss", CultureInfo.InvariantCulture).TotalSeconds;
            }
        }
    }
}