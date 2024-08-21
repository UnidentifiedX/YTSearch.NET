using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace YTSearch.NET.Models
{
    public class SearchedYouTubeChannel
    {
        public SearchedYouTubeChannel(string? channelId, string? name, Thumbnail[] thumbnails, JsonNode? descriptionSnippet, int? videoCount, int? subscribers)
        {
            ChannelId = channelId;
            Name = name;
            Thumbnails = thumbnails;
            DescriptionSnippet = descriptionSnippet;
            VideoCount = videoCount;
            Subscribers = subscribers;
        }

        public string? ChannelId { get; }
        public string? Name { get; }
        public Thumbnail[] Thumbnails { get; }
        public JsonNode? DescriptionSnippet { get; }
        public int? VideoCount { get; }
        public int? Subscribers { get; }
    }
}
