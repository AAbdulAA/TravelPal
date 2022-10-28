using System.Windows;
using TravelPal.Classes;
using TravelPal.Enum;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserManager _userManager;

        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            _userManager = userManager;
            //cbCountrey.ItemsSource = Enum.GetValues(typeof(Countries));
            //cbCountrey.SelectedIndex = 0;   
        }

        private void btnRegisterRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;

            Countries country = (Countries)cbCountrey.SelectedIndex;

            _userManager.AddUser(username, password, country);

            MessageBox.Show("User is added", "Window");
            Close();
        }
    }
}
