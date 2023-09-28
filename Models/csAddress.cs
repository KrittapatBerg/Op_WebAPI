using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Op_WebAPI.Models
{
    public class csAddress
    {
        [Key]       //EFC Code first
        public int AddressId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(10)]
        public int Zipcode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;

        public int AttractionId { get; set; }
        [JsonIgnore]
        public csAttraction Attraction { get; set; }
    }
}
