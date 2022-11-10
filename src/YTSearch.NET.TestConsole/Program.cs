using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace YTSearch.NET.TestConsole
{   
    class TestConsole
    {
        static async Task Main(string[] args)
        {
            var client = new YouTubeSearchClient();

            //var a = (await client.SearchYoutubeAsync("never gonna give you up")).Results.First().Url;
            var result = (await client.GetVideoMetadataAsync(new Uri("https://www.youtube.com/watch?v=yXQViqx6GMY"))).Result;

            //Debugger.Break();

            Console.WriteLine(result.Author); // MariahCareyVEVO
            Console.WriteLine(result.Category); // Music
            Console.WriteLine(result.IsCrawlable); // True
            Console.WriteLine(result.IsFamilyFriendly); // True
            Console.WriteLine(result.IsLiveContent); // False
            Console.WriteLine(result.IsPrivate); // False
            Console.WriteLine(result.IsRatingEnabled); // True
            Console.WriteLine(result.IsUnlisted); // False
            Console.WriteLine(result.Length); // 00:03:55
            Console.WriteLine(result.PublishedDate); // 23/11/2009 12:00:00 am
            Console.WriteLine(result.UploadedDate); // 23/11/2009 12:00:00 am
            Console.WriteLine(result.Title); // Mariah Carey - All I Want For Christmas Is You (Official Video)
            Console.WriteLine(result.Url); // https://www.youtube.com/watch?v=yXQViqx6GMY
            Console.WriteLine(result.VideoId); // yXQViqx6GMY
            Console.WriteLine(result.Views); // 731599447
        }
    }
}