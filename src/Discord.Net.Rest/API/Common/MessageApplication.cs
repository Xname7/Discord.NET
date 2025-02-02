using Newtonsoft.Json;

namespace Discord.API
{
    internal class MessageApplication
    {
        /// <summary>
        ///     Gets the snowflake ID of the application.
        /// </summary>
        [JsonProperty("id")]
        public ulong Id { get; set; }
        /// <summary>
        ///     Gets the ID of the embed's image asset.
        /// </summary>
        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }
        /// <summary>
        ///     Gets the application's description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        ///     Gets the ID of the application's icon.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        /// <summary>
        ///     Gets the name of the application.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
