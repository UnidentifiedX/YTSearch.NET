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

            var a = (await client.SearchYoutubeAsync("never gonna give you up")).Results.First().Url;
            var b = await client.GetVideoMetadataAsync(new Uri(a));

            Debugger.Break();
        }
    }
}