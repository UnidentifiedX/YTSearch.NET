using System.Threading.Tasks;

namespace YTSearch.NET.TestConsole
{   
    class TestConsole
    {
        static async Task Main(string[] args)
        {
            var client = new YouTubeSearchClient();

            var a = await client.SearchYouTube("astronomia");
        }
    }
}