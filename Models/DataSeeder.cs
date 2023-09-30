using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Op_WebAPI.Data;


namespace Op_WebAPI.Models
{
    public class DataSeeder
    {
        private readonly DataContext _context;
        private readonly Random random = new Random();
        public DataSeeder(DataContext context)
        {
            _context = context;
        }

        public void SeedDatabase(int nrOfAttractions, int nrOfAddresses, int nrOfUsers, int nrOfReviews,  int nrOfRatings)
        {
            SeedAttractions(nrOfAttractions);
            SeedAddresses(nrOfAddresses);
            SeedUsers(nrOfUsers);
            SeedReviews(nrOfReviews); 
            SeedRatings(nrOfRatings);
        }

        public void SeedAttractions(int nrOfAttractions)
        {
            for (int i = 0; i < nrOfAttractions; i++)
            {
                var attract = new csAttraction
                {
                    AttractionName = GenerateName(),
                    Category = GenerateCategory(),
                    Description = GenerateDescription()
                };

                _context.SightSeeings.Add(attract);
            }
            _context.SaveChanges();
        }

        #region Attraction generator 
        private string GenerateName()
        {

            string[] _attractionName = "Sunshine Bay, Raiya Beach, Lego Land, Aquarium, Sea World, Niagara Fall, Redwood, Fancy Raw".Split(", ");
            string[] _category = "Park, Restaurant, Café, Museum, Architecture, Waterfall, Beach, Forest, Hotel".Split(", ");

            string ranAttract = _attractionName[random.Next(_attractionName.Length)];
            string seedAttract = ranAttract + random.Next(_category.Length);
            return seedAttract;
        }
        private string GenerateCategory()
        {
            string[] _category = "Park, Restaurant, Café, Museum, Architecture, Waterfall, Beach, Forest, Hotel, Zoo, Aquarium, Bar, Amusement".Split(", ");
            string ranCat = _category[random.Next(_category.Length)];   
            return ranCat;
        }

        private string GenerateDescription()
        {
            string[] _description =
            {
                   "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ", 
                "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, ", 
                "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", 
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat ", 
                "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui ", 
                "officia deserunt mollit anim id est laborum."
            };

            string ranDescript = _description[random.Next(_description.Length)];
            return ranDescript;
            //public string Attraction => _attractionName[Next(0, _attractionName.Length)];
            //public string Category => _category[Next(0, _category.Length)];
            //public string Description => _description[Next(0, _description.Length)];
        }
        #endregion

        #region Address Generator 
        public void SeedAddresses(int nrOfAddresses)
        {
            for (int i = 0; i < nrOfAddresses; i++)
            {
                var address2 = new csAddress
                {
                    AddressId = i,
                    StreetName = GenerateStreet(),
                    City = GenerateCity(),
                    Zipcode = GenerateZipcode(),
                    Country = GenerateCountry()
                }; 
                _context.Addresses.Add(address2);
            }
            _context.SaveChanges();
        }
        private string GenerateStreet()
        {
            string[] _streetName = "Flower Rd, Moon street, Ion Rd, Riverflow, st.Septon, Sun n Star street, Dark horse Rd, Rice field, Golden street, Jade Rd, st.Crow, Hyde Rd ".Split(", ");
            string randomStreet = _streetName[random.Next(_streetName.Length)];
            string seedStreet = randomStreet + random.Next(0, 909);
            return seedStreet;
        }
        private string GenerateCity()
        {
            string[] _city = "New Sea, Black Sea, Dark Sea, Bright Sea, Star Sea, Old Sea, Blue Sea, North Sea, Iron Sea, Jade Sea, Golden Sea, Glow Sea, Glitten Sea".Split(", ");
            string seedCity = _city[random.Next(_city.Length)];
            return seedCity; 
        }
        private int GenerateZipcode()
        {
            int zipcode = random.Next(10110, 90990);
            return zipcode; 
        }

        private string GenerateCountry()
        {
            string[] _region = "High, Middle, South, Central, North, Ground, Gold, Black, Green, West, East".Split(", ");
            string[] _country =
            {
                "Tower, Korea, King's Landing, Casterly Rock, Sea, Winterfell, Highgarden, Sea, Dothraki, Carolina, Wakanda, Cairo, Birmingham, Downton Abbey, Wimbledon, Highland Gard, Asgard, Liberty "
            };
            string ranRegion = _region[random.Next(_region.Length)];
            string ranCountry = _country[random.Next(_country.Length)]; 
            string seedCountry = ranRegion + ranCountry;
            return seedCountry;   
        }
        #endregion

        #region User Generator 
        public void SeedUsers(int nrOfUsers)
        {
            for(int i = 0;i < nrOfUsers;i++)
            {
                var user2 = new csUser
                {
                    UserName = GenerateUserName(),
                    UserEmail = GenerateUserEmail()
                }; 
                _context.Users.Add(user2);
            }
                _context.SaveChanges();
        }
        private string GenerateUserName()
        {
            string[] _userName = "Joff, Jeff, Jim, Pam, Dwight, Steve, Stanley".Split(",");
            string randomName;
            string uniqueUserName; 
            do
            {
                randomName = _userName[random.Next(_userName.Length)];
                uniqueUserName = randomName + random.Next(50);
            }
            while (_context.Users.Any(u => u.UserName == uniqueUserName));         //to ensure every name is unique 

            return uniqueUserName; 
        }
        private string GenerateUserEmail()
        {
            string[] domains = { "snow.com", "flower.com", "stone.com", "tower.com", "sea.com", "wind.com", "air.com", "sand.com", "star.com" };
            string ranDomain;
            string ranName;
            string uniqueEmail;
            do
            {
                ranDomain = domains[random.Next(domains.Length)];
                ranName = GenerateName();
                uniqueEmail = $"{ranName}@{ranDomain}"; 
            }
            while (_context.Users.Any(u => u.UserEmail == uniqueEmail));

            return uniqueEmail; 
        }
        #endregion

        #region Review Generator 
        public void SeedReviews(int nrOfReviews)
        {
            for (int i = 0; i < nrOfReviews;i++)
            {
                var review = new csReview
                {
                    Review = GenerateReview(),
                };

                if (random.Next(2) == 0) continue;              //some attraction don't have reviews 
                _context.Reviews.Add(review);
            }
            _context.SaveChanges(); 
        }
        private string GenerateReview()
        {
            string[] _review =
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ",
                "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, ",
                "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ",
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat ",
                "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui ",
                "officia deserunt mollit anim id est laborum."
            };
            string ranReview = _review[random.Next(_review.Length)];      
            return ranReview;
        }
        #endregion

        #region Rating Generator 
        public void SeedRatings(int nrOfRatings)
        {
            for(int i = 0;i < nrOfRatings;i++)
            {
                var rating = new csRating
                {
                    RatingId = i,
                    Rating = GenerateRating()
                };
                _context.Ratings.Add(rating);
            }
            _context.SaveChanges(); 
        }
        private int GenerateRating()
        {
            int rating = random.Next(1, 11);
            return rating;
        }
        #endregion
    }

    /*
    [TestClass]
    public class DataSeederTests
    {
        [TestMethod]
        public void SeedAttractions_ShouldSeedData()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
            using (var dbContext = new DataContext(options))
            {
                var dataSeeder = new DataSeeder(dbContext);
                dataSeeder.SeedAttractions(5);
                Assert.AreEqual(5, dbContext.SightSeeings.Count()); 
            }
        }
    }*/
}
