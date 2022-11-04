using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // new list usermanager 
        private UserManager userManager = new();


        public MainWindow()
        {
            InitializeComponent();
            User userGandalf = new("Gandalf", "password", Countries.Sweden);
            userGandalf.Travels.Add(new Trip(TripTypes.Work, "Malmö", Countries.Albania, 7));
            userGandalf.Travels.Add(new Vacation(true, "Istanbul", Countries.Turkey, 17));
            userManager.Users.Add(userGandalf);
        }

        // öppna upp registerwindow 
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new RegisterWindow(userManager);
            registerWindow.Show();
        }

        // Signa in användare 
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // namn & password
            string username = txbUsername.Text;
            string password = pswPassword.Password;
            string confirmPassword = pswConfirmPassword.Password;

            // bool över users 

            bool isFoundUSer = false;

            foreach (IUser user in userManager.Users)
            {
                if (user.Username == username && user.Password == password && user.Password == confirmPassword)
                {
                    isFoundUSer = true;
                    userManager.UserSignedIn = user;

                    if (user is User)
                    {
                        TravelsWindow travelsWindow = new(userManager, (User)user);
                        travelsWindow.Show();
                        Hide();
                        break;
                    }
                    else if (user is Admin)
                    {
                        TravelsWindow travelswindow = new(userManager, (Admin)user);
                        travelswindow.Show();
                        Hide();
                        break;
                    }


                }
            }
            if (!isFoundUSer)
            {
                MessageBox.Show("your username or password is incorrect");
                return;
            }
        }
    }
}
