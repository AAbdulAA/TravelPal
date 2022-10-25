using System.Collections.Generic;
using System.Linq;
using TravelPal.Enum;

namespace TravelPal.Classes
{
    public class UserManager
    {
        public List<IUser> Users { get; set; }

        public IUser UserSignedIn { get; set; }

        public UserManager()
        {
            Users = new List<IUser>();
        }

        public bool AddUser(string username, string password, Countries country)
        {
            if (ValidateUserName(username))
            {
                User newUser = new User()
                {
                    Username = username,
                    Password = password,
                    Location = country
                };
                Users.Add(newUser);
                return true;
            }
            return false;
        }

        public bool removeUser(User user)
        {
            if (Users.Any(x => x.Username == user.Username))
            {
                Users.Remove(user);
                return true;
            }
            return false;

        }

        private bool ValidateUserName(string username)
        {
            return true;
        }
    }
}
