using Models;
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

        public csAddress Seed(csSeedGenerator sGen)
        {
            var test = new csAddress()
            {
                AddressId = 5,
                StreetName = sGen.PetName,
                City = sGen.Country,
                Zipcode = sGen.Next(10100, 90900),
                Country = sGen.Country,
                AttractionId = 4
            };
            return test;
        }
    }
}
