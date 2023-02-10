using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTSearch.NET.Models
{
    /// <summary>
    /// A thumbnail class (record)
    /// </summary>
    /// <param name="Width">Width of the thumbnail</param>
    /// <param name="Height">Height of the thumbnail</param>
    /// <param name="Url">Link to thumbnail image</param>

#if NET5_0_OR_GREATER
    public record Thumbnail(int Width, int Height, string Url);
#else
    public class Thumbnail
    {
        public Thumbnail(int width, int height, string url)
        {
            Width = width;
            Height = height;
            Url = url;
        }

        public int Width { get; }
        public int Height { get; }
        public string Url { get; }
    }
#endif
}