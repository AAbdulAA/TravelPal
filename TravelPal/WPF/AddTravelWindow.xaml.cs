﻿using System;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private readonly User user;
        private readonly TravelsWindow travelsWindow;


        public AddTravelWindow(User user, TravelsWindow travelsWindow)
        {
            InitializeComponent();
            this.user = user;
            this.travelsWindow = travelsWindow;
            cbAddTravelCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            cbAddTravelCountry.SelectedIndex = 0;
            cbAddTravelTravel.SelectedIndex = 0;
            cbxAddTravelAllInclusive.Visibility = Visibility.Visible;
            lblAddTravelTrpType.Visibility = Visibility.Hidden;
            cbAddTravelTripType.Visibility = Visibility.Hidden;
            cbAddTravelTripType.ItemsSource = Enum.GetValues(typeof(TripTypes));
            cbAddTravelTripType.SelectedIndex = 0;
        }

        // lägg till resa 
        private void btnAddTravelAdd_Click(object sender, RoutedEventArgs e)
        {
            string destination = tbAddTravelDestination.Text;
            Countries country = (Countries)cbAddTravelCountry.SelectedIndex;

            if (cbAddTravelTravel.SelectedIndex == 0)
            {
                bool allInclusive = (bool)cbxAddTravelAllInclusive.IsChecked;
                bool isInt = int.TryParse(tbAddTravelTravelers.Text, out int travelers);

                if (!isInt)
                {
                    MessageBox.Show("You must enter a number in travelers", "Error");
                    return;
                }

                Vacation travel = new(allInclusive, destination, country, travelers);
                user.Travels.Add(travel);
                travelsWindow.Show();
                travelsWindow.ShowTravels();
                Close();
            }
            else
            {
                TripTypes tripType = (TripTypes)cbAddTravelTripType.SelectedIndex;
                int travelers = int.Parse(tbAddTravelTravelers.Text);

                Trip travel = new(tripType, destination, country, travelers);
                user.Travels.Add(travel);
                travelsWindow.Show();
                travelsWindow.ShowTravels();
                Close();
            }

        }

        // stäng fönster Add travel
        private void btnAddTravelExit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        // visa lista over trips när det behövs 
        private void cbAddTravel_DropDownClosed(object sender, EventArgs e)
        {

            if (cbAddTravelTravel.SelectedIndex == 1)
            {
                cbxAddTravelAllInclusive.Visibility = Visibility.Hidden;
                lblAddTravelTrpType.Visibility = Visibility.Visible;
                cbAddTravelTripType.Visibility = Visibility.Visible;
            }
            else
            {
                cbxAddTravelAllInclusive.Visibility = Visibility.Visible;
                lblAddTravelTrpType.Visibility = Visibility.Hidden;
                cbAddTravelTripType.Visibility = Visibility.Hidden;
            }
        }
    }
}
