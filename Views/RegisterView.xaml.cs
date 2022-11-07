using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFCliente.ConnectService;

namespace WCFCliente.Views
{
    /// <summary>
    /// Interaction logic for ResgisterView.xaml    
    public partial class RegisterView : Page
    {
        
        public void Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            ConnectService.UserManagerClient client = new ConnectService.UserManagerClient();

            Player player = PlayerData();
            if (ValidateFields())
            {
                int result = client.AddPlayer(player);

                if (result == 0)
                {
                    MessageBox.Show("Error occurred, registration didn't take effect");
                }
                else
                {
                    MessageBox.Show("Successful registration.");
                }
                
            }


        }

        private Player PlayerData()
        {
            Player player = new Player
            {
                firstName = TextFirsName.Text,
                lastName = TextLastName.Text,
                email = TextEmail.Text,
                userName = TextUserName.Text,
                password = TextPassword.Password,
                status = true
            };

            return player;
        }
        
        public bool ValidateFields()
        {
            bool result = false;
            if (TextFirsName.Text.Length <= 0 || TextLastName.Text.Length <= 0 || TextEmail.Text.Length <= 0 ||
                TextUserName.Text.Length <= 0 || TextPassword.Password.Length <= 0)
            {
                MessageBox.Show("An empty field was detected, to continue you must fill all text fields.");
            }
            else
            {
                result = true;
            }
            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("Views/LoginView.xaml", UriKind.Relative));

        }

        private void TextFirsName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!TextFirsName.Text.Equals("") || !TextFirsName.Text.Equals(null))
            {
                lblExampleFirstName.Visibility = Visibility.Hidden;
            }
        }

        private void TextFirsName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextFirsName.Text.Equals("") || TextFirsName.Text.Equals(null))
            {
                lblExampleFirstName.Visibility = Visibility.Visible;
            }
        }

        private void TextLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextLastName.Text.Equals("") || TextLastName.Text.Equals(null))
            {
                lblExampleLastName.Visibility = Visibility.Visible;
            }
        }

        private void TextLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!TextLastName.Text.Equals("") || !TextLastName.Text.Equals(null))
            {
                lblExampleLastName.Visibility = Visibility.Hidden;
            }
        }

        private void TextEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!TextEmail.Text.Equals("") || !TextEmail.Text.Equals(null))
            {
                lblExampleEmail.Visibility = Visibility.Hidden;
            }
        }

        private void TextEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextEmail.Text.Equals("") || TextEmail.Text.Equals(null))
            {
                lblExampleEmail.Visibility = Visibility.Visible;
            }
        }

        private void TextUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!TextUserName.Text.Equals("") || !TextUserName.Text.Equals(null))
            {
                lblExampleUser.Visibility = Visibility.Hidden;
            }
        }

        private void TextUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextUserName.Text.Equals("") || TextUserName.Text.Equals(null))
            {
                lblExampleUser.Visibility = Visibility.Visible;
            }
        }
        
    }
}
