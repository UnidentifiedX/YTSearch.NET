namespace YTSearch.NET.Tests
{
    public class Tests
    {
        private YouTubeSearchClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new YouTubeSearchClient();
        }

        [Test]
        public async Task SearchYoutube_TitleSearchWithoutFlags_CorrectUrlAndQuery()
        {
            var a = await _client.SearchYoutube("never gonna give you up");
            Assert.Multiple(() =>
            {
                Assert.That(a.Url, Is.EqualTo("https://www.youtube.com/results?search_query=never+gonna+give+you+up"));
                Assert.That(a.Query, Is.EqualTo("never gonna give you up"));
            });
        }

        [Test]
        public async Task SearchYoutube_TitleSearchWithoutFlags_CorrectVideoDetails()
        {
            var a = (await _client.SearchYoutube("never gonna give you up")).Results.First();
            Assert.Multiple(() =>
            {
                Assert.That(a.Title, Is.EqualTo("Rick Astley - Never Gonna Give You Up (Official Music Video)"));
                Assert.That(a.VideoId, Is.EqualTo("dQw4w9WgXcQ"));
                Assert.That(a.Url, Is.EqualTo("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
                Assert.That(a.Length, Is.EqualTo(TimeSpan.FromSeconds(213)));
                Assert.That(a.Author, Is.EqualTo("Rick Astley"));
                Assert.That(a.Published, Is.EqualTo("13 years ago"));
            });
        }
    }
}