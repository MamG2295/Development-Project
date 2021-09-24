using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Interview.Web.Models
{
    public class Categories
    {
        [JsonPropertyName("instance_id")]
        public int InstanceID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("created_timestamp")]
        public DateTime CreatedTimestamp { get; set; }
       
    }
}
