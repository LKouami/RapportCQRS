using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace RapportCQRS.Domain.Commands.Common
{
    public class DeleteBaseCommand<T,TResult> : CommandBase<TResult> where TResult : class
    {
        public DeleteBaseCommand()
        {
        }

        [JsonConstructor]
        public DeleteBaseCommand(T id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        [Required]
        public T Id { get; set; }


        /// <summary>
        /// last Updated at retrieved
        /// </summary>
        [JsonProperty("updated_at")]
        [Required]
        public DateTime Updated_At { get; set; }

        /// <summary>
        /// The deleted date
        /// </summary>
        [JsonProperty("deleted_at")]
        [Required]
        public DateTime Deleted_At { get; set; }

        /// <summary>
        /// Deleted user
        /// </summary>
        [JsonProperty("deleted_by")]
        [Required]
        public int Deleted_By { get; set; }
    }

    public class DeleteBaseCommand<TResult>: DeleteBaseCommand<int,TResult> where TResult : class
    {

    }
}