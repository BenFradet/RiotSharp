using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Class representing an image (Static API).
    /// </summary>
    public class ImageStatic
    {
        internal ImageStatic() { }

        /// <summary>
        /// Full name for this image.
        /// </summary>
        [JsonPropertyName("full")]
        public string Full { get; set; }

        /// <summary>
        /// Image's group (spell, champion, item, etc).
        /// </summary>
        [JsonPropertyName("group")]
        public string Group { get; set; }

        /// <summary>
        /// Image's height.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }

        /// <summary>
        /// Image's sprite.
        /// </summary>
        [JsonPropertyName("sprite")]
        public string Sprite { get; set; }

        /// <summary>
        /// Image's width.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }

        /// <summary>
        /// X starting point for this image.
        /// </summary>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        /// Y starting point for this image.
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
