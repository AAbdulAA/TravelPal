using System.Collections.Generic;
using TravelPal.Enum;

namespace TravelPal.Classes
{
    public class User : IUser
    {
        public List<Travel> Travels { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
    }
}
