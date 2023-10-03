using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Op_WebAPI.Models
{
    public class csUser
    {
        [Key]       //EFC code first 
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(100)]
        public string? UserEmail { get; set; }
      
        public List<csReview> Reviews { get; set; } = new List<csReview>();

    }
}
