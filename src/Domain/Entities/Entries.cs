using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Entries
    {
        [JsonProperty("API")]
        public string Api { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Auth")]
        public string? Auth { get; set; }
        [JsonProperty("HTTPS")]
        public bool Https { get; set; }
        [JsonProperty("Cors")]
        public string Cors { get; set; }
        [JsonProperty("Link")]
        public Uri Link { get; set; }
        [JsonProperty("Category")]
        public string Category { get; set; }
    }
}
