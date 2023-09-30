using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Op_WebAPI.Models
{
    public class csReview
    {
        [Key]       //EFC code first
        public int ReviewId { get; set; }

        [MaxLength(200)]
        public string Review { get; set; } = string.Empty;
       
        [JsonIgnore]
        public csAttraction Attraction { get; set; } = null;
        public int AttractionId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public csUser User { get; set; } = null!;
    }
}
