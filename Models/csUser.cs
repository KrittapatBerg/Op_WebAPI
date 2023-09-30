using Microsoft.Extensions.Hosting;
using Op_WebAPI.Models;
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


        //public List<csRating> Ratings { get; set;} 

        //public csUser Seed(csSeedGenerator sGen)
        //{
        //    var user1 = new csUser
        //    {
        //        UserName = sGen.FirstName,
        //        UserEmail = sGen.Email(),
               
        //    };
        //    return user1;
        //}
    }
}
