using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using YTSearch.NET.Models;

namespace YTSearch.NET.Utils
{
    internal static class SearchUtils
    {
        internal static int? KMBToInt(string? kmb)
        {
            if (kmb == null) return null;

            try
            {
                if (kmb.ToLower().Contains('k'))
                {
                    return (int)(float.Parse(kmb.ToLower().Replace("k", "")) * 1000);
                }
                else if (kmb.ToLower().Contains('m'))
                {
                    return (int)(float.Parse(kmb.ToLower().Replace("m", "")) * 1000000);
                }
                else if (kmb.ToLower().Contains('b'))
                {
                    return (int)(float.Parse(kmb.ToLower().Replace("b", "")) * 1000000000);
                }
                else
                {
                    return int.Parse(kmb);
                }
            }
            catch
            {
                return null;
            }
        }

        internal static TimeSpan ParseVideoLength(string? timespan)
        {
            var output = TimeSpan.Zero;
            if (timespan != null)
            {
                try
                {
                    switch (timespan.Split(':').Length)
                    {
                        case 1:
                            output = TimeSpan.ParseExact(timespan, "%s", CultureInfo.InvariantCulture);
                            break;
                        case 2:
                            output = TimeSpan.ParseExact(timespan, @"m\:ss", CultureInfo.InvariantCulture);
                            break;
                        default:
                            output = TimeSpan.ParseExact(timespan, "g", CultureInfo.InvariantCulture);
                            break;
                    }
                }
                catch
                {
                    output = TimeSpan.Zero;
                }
            }

            return output;
        }

        internal static Thumbnail[] ParseThumbnails(JsonNode? jsonNode)
        {
            var thumbnails = new List<Thumbnail>();
            jsonNode?.AsArray().ToList().ForEach(thumbnail =>
            {
                var width = (int?)thumbnail?["width"];
                var height = (int?)thumbnail?["height"];
                var url = (string?)thumbnail?["url"];
                thumbnails.Add(new Thumbnail(width, height, url));
            });

            return thumbnails.ToArray();
        }
    }
}
