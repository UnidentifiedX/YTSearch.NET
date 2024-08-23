using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace YTSearch.NET.TestConsole
{
    class TestConsole
    {
        static async Task Main(string[] args)
        {
            var client = new YouTubeSearchClient();

            //var a = await client.SearchYouTubeChannelAsync("rick astley");
            var a = await client.GetVideoMetadataAsync("qUeud6DvOWI");
            //var a = (await client.SearchYoutubeVideoAsync("never gonna give you up")).Results.First().Url;
            //var a = (await client.SearchYoutubeVideoAsync("beautiful girls"));

            Debugger.Break();


            ////var a = (await client.SearchYoutubeAsync("never gonna give you up")).Results.First().Url;
            //var _metadata_test = (await client.GetVideoMetadataAsync(new Uri("https://www.youtube.com/watch?v=yXQViqx6GMY"))).Result;

            ////Debugger.Break();

            //Console.WriteLine(_metadata_test.Author);           // MariahCareyVEVO
            //Console.WriteLine(_metadata_test.Category);         // Music
            //Console.WriteLine(_metadata_test.IsCrawlable);      // True
            //Console.WriteLine(_metadata_test.IsFamilyFriendly); // True
            //Console.WriteLine(_metadata_test.IsLiveContent);    // False
            //Console.WriteLine(_metadata_test.IsPrivate);        // False
            //Console.WriteLine(_metadata_test.IsRatingEnabled);  // True
            //Console.WriteLine(_metadata_test.IsUnlisted);       // False
            //Console.WriteLine(_metadata_test.Length);           // 00:03:55
            //Console.WriteLine(_metadata_test.PublishedDate);    // 23/11/2009 12:00:00 am
            //Console.WriteLine(_metadata_test.UploadedDate);     // 23/11/2009 12:00:00 am
            //Console.WriteLine(_metadata_test.Title);            // Mariah Carey - All I Want For Christmas Is You (Official Video)
            //Console.WriteLine(_metadata_test.Url);              // https://www.youtube.com/watch?v=yXQViqx6GMY
            //Console.WriteLine(_metadata_test.VideoId);          // yXQViqx6GMY
            //Console.WriteLine(_metadata_test.Views);            // 731599447
            //Console.ReadKey();

            //// Should be the second song in the list, depends on Youtube tho and whats most popular
            //var _video_test = (await client.SearchYoutubeVideoAsync("Mariah Carey - All I Want For Christmas Is You (Official Video)")).Results;

            //foreach (SearchedYouTubeVideo _vid in _video_test)
            //{
            //    Console.WriteLine(Environment.NewLine);
            //    Console.WriteLine(_vid.Author);           // MariahCarey
            //    Console.WriteLine(_vid.Length);           // 00:03:55
            //    Console.WriteLine(_vid.Title);            // Mariah Carey - All I Want For Christmas Is You (Official Video)
            //    Console.WriteLine(_vid.Url);              // https://www.youtube.com/watch?v=yXQViqx6GMY
            //    Console.WriteLine(_vid.VideoId);          // yXQViqx6GMY
            //    Console.WriteLine(_vid.Views);            // 731599447
            //    Console.ReadKey();
            //}
        }
    }
}