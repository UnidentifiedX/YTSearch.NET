## YTSearch.NET

A simple .NET library that searches YouTube for video results and video data.

## Installation

Install the package via NuGet:
```
PM> Install-Package YTSearch.NET
```

## Running the project
### Quickstart

```cs
using YTSearch.NET;

var client = new YouTubeSearchClient();
var results = await client.SearchYoutube("all i want for christmas is you");

foreach (var result in a.Results)
{
    Console.WriteLine($"{result.Title} | {result.Author} | {result.Length:mm\\:ss}");
}

/*
Mariah Carey - All I Want for Christmas Is You (Make My Wish Come True Edition) | Mariah Carey | 04:03
Mariah Carey - All I Want For Christmas Is You (Official Video) | Mariah Carey | 03:55
Mariah Carey - All I Want For Christmas Is You (Lyrics) | 7clouds | 04:02
[Playlist] must-have songs on this christmas ?? christmas medley 2021 | are you happy? | 50:16
All I Want For Christmas Is You |  La Portella tancek dance | Tanecná skola La Portella | 03:56
All I Want For Christmas Is You (SuperFestive!) (Shazam Version) | Justin Bieber | 04:14
????? ??? ??? ?? `All I Want for Christmas Is You?'?2021 SBS ????(2021sbsgayo)?SBS ENTER. | SBS Entertainment | 03:55
Mariah Carey, Ariana Grande, Justin Bieber Christmas Songs - Top Pop Christmas Songs Playlist 2020 | Dautay vlog | 05:47
Mariah Carey - All I Want for Christmas Is You (Official Audio) | Nielson Lucas | 04:02
All I Want For Christmas Is You | Live Love Party | Zumba | Dance Fitness | Christmas | LIVELOVEPARTY.TV | 04:05
Fifth Harmony - All I Want for Christmas Is You (Official Video) | Fifth Harmony | 03:50
Mariah Carey - All I Want for Christmas Is You (Live at Tokyo Dome) | Mariah Carey | 04:55
All I Want For Christmas Is You - Mariah Carey (Karaoke Songs With Lyrics - Original Key) | Musisi Karaoke | 04:32
Mariah Carey - All I Want For Christmas Is You | GreGaVa Channel | 03:53
All I Want for Christmas Is You arranged by Michael Brown | Hal Leonard Concert Band | 02:54
all i want for christmas is you sped up | love. | 03:04
"All I Want For Christmas Is You" - Mariah Carey (Against The Current COVER) | Against The Current | 03:17
?10 HOURS? All I Want for Christmas Is You | 10 Hour Archive | 02:51
All I Want for Christmas Is You (SATB Choir) - Arranged by Mac Huff | Hal Leonard Choral | 03:45
*/
```

## Issues and Contributing
Pull requests and issues are more than welcome.

## License
This projects is licensed under the [MIT License](./LICENSE.txt).

## TODO and planned features
- [ ] YouTube Music search 
- [ ] Search by playlist, author, etc.
- [x] Search video metadata
- [ ] Add like count to video metadata