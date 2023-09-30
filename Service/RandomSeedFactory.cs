using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Models;
using System;

namespace Op_WebAPI.Service
{
    public static class RandomSeedFactory
    {
        private static Random random = new Random();

        #region Attraction Generator 
        public static List<csAttraction> RandomAttraction(int amount)
        {
            var attractionList = new List<csAttraction>();

            for (int i = 0; i < amount; i++)
            {
                var result = new csAttraction
                {
                    AttractionName = RandomSeedFactory.GenerateAttraction(),
                    Category = RandomSeedFactory.GenerateCategory(),
                    Description = RandomSeedFactory.GenerateDescription(),
                    //Address = we do it later
                };
                attractionList.Add(result);
            }
            return attractionList;
        }
        private static string GenerateAttraction()
        {

            string[] _attractionName = "Sunshine Bay, Raiya Beach, Lego Land, Aquarium, Sea World, Niagara Fall, Redwood, Fancy Raw".Split(", ");
            string[] _category = "Park, Restaurant, Café, Museum, Architecture, Waterfall, Beach, Forest, Hotel".Split(", ");

            string ranAttract = _attractionName[random.Next(_attractionName.Length)];
            string seedAttract = ranAttract + random.Next(_category.Length);
            return seedAttract;
        }
        private static string GenerateCategory()
        {
            string[] _category = "Park, Restaurant, Café, Museum, Architecture, Waterfall, Beach, Forest, Hotel, Zoo, Aquarium, Bar, Amusement".Split(", ");
            string ranCat = _category[random.Next(_category.Length)];
            return ranCat;
        }
        private static string GenerateDescription()
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
        }
        #endregion

        #region Address Generator 
        public static List<csAddress> RandomAddress(int amount)
        {
            var addressList = new List<csAddress>();

            for (int i = 0; i < amount; i++)
            {
                var result = new csAddress
                {
                    StreetName = RandomSeedFactory.GenerateStreet(),
                    City = RandomSeedFactory.GenerateCity(),
                    Zipcode = RandomSeedFactory.GenerateZipcode(),
                    Country = RandomSeedFactory.GenerateCountry()
                    //Attraction, have to connect them 
                };
                addressList.Add(result);
            }
            return addressList;

        }
        private static string GenerateStreet()
        {
            string[] _streetName = "Flower Rd, Moon street, Ion Rd, Riverflow, st.Septon, Sun n Star street, Dark horse Rd, Rice field, Golden street, Jade Rd, st.Crow, Hyde Rd ".Split(", ");
            string randomStreet = _streetName[random.Next(_streetName.Length)];
            string seedStreet = randomStreet + random.Next(0, 909);
            return seedStreet;
        }
        private static string GenerateCity()
        {
            string[] _city = "New Sea, Black Sea, Dark Sea, Bright Sea, Star Sea, Old Sea, Blue Sea, North Sea, Iron Sea, Jade Sea, Golden Sea, Glow Sea, Glitten Sea".Split(", ");
            string seedCity = _city[random.Next(_city.Length)];
            return seedCity;
        }
        private static int GenerateZipcode()
        {
            int zipcode = random.Next(10110, 90990);
            return zipcode;
        }
        private static string GenerateCountry()
        {
            string[] _region = "High, Middle, South, Central, North, Ground, Gold, Black, Green, West, East".Split(", ");
            string[] _country =
            {
                "Tower, Korea, King's Landing, Casterly Rock, Sea, Winterfell, Highgarden, Sea, Dothraki, Carolina, Wakanda, Cairo, Birmingham, Downton Abbey, Wimbledon, Highland Gard, Asgard, Liberty "
            };
            string ranRegion = _region[random.Next(_region.Length)];
            string ranCountry = _country[random.Next(_country.Length)];
            string seedCountry = ranRegion + " " + ranCountry;
            return seedCountry;
        }
        #endregion

        #region User Generator
        public static List<csUser> RandomUser(int amount)
        {
            var userList = new List<csUser>();

            for (int i = 0; i < amount; i++)
            {
                var result = new csUser
                {
                    UserName = RandomSeedFactory.GenerateUserName(),
                    UserEmail = RandomSeedFactory.GenerateEmail()
                    //connect to Review and Rating later
                };
                userList.Add(result);
            }
            return userList; 
        }

        private static string GenerateUserName()
        {
            string[] _userName = "Joff, Jeff, Jim, Pam, Dwight, Steve, Stanley, Kitty, Jon, Tuna, Paul, Roger, Louis, Bryan, David, Rebecca, Clerance, Edward, Catniss".Split(", ");
            string randomName = _userName[random.Next(_userName.Length)];
            string uniqueUserName = randomName + random.Next(1, 51);
              //to ensure every name is unique 

            return uniqueUserName;
        }
        private static string GenerateEmail()
        {
            string[] domains = { "snow.com", "flower.com", "stone.com", "tower.com", "sea.com", "scranton.com", "air.com", "sand.com", "star.com" };
            string ranDomain = domains[random.Next(domains.Length)];
            string ranName = GenerateUserName();
            string uniqueEmail = $"{ranName}@{ranDomain}";
           
            return uniqueEmail;
        }
        #endregion

        #region Review Generator
        public static List<csReview> RandomReview(int amount)
        {
            var reviewList = new List<csReview>();

            for(int i = 0; i < amount; i++)
            {
                var result = new csReview
                {
                    Review = RandomSeedFactory.GenerateReview()
                    //connect to Attraction and User later 
                }; 
                if (random.Next(2) == 0) continue;
                reviewList.Add(result);
            }
            return reviewList; 
        }
        private static string GenerateReview()
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
        public static List<csRating> RandomRating(int amount)
        {
            var ratingList = new List<csRating>();

            for(int i = 0;i < amount; i++)
            {
                var result = new csRating
                {
                    Rating = RandomSeedFactory.GenerateRating()
                    //connect to User and Attraction later
                }; 
                ratingList.Add(result);
            }
            return ratingList;
        }
        private static int GenerateRating()
        {
            int rating = random.Next(1, 11);
            return rating;
        }
        #endregion 
    }
}
