using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLib.Model
{
    public class TrefleDataLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }

        [JsonPropertyName("plant")]
        public string Plant { get; set; }

        [JsonPropertyName("genus")]
        public string Genus { get; set; }

        public override string ToString()
        {
            return $"{nameof(Self)}: {Self}, {nameof(Plant)}: {Plant}, {nameof(Genus)}: {Genus}";
        }
    }
}
