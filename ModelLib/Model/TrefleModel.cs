using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModelLib.Model
{
    public class TrefleModel
    {
        [JsonPropertyName("data")]
        public List<TrefleData> Data { get; set; }

        [JsonPropertyName("links")]
        public TrefleLinks Links { get; set; }

        [JsonPropertyName("meta")]
        public TrefleMeta Meta { get; set; }

        public override string ToString()
        {
            return $"{nameof(Data)}: {Data}, {nameof(Links)}: {Links}, {nameof(Meta)}: {Meta}";
        }
    }
}
