using System.Diagnostics;
using System.Threading.Tasks;

namespace YTSearch.NET.TestConsole
{   
    class TestConsole
    {
        static async Task Main(string[] args)
        {
            var client = new YouTubeSearchClient();

            var a = await client.SearchYouTube("all i want for christmas is you");

            Debugger.Break();
        }
    }
}