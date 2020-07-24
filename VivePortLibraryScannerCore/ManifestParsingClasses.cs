/// <summary>
/// These classes are for deserializarion only
/// </summary>
namespace VivePortLibraryScanner
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    internal class ViveApp
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("applications")]
        public Application[] Applications { get; set; }
    }

    internal partial class Application
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_key")]
        public string AppKey { get; set; }

        [JsonProperty("strings")]
        public Dictionary<string, Info> Strings { get; set; }

        [JsonProperty("launch_type")]
        public string LaunchType { get; set; }

        [JsonProperty("image_path")]
        public string ImagePath { get; set; }

        [JsonProperty("is_dashboard_overlay")]
        public bool IsDashboardOverlay { get; set; }

        [JsonProperty("arguments")]
        public string Arguments { get; set; }

        [JsonProperty("binary_path_windows")]
        public string BinaryPathWindows { get; set; }
    }

    internal partial class Info
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    
}
