using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace RapportCQRS.Domain.Queries
{
    public class QueryListBase<TResult> : QueryBase<TResult> where TResult : class
    {
        public QueryListBase()
        {
            Direction = "asc";
            PageIndex = 0;

            //TODO change to configuration
            PageSize = 15;
        }
        public QueryListBase(string search, string sort, string direction, int pageIndex, int pageSize)
            :this()
        {
            Search = search;
            Sort = sort;
            Direction = direction;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        [JsonProperty("search")]
        public string Search { get; set; }

        /// <summary>
        /// Sorting column (based on database)
        /// </summary>
        /// <value></value>
        [JsonProperty("sort")]
        [Required]
        public string Sort { get; set; }

        /// <summary>
        /// Sorting asc or desc
        /// </summary>
        /// <value></value>
        [JsonProperty("direction")]
        [Required]
        public String Direction { get; set; }

        [JsonProperty("pageIndex")]
        [Required]
        public Int32 PageIndex { get; set; }

        [JsonProperty("pageSize")]
        [Required]
        public Int32 PageSize { get; set; }
    }
}