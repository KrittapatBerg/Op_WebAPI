using Op_WebAPI.Data;

namespace Op_WebAPI.Service
{
    public class Seed
    {
        private  int attractionAmount = 10;
        private static int addressAmount = 10;
        private static int userAmount = 5;
        private static int reviewAmount = 5;

        public static void SeedData(DataContext context)
        {
            try
            {
                //skapa en code som lägg in address och alla detaljer i varje attraction som är skapas 
                if (!context.SightSeeings.Any())
                {

                    // Seed data
                    var attractions = RandomSeedFactory.RandomAttraction(attractionAmount);
                    var addresss = RandomSeedFactory.RandomAddress(attractionAmount);
                    var user = RandomSeedFactory.RandomReview(attractionAmount);
                    for (int i = 0; i < attractions.Count; i++)
                    {
                        attractions[i].Address = addresss[i];
                        //attractions[i].Review = user[i]; 
                    }
                    //for (int i = 0;i < attractions.Count; i++)
                    //{
                    //}

                    /*
                    {
                    new csAttraction { AttractionName = "Redwood Park", Category = "Park", Description = "A place where human connects to nature" },  // 1
                    new csAttraction { AttractionName = "Bon Appetite", Category = "Restaurant", Description = "Two Michelin stars since 1990" },     // 2
                
                    new csAttraction { AttractionName = "Slow Café", Category = "Café", Description = "Hip café for anyone" },
                    new csAttraction { AttractionName = "Vasa Museum", Category = "Museum", Description = "A historical museum worth seeing" },
                    new csAttraction { AttractionName = "Du Omo", Category = "Architecture", Description = "A wonder of a region" },
                    new csAttraction { AttractionName = "Nian Gara", Category = "Waterfall", Description = "The biggest waterfall of this region" },
                    new csAttraction { AttractionName = "White Beach", Category = "Beach", Description = "They call this white beach for a reason" },
                    new csAttraction { AttractionName = "Cedar Wood", Category = "Forest", Description = "An amazing place to go camping" },
                    new csAttraction { AttractionName = "Hotel California", Category = "Hotel", Description = "A very family-oriented hotel" }
                    };
                    */

                    context.AddRange(attractions);
                    context.SaveChanges();
                }



                if (context.Addresses.Any())
                {
                    var addresses = RandomSeedFactory.RandomAddress(addressAmount);

                    context.AddRange(addresses);
                    context.SaveChanges();
                }

                if (context.Users.Any())
                {
                    //skapa en remove seed som ta bort seed varje gång innan seed kan seeda igen

                    var users = RandomSeedFactory.RandomUser(userAmount);

                    /*{
                        new csUser { UserName = "Jon86", UserEmail = "jon.86@snow.com" },   //user1
                        new csUser { UserName = "Zen" }                                     //user2
                    };*/

                    context.AddRange(users);
                    context.SaveChanges();
                }

                if (context.Reviews.Any())
                {
                    var reviews = RandomSeedFactory.RandomReview(reviewAmount);

                    /*{
                        new csReview { Review = "It was an amazing restaurant. Book your table like 8 months ahead though. ", UserId = 2, AttractionId = 2 },
                        new csReview { Review = "We go camping/ hiking there at least once a year. Great place, man!", UserId = 1, AttractionId = 1 }
                    };*/
                    context.AddRange(reviews);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
