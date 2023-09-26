using System.ComponentModel.DataAnnotations;

namespace Op_WebAPI.Models
{
    public class csAttraction
    {
        [Key]       //EFC code first 
        public int AttractionId { get; set; }
        [Required]
        [MaxLength(100)]
        public string AttractionName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        //public List<csReview> Review { get; set; } = null;     //One Attraction has a list of Review 0-20 reviews
        //public List<csRating> Rating { get; set; } = null;     //One Attraction has a list of Rating 0-20 ratings

    }
}
