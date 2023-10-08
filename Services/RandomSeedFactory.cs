using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Models;
using System;
using System.Runtime.CompilerServices;

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
                };
                attractionList.Add(result);
            }
            return attractionList;
        }
        private static string GenerateAttraction()
        {
            string[] _attractionName = ("Sunshine, Bay, Raiya Beach, Lego, Land, Aquarium, Sea, World, Niagara, Fall, Redwood, Fancy Raw, " +
                "Dragon, Rainbow, Miyamoto, Aspen, Highland, Dinausaur, Frozen, Beauty, Arrival, AutoBahn, Bonsai, Fuji, " +
                "History, Unicorn, Dalai, Youth, Mystery, Downton, Jumanji, Mars, Planet, Natural, Plastic, Jam, Space, Loiter, " +
                "Toy, Story, Sunset, Bangle, Beagle, Beatles, Lady, Statue, Curve, Science, Discovery, Animal, Wonder, Pyramid ").Split(", ");

            string seedAttract = _attractionName[random.Next(0, _attractionName.Length)] + " " + _attractionName[random.Next(0, _attractionName.Length)];
            return seedAttract;
        }
        private static string GenerateCategory()
        {
            string[] _category = ("Park, Restaurant, Café, Museum, Architecture, Waterfall, Beach, Forest, Hotel, Zoo, Aquarium, Bar, Amusement, Mountain").Split(", ");
            string ranCat = _category[random.Next(_category.Length)];
            return ranCat; 
        }
        private static string GenerateDescription()
        {
            string[] _description =
            {
                   "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod. ",
                   "Sensational place to be with family and friends.",
                "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam. ",
                "This destination delivers a great moment to any visitors",
                "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ",
                "Popular vote 10 years in a row.",
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat. ",
                "One of top destinations of the country",
                "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui. ",
                "Memorable and magical moment starts here...", 
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
                    Country = RandomSeedFactory.GenerateCountry(),
                    AttractionId = i + 1 
                };
                addressList.Add(result);
            }
            return addressList;

        }
        private static string GenerateStreet()
        {
            string[] _streetName = ("Flower Rd, Moon street, Ion Rd, Riverflow, st.Septon, Sun n Star street, Dark horse Rd, Rice field, Golden street, Jade Rd, st.Crow, Hyde Rd ").Split(", ");
            string seedStreet = _streetName[random.Next(0, _streetName.Length)] + " " + random.Next(0, 909);
            return seedStreet;
        }
        private static string GenerateCity()
        {
            string[] _region = ("Middle, South, Central, North, Gold, Black, Green, West, East, Dark, Bright, Star, Ancient, Blue, Iron, Ion, Jade, Golden, Glow, Sparkling, New ").Split(", ");
            string[] _city = ("Sea, Tower, Sand, Garden, Flower, Snow, Leaf, Stone, Brick, Water, Star, Storm, Ryder, Everest, Grass, Land ").Split(", ");

            string seedCity = _region[random.Next(_region.Length)]  + " " + _city[random.Next(_city.Length)];
            return seedCity;
        }
        private static int GenerateZipcode()
        {
            int zipcode = random.Next(10110, 90990);
            return zipcode;
        }
        private static string GenerateCountry()
        {
            string[] _country = ("High Tower, King's Landing, Casterly Rock, Winterfell, Highgarden, Dothraki, Wakanda, Downton Abbey, Highland, Asgard, Liberty Land").Split(", ");
            
            string seedCountry = _country[random.Next(0, _country.Length)];
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
                };
                userList.Add(result);
            }
            return userList; 
        }

        private static string GenerateUserName()
        {
            string[] _userName = ("Joff, Jeff, Jim, Pam, Dwight, Steve, Stanley, Kitty, Jon, Tuna, Paul, Roger, Louis, Bryan, David, Rebecca, Clerance, Edward, Catniss").Split(", ");
            string uniqueUserName = _userName[random.Next(0,_userName.Length)] + random.Next(1, 51);
            return uniqueUserName;
        }
        private static string GenerateEmail()
        {
            string[] domains = {"snow.com", "flower.com", "stone.com", "tower.com", "sea.com", "scranton.com", "air.com", "sand.com", "star.com" };
            string ranDomain = domains[random.Next(domains.Length)];
            string ranName = GenerateUserName();
            string uniqueEmail = $"{ranName}@{ranDomain}";
           
            return uniqueEmail;
        }
        #endregion

        #region Review Generator
        public static List<csReview> RandomReview(int amount, int usercount)
        {
            var reviewList = new List<csReview>();

            for(int i = 0; i < amount; i++)
            {
                var result = new csReview
                {
                    Review = RandomSeedFactory.GenerateReview(),
                    UserId = random.Next(1, usercount),
                    AttractionId = i + 1
                }; 
                reviewList.Add(result);
            }
            return reviewList; 
        }
        private static string GenerateReview()
        {
            string[] _review =
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ",
                "There're plenty of place like this but cheaper",
                "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam ",
                "Overhyped",
                "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ",
                "Anything you expected and a little bit more.",
                "Meh...",
                "Worth the price.",
                "High standard",
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat ",
                "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui ",
                "It was a dream",
                "officia deserunt mollit anim id est laborum.",
                "It was an amazing place. Check it out!",
                "We come here regularly, highly recommend."
            };
            string ranReview = _review[random.Next(0, _review.Length)];
            
            return ranReview;
        }
        #endregion
    }
}
