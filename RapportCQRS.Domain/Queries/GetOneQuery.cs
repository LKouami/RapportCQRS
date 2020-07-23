using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RapportCQRS.Domain.Queries
{
    public class GetOneQuery<T, TResult> : QueryBase<TResult> where TResult : class
    {
        public GetOneQuery()
        {
        }

        [JsonConstructor]
        public GetOneQuery(T id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        [Required]
        public T Id { get; set; }
    }
}