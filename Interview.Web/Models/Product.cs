using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Interview.Web.Models
{
    [Serializable]
    public class Product
    {
        [JsonPropertyName("product_image_uris")]
        public string ProductImageUris { get; set; }
        [JsonPropertyName("valid_skus")]
        public string ValidSkus { get; set; }       
        [JsonPropertyName("instance_id")]
        public int? InstanceId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("created_timestamp")]
        public DateTime CreatedTimestamp { get; set; }

    } 
}
