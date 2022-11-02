using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace YTSearch.NET.TestConsole
{   
    class TestConsole
    {
        static async Task Main(string[] args)
        {
            var client = new YouTubeSearchClient();

            var a = await client.SearchYoutube("all i want for christmas is you");

            foreach (var result in a.Results)
            {
                Console.WriteLine($"{result.Title} | {result.Author} | {result.Length:mm\\:ss}");
            }
        }
    }
}