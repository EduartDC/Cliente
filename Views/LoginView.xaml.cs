using System;
using System.Collections.Generic;
using System.Linq;
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

            Player player = new Player
            {                
                userName = textUserName.Text,
                password = textPassword.Password
            };

            if (ValidateFields())
            {
                int result = client.ValidatePlayer(player);
                if (result == 0)
                {
                    MessageBox.Show("Error occurred, registration didn't take effect");
                }
                else
                {
                    MessageBox.Show("Welcome to 100 Mexicanos Dijeron!");
                }
                Console.WriteLine(result);
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

            MainWindow mainWindow= new MainWindow();
            mainWindow.Contenedor.NavigationService.Navigate(new RegisterView());
            
        }
    }
}
