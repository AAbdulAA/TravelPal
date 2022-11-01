using TravelPal.Enums;

namespace TravelPal.Classes
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }



        public void IUser(string usernname, string password, Countries location)
        {

        }
    }
}
