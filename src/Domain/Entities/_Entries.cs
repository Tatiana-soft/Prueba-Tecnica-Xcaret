using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;

namespace Domain.Entities
{
    public class _Entries
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("entries")]
        public List<Entries> Entries { get; set; }
    }
}
