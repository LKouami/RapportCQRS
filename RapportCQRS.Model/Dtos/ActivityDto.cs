using Newtonsoft.Json;
using System;

namespace RapportCQRS.Model.Dtos
{
    public class ActivityDto
    {
        [JsonProperty("id")]
        public short Id { get; set; }
        [JsonProperty("userId")]
        public short UserId { get; set; }
        [JsonProperty("description")]
        public string ContenuAct { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("modifiedBy")]
        public int ModifiedBy { get; set; }
        [JsonProperty("modifiedAt")]
        public DateTime ModifiedAt { get; set; }
        [JsonProperty("deletedBy")]
        public int? DeletedBy { get; set; }
        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }


    }
}