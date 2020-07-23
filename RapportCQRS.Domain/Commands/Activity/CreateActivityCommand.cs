using Newtonsoft.Json;
using RapportCQRS.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapportCQRS.Domain.Commands.Activity
{
    public class CreateActivityCommand : CreateCommandBase<ActivityDto>
    {
        public CreateActivityCommand() : base()
        {

        }

        [JsonProperty("userId")]
        public short UserId { get; set; }
        [JsonProperty("description")]
        public string ContenuAct { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        
    }
}
