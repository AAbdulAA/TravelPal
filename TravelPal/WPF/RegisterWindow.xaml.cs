using System;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.WPF
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserManager userManager;

        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            cbCountrey.ItemsSource = Enum.GetValues(typeof(Countries));
            cbCountrey.SelectedIndex = 0;

        }

        // ------------ Lägg till detta ----------------
        // Om användarnamnet redan är upptaget ska ett varningsmeddelande visas
        private void btnRegisterRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string password = psbRegisterPassword.Password;
            string confirmPassword = psbRegisterConfirmPassword.Password;

            Countries country = (Countries)cbCountrey.SelectedIndex;

            this.userManager.AddUser(username, password, confirmPassword, country);
            if (txtRegisterUsername.Text == "" || psbRegisterPassword.Password == "")
            {
                // printa meddalande, kan ej stå tomt 
                MessageBox.Show("Please fill in all the fields correctly ");
                return;
            }

            this.userManager.AddUser(username, password, confirmPassword, country);
            MessageBox.Show("User is added", "Window");
            Close();
        }
    }
}
