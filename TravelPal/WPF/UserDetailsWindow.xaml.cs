using System;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        private IUser user;

        public UserDetailsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            cmbUserDetailsCountrey.ItemsSource = Enum.GetValues(typeof(Countries));
            cmbUserDetailsCountrey.SelectedIndex = 0;


            //txtUserDetailsUsername.Text = userManager.UserSignedIn.Username;
            //LoadUserUI();
        }

        //private void LoadUserUI()
        //{
        //    txtUserDetailsUsername.Text = userManager.UserSignedIn.Username;
        //}


        // Spara ny user,.... öppna travelswindow
        private void btnUserDetailsSave_Click(object sender, RoutedEventArgs e)
        {
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cmbUserDetailsCountrey.SelectedItem.ToString());

            if (userManager.CheckUserLenght(txtUserDetailsUsername.Text) && userManager.ValidateUsername(txtUserDetailsUsername.Text) && userManager.ConfirmNewPassword(txtUserDetailsNewPassword.Text, txtUserDetailsConfirmPassword.Text) && userManager.CheckNewPasswordLength(txtUserDetailsNewPassword.Text))
            {
                userManager.UserSignedIn.Username = txtUserDetailsUsername.Text;
                userManager.UserSignedIn.Password = txtUserDetailsNewPassword.Text;
            }
            else
            {
                return;
            }

            userManager.UserSignedIn.Location = selectedCountry;

            TravelsWindow travelsWindow = new(userManager, user);

            travelsWindow.Show();

            Close();



        }

        private void cmbUserDetailsCountrey_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnUserDetailsCancel_Click(object sender, RoutedEventArgs e)
        {
            user = userManager.UserSignedIn;

            TravelsWindow travelsWindow = new(userManager, user);

            travelsWindow.Show();

            Close();
        }
    }
}
