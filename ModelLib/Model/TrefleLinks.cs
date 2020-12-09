using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLib.Model
{
    public class TrefleLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public string Prev { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }

        public override string ToString()
        {
            return $"{nameof(Self)}: {Self}, {nameof(First)}: {First}, {nameof(Next)}: {Next}, {nameof(Prev)}: {Prev}, {nameof(Last)}: {Last}";
        }
    }
}
