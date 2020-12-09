using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLib.Model
{
    public class TrefleMeta
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        public override string ToString()
        {
            return $"{nameof(Total)}: {Total}";
        }
    }
}
