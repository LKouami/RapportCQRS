﻿using Newtonsoft.Json;
using RapportCQRS.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapportCQRS.Domain.Commands.TimeTable
{
    public class UpdateTimeTableCommand : UpdateCommandBase<TimeTableDto>
    {
        public UpdateTimeTableCommand()
        {

        }

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
        
    }
}
