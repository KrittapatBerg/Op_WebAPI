using Op_WebAPI.Data;

namespace Op_WebAPI.Models
{
    public class SeedGenerator //: Random  TO DO : random 
    {
        public static void SeedData(DataContext context) 
        {
            if (context.SightSeeings.Any()) 
            {

                // Seed data
                var attractions = new List<csAttraction>
                {
                new csAttraction { AttractionName = "Redwood Park", Category = "Park", Description = "A place where human connects to nature" },
                new csAttraction { AttractionName = "Bon Appetite", Category = "Restaurant", Description = "Two Michelin stars since 1990" },
                
                /*
                new csAttraction { AttractionName = "Slow Café", Category = "Café", Description = "Hip café for anyone" },
                new csAttraction { AttractionName = "Vasa Museum", Category = "Museum", Description = "A historical museum worth seeing" },
                new csAttraction { AttractionName = "Du Omo", Category = "Architecture", Description = "A wonder of a region" },
                new csAttraction { AttractionName = "Nian Gara", Category = "Waterfall", Description = "The biggest waterfall of this region" },
                new csAttraction { AttractionName = "White Beach", Category = "Beach", Description = "They call this white beach for a reason" },
                new csAttraction { AttractionName = "Cedar Wood", Category = "Forest", Description = "An amazing place to go camping" },
                new csAttraction { AttractionName = "Hotel California", Category = "Hotel", Description = "A very family-oriented hotel" }
                */
                };

                context.AddRange(attractions);
                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                var addresses = new List<csAddress>
                {
                    new csAddress { StreetName = "Flower Rd.", City = "Middle Korea", Zipcode = 20165, Country = "South Sea", AttractionId = 1 },
                    new csAddress { StreetName = "Snow street", City = "Westeros", Zipcode = 60521, Country = "North Sea", AttractionId = 2}
                };
                context.AddRange(addresses);
                context.SaveChanges();
            }
        }

    }
}
