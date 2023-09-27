using System.ComponentModel.DataAnnotations;

namespace Op_WebAPI.Models
{
    public class csRating
    {
        [Key]       //EFC code first
        public int RatingId { get; set; }

        [MaxLength(3)]
        public int Rating { get; set; }
        public csUser User { get; set; }
        public int  UserId { get; set; }
        public csAttraction Attraction { get; set; }
        public int AttractionId { get; set; } 
    }
}
