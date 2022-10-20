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
using WCFCliente.MessageService;

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
            MessageService.UserManagerClient client = new MessageService.UserManagerClient();

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
            Player player = new Player();

            player.firstName = TextFirsName.Text;
            player.lastName = TextLastName.Text;
            player.email = TextEmail.Text;
            player.userName = TextUserName.Text;
            player.password = TextPassword.Password;
            player.status = true;

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

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            ResgisterView win = new ResgisterView();
            win.Visibility = Visibility.Collapsed;
            

        }
    }
}
