using Newtonsoft.Json;
using System;

namespace RapportCQRS.Model.Dtos
{
    public class RoleDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}