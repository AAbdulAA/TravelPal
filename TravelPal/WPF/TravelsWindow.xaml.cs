using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Classes;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private List<Travel> travels = new();
        private MainWindow _mainWindow;
        private UserManager userManager;
        private User _user;
        private Admin admin;
        private bool IsAdmin = false;
        private TravelManager travelManager;

        public TravelsWindow(UserManager userManager, IUser user)
        {
            InitializeComponent();
            this.userManager = userManager;
            lbTravelsUserName.Content = userManager.UserSignedIn.Username;

            if (userManager.UserSignedIn is User)
            {
                _user = (User)userManager.UserSignedIn;
                travels = _user.Travels;
                ShowTravels();

            }

            if (userManager.UserSignedIn is Admin)
            {
                btnTravelsAddTravel.IsEnabled = false;
                btnTravelsUserDetails.IsEnabled = false;
                admin = (Admin)user;
                lbTravelsUserName.Content = "Logged in as ADMIN";
                ShowTravels();
                IsAdmin = true;
            }

        }

        private void btnTravelsUserDetails_Click(object sender, RoutedEventArgs e)
        {
            // öppna user window
            Window userDetailsWindow = new UserDetailsWindow(userManager);
            userDetailsWindow.Show();
            Close();


        }

        private void btnTravelsAddTravel_Click(object sender, RoutedEventArgs e)
        {
            // öppna upp fönstret för att lägga till resa 
            Window addTravelWindow = new AddTravelWindow(_user, this);
            addTravelWindow.Show();
        }

        private void btnTravelsRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lwTravelsInfo.SelectedIndex is -1)
            {
                MessageBox.Show("Select a travel to remove first.");
                return;
            }

            Travel travelToRemove = travels[lwTravelsInfo.SelectedIndex];


            if (travelToRemove is Trip)
                travels.Remove((Trip)travelToRemove);
            else
                travels.Remove((Vacation)travelToRemove);

            ShowTravels();

        }

        private void btnTravelsDetails_Click(object sender, RoutedEventArgs e)
        {
            // öppna fönster travel Det om resa markeras i listView annars om inget är markerat ska varningsmeddalnde komma
            ListViewItem selectedItem = lwTravelsInfo.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, selectedTravel);
                travelDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Pick a travel to remove from the list please.");
            }

        }

        private void btnTravelsInfo_Click(object sender, RoutedEventArgs e)
        {
            // Föklaring till appens syfte 
            MessageBox.Show("This is an app made properly for you. Choose your destination from all the countries in the world. Safe travel");
        }

        private void btnTravelsSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Exit från fönstret, gå till Main

            userManager.UserSignedIn = null;
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        // Visa resemål i listan 
        public void ShowTravels()
        {

            lwTravelsInfo.Items.Clear();

            if (IsAdmin)
            {
                List<IUser> userList = this.userManager.Users.Where(x => x.GetType() == typeof(User)).ToList();
                foreach (User user in userList)
                {
                    foreach (Travel travel in user.Travels)
                    {
                        travels.Add(travel);
                        ListViewItem listViewItem = new();
                        listViewItem.Tag = travel;
                        listViewItem.Content = $"User: {user.Username} Trip: {travel.Destination} | Country: {travel.Country.ToString()} | Travelers: {travel.Travellers.ToString()}";
                        lwTravelsInfo.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                foreach (Travel t in travels)
                {
                    ListViewItem listViewItem = new();
                    listViewItem.Tag = t;
                    listViewItem.Content = $"Travel: {t.Destination} | Country: {t.Country.ToString()} | Travelers: {t.Travellers.ToString()}";
                    lwTravelsInfo.Items.Add(listViewItem);
                }
            }
        }


    }
}
