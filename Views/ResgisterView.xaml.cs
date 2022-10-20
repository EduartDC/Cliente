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

             Player player = new Player();
             player.firstName = "Julio";
             player.lastName = "Lopez";
             player.email = "jl@gmail.com";
             player.userName = "jl12345";
             player.password = "1234";
             player.status = true;

             int result = client.AddPlayer(player);
             Console.WriteLine(result);
        }

        private void TextFirsName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
