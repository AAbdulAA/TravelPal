using System.Windows;
using TravelPal.Classes;
using TravelPal.WPF;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;
        private User user;

        public TravelsWindow()
        {
            InitializeComponent();
        }

        public TravelsWindow(UserManager userManager, User user)
        {
            this.userManager = userManager;
            this.user = user;
        }

        private void btnTravelsUserDetails_Click(object sender, RoutedEventArgs e)
        {
            Window userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.Show();

        }

        private void btnTravelsAddTravel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
