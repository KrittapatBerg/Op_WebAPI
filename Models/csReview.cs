using System.ComponentModel.DataAnnotations;

namespace Op_WebAPI.Models
{
    public class csReview
    {
        [Key]       //EFC code first
        public int ReviewId { get; set; }

        [MaxLength(200)]
        public string Review { get; set; } = string.Empty;
        public csUser User { get; set; }
        public int UserId { get; set; }
        public csAttraction Attraction { get; set; }
        public int AttractionId { get; set; } 
    }
}
