using TravelPal.Enum;

namespace TravelPal.Classes
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
    }
}
