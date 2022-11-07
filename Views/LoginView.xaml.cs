using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WCFCliente.ConnectService;
using WCFCliente.Resources;

namespace WCFCliente.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ConnectService.UserManagerClient client = new ConnectService.UserManagerClient();

            String userName = textUserName.Text;
            String password = textPassword.Password.ToString();
          

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(Properties.Resources.messageBoxEmptyFields);
            }
            else
            {
                password = Accessories.sha256(password);
                validateCredentials(userName, password);
            }

            if (ValidateFields())
            {
                int result = client.ValidatePlayer(player);
                if (result == 0)
                {
                    MessageBox.Show("Error occurred, registration didn't take effect");
                }
                else
                {
                  
                    NavigationService.Navigate(new Uri("Views/InicioView.xaml", UriKind.Relative));
                }
                Console.WriteLine(result);
            }

        }

        private void validateCredentials(string userName, string password)
        {
            try
            {
                var playerProfile = playerProfileManagementClient.Login(username, password);
                if (playerProfile != null)
                {
                    playerProfileManagementClient.Close();
                    GoToMainMenu(playerProfile);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.CHECK_ENTERED_INFORMATION_LABEL,
                              Properties.Resources.INVALID_DATA_WINDOW_TITLE);
                    PasswordBox.Clear();
                }
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show(Properties.Resources.TRY_AGAIN_LATER_LABEL,
                    Properties.Resources.NO_SERVER_CONNECTION_WINDOW_TITLE);
                Close();
            }
        }

        private void textUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textUserName.Text.Equals("") || !textUserName.Text.Equals(null))
            {
                lblExampleUserName.Visibility = Visibility.Hidden;
            }
        }

        private void textUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textUserName.Text.Equals("") || textUserName.Text.Equals(null))
            {
                lblExampleUserName.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textUserName.Text.Equals("") || textUserName.Text.Equals(null))
            {
                lblExamplePassword.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textUserName.Text.Equals("") || !textUserName.Text.Equals(null))
            {
                lblExamplePassword.Visibility = Visibility.Hidden;
            }
        }

        public bool ValidateFields()
        {
            bool result = false;
            if (textUserName.Equals("") || textUserName.Equals(null) || 
                textPassword.Equals("") || textPassword.Equals(null))
            {
                MessageBox.Show("An empty field was detected, to continue you must fill all text fields.");
            }
            else
            {
                result = true;
            }
            return result;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("Views/RegisterView.xaml", UriKind.Relative));

        }
    }
}
