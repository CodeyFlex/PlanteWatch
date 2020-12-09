using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLib.Model
{
    public class TrefleData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("bibliography")]
        public string Bibliography { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("rank")]
        public string Rank { get; set; }

        [JsonPropertyName("family_common_name")]
        public string FamilyCommonName { get; set; }

        [JsonPropertyName("genus_id")]
        public int GenusId { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("synonyms")]
        public List<string> Synonyms { get; set; }

        [JsonPropertyName("genus")]
        public string Genus { get; set; }

        [JsonPropertyName("family")]
        public string Family { get; set; }

        [JsonPropertyName("links")]
        public TrefleDataLinks Links { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(CommonName)}: {CommonName}, {nameof(Slug)}: {Slug}, {nameof(ScientificName)}: {ScientificName}, {nameof(Year)}: {Year}, {nameof(Bibliography)}: {Bibliography}, {nameof(Author)}: {Author}, {nameof(Status)}: {Status}, {nameof(Rank)}: {Rank}, {nameof(FamilyCommonName)}: {FamilyCommonName}, {nameof(GenusId)}: {GenusId}, {nameof(ImageUrl)}: {ImageUrl}, {nameof(Synonyms)}: {Synonyms}, {nameof(Genus)}: {Genus}, {nameof(Family)}: {Family}, {nameof(Links)}: {Links}";
        }
    }
}
