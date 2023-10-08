using Op_WebAPI.Data;

namespace Op_WebAPI.Service
{
    public class Seed
    {
        private  int attractionAmount = 1000;
        private  int addressAmount = 100;
        private  int userAmount = 65;
        private  int reviewAmount = 40;

        public  void SeedData(DataContext context)
        {
            try
            {
                if (!context.SightSeeings.Any())
                {     // Seed data
                    var attractions = RandomSeedFactory.RandomAttraction(attractionAmount);
                  
                    context.AddRange(attractions);
                    context.SaveChanges();
                }             

                if(!context.Addresses.Any())
                {
                    var address = RandomSeedFactory.RandomAddress(addressAmount);
                    context.AddRange(address);
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    var users = RandomSeedFactory.RandomUser(userAmount);

                    context.AddRange(users);
                    context.SaveChanges();
                }

                if (!context.Reviews.Any())
                {
                    var reviews = RandomSeedFactory.RandomReview(reviewAmount);
             
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
