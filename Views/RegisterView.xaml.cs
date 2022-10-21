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
    /// </summary>
    public partial class ResgisterView : Page
    {
        
        public ResgisterView()
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
                Console.WriteLine(result);
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

            

        }
    }
}
