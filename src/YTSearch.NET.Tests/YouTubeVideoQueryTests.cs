using System.Globalization;

namespace YTSearch.NET.Tests
{
    public partial class Tests
    {
        [Test]
        public async Task QueryYouTubeVideo_GetVideoMetadataWithVideoId_CorrectVideoDetails()
        {
            var a = (await _client.GetVideoMetadataAsync("dQw4w9WgXcQ")).Result;
            var b = new string[] {  };
            Assert.Multiple(() =>
            {
                Assert.That(a.Title, Is.EqualTo("Rick Astley - Never Gonna Give You Up (Official Music Video)"));
                Assert.That(a.VideoId, Is.EqualTo("dQw4w9WgXcQ"));
                Assert.That(a.Url, Is.EqualTo("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
                Assert.That(a.Length, Is.EqualTo(TimeSpan.FromSeconds(212)));
                Assert.That(a.Author, Is.EqualTo("Rick Astley"));

                Assert.That(a.Description, Is.EqualTo("The official video for “Never Gonna Give You Up” by Rick Astley\nTaken from the album ‘Whenever You Need Somebody’ – deluxe 2CD and digital deluxe out 6th May 2022 Pre-order here – https://RickAstley.lnk.to/WYNS2022ID\n\n“Never Gonna Give You Up” was a global smash on its release in July 1987, topping the charts in 25 countries including Rick’s native UK and the US Billboard Hot 100.  It also won the Brit Award for Best single in 1988. Stock Aitken and Waterman wrote and produced the track which was the lead-off single and lead track from Rick’s debut LP “Whenever You Need Somebody”.  The album was itself a UK number one and would go on to sell over 15 million copies worldwide.\n\nThe legendary video was directed by Simon West – who later went on to make Hollywood blockbusters such as Con Air, Lara Croft – Tomb Raider and The Expendables 2.  The video passed the 1bn YouTube views milestone on 28 July 2021.\n\nSubscribe to the official Rick Astley YouTube channel: https://RickAstley.lnk.to/YTSubID\n\nFollow Rick Astley:\nFacebook: https://RickAstley.lnk.to/FBFollowID \nTwitter: https://RickAstley.lnk.to/TwitterID \nInstagram: https://RickAstley.lnk.to/InstagramID \nWebsite: https://RickAstley.lnk.to/storeID \nTikTok: https://RickAstley.lnk.to/TikTokID\n\nListen to Rick Astley:\nSpotify: https://RickAstley.lnk.to/SpotifyID \nApple Music: https://RickAstley.lnk.to/AppleMusicID \nAmazon Music: https://RickAstley.lnk.to/AmazonMusicID \nDeezer: https://RickAstley.lnk.to/DeezerID \n\nLyrics:\nWe’re no strangers to love\nYou know the rules and so do I\nA full commitment’s what I’m thinking of\nYou wouldn’t get this from any other guy\n\nI just wanna tell you how I’m feeling\nGotta make you understand\n\nNever gonna give you up\nNever gonna let you down\nNever gonna run around and desert you\nNever gonna make you cry\nNever gonna say goodbye\nNever gonna tell a lie and hurt you\n\nWe’ve known each other for so long\nYour heart’s been aching but you’re too shy to say it\nInside we both know what’s been going on\nWe know the game and we’re gonna play it\n\nAnd if you ask me how I’m feeling\nDon’t tell me you’re too blind to see\n\nNever gonna give you up\nNever gonna let you down\nNever gonna run around and desert you\nNever gonna make you cry\nNever gonna say goodbye\nNever gonna tell a lie and hurt you\n\n#RickAstley #NeverGonnaGiveYouUp #WheneverYouNeedSomebody #OfficialMusicVideo"));
                Assert.That(a.IsCrawlable, Is.EqualTo(true));
                Assert.That(a.IsRatingEnabled, Is.EqualTo(true));
                Assert.That(a.IsPrivate, Is.EqualTo(false));
                Assert.That(a.IsLiveContent, Is.EqualTo(false));
                Assert.That(a.PublishedDate, Is.EqualTo(DateTime.ParseExact("10-24-2009", "MM-dd-yyyy", CultureInfo.InvariantCulture)));
                Assert.That(a.UploadedDate, Is.EqualTo(DateTime.ParseExact("10-24-2009", "MM-dd-yyyy", CultureInfo.InvariantCulture)));
                Assert.That(a.IsFamilyFriendly, Is.EqualTo(true));
                Assert.That(a.IsUnlisted, Is.EqualTo(false));
                Assert.That(a.Category, Is.EqualTo("Music"));
            });
        }
    }
}
