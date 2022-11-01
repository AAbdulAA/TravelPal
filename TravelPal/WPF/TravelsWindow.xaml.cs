using System.Windows;
using TravelPal.Classes;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;
        private User user;

        public TravelsWindow(UserManager userManager, User user)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.user = user;
            lbTravelsUserName.Content = user.Username;
        }


        private void btnTravelsUserDetails_Click(object sender, RoutedEventArgs e)
        {
            Window userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.Show();

        }

        private void btnTravelsAddTravel_Click(object sender, RoutedEventArgs e)
        {
            Window addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
        }
    }
}
