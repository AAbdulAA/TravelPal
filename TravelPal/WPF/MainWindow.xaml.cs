using System.Windows;
using TravelPal.Classes;

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


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new RegisterWindow(userManager);
            registerWindow.Show();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // namn & password
            string username = txbUsername.Text;
            string password = pswPassword.Password;

            // bool över users 

            bool isFoundUSer = false;

            foreach (User user in userManager.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    isFoundUSer = true;

                    if (user is User)
                    {
                        Window travelsWindow = new TravelsWindow(userManager, user);
                        travelsWindow.Show();
                    }
                    else if (user is Admin)
                    {
                        Window travelswindow = new TravelsWindow(userManager, user);
                        travelswindow.Show();
                    }

                }
            }
            if (!isFoundUSer)
            {
                MessageBox.Show("your username or password is incorrect");
            }
            Close();
        }
    }
}
