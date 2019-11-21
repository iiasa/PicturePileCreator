using System;

namespace PPC.Utility.DTO
{
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public  class PileDefinition
    {
        [JsonProperty("campaign_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignName { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("question", NullValueHandling = NullValueHandling.Ignore)]
        public string Question { get; set; }

        [JsonProperty("instruction_pages", NullValueHandling = NullValueHandling.Ignore)]
        public string[] InstructionPages { get; set; }

        [JsonProperty("answers", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Answers { get; set; }

        private string InstructionPagesCombined => String.Join('#', InstructionPages).Replace("\'", "\'\'");
        private string CampaignNameSQL => CampaignName.Replace("\'", "\'\'");
        private string QuestionSQL => Question.Replace("\'", "\'\'");



        public string SqlInsert => $"select * from public.gw_insert_urundata_pile_definition('{CampaignNameSQL}', '{QuestionSQL}', '{InstructionPagesCombined}', 0);";

        public static PileDefinition FromJson(string json) => JsonConvert.DeserializeObject<PileDefinition>(json, PPC.Utility.DTO.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PileDefinition self) => JsonConvert.SerializeObject(self, PPC.Utility.DTO.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}