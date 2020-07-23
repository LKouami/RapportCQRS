using RapportCQRS.Model.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace RapportCQRS.Domain.Commands.User
{
    public class UpdateUserCommand : UpdateCommandBase<UserDto>
    {

        public UpdateUserCommand()
        {

        }

        [JsonConstructor]
        public UpdateUserCommand(int id,
            string email, string password,
            string token, byte status,
            int createdBy, DateTime createdAt)
            : base(createdBy, createdAt)
        {
            Id = id;
            Email = email;
            Password = password;
            Token = token;
            Email = email;
            Status = status;


        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        [EmailAddress]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("Status")]
        public byte Status { get; set; }
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