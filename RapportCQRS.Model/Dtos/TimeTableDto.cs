using Newtonsoft.Json;
using System;

namespace RapportCQRS.Model.Dtos
{
    public class TimeTableDto
    {
        [JsonProperty("id")]
        public short Id { get; set; }
        [JsonProperty("userId")]
        public short UserId { get; set; }
        [JsonProperty("dateDuJour")]
        public DateTime DateDuJour { get; set; }
        [JsonProperty("heureArrive")]
        public DateTime HeureArrive { get; set; }
        [JsonProperty("heureDepart")]
        public DateTime HeureDepart { get; set; }
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