using System.Collections.Generic;
using System.Linq;
using TravelPal.Enums;

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


        // Add User 
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

        // Remove User 
        public bool removeUser(User user)
        {
            if (Users.Any(x => x.Username == user.Username))
            {
                Users.Remove(user);
                return true;
            }
            return false;

        }

        // Username och password rätt längd 
        private bool ValidateUserName(string username, string password)
        {
            return username.Length > 20 || username.Length < 3 ? false : true;

        }
        private bool ValidateUserName(string password)
        {
            return password.Length > 20 || password.Length < 3 ? false : true;

        }
        public bool UserSignIn(string username, string password)
        {
            return true;
        }


    }
}
