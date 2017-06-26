using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
using TCP_Client_and_Server;


namespace Elite_Dangerous_Touch_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShipControlButton_Click(object sender, RoutedEventArgs e)
        {
            IPSetup ip = new IPSetup();
            ip.Owner = this;
            ip.Show();
        }

        private void CTRL_Reciever_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
