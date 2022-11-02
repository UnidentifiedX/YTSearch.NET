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
    public record Thumbnail(int Width, int Height, string Url);
}