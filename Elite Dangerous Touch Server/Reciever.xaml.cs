using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Elite_Dangerous_Touch_Server
{
    /// <summary>
    /// Interaction logic for Reciever.xaml
    /// </summary>
    public partial class Reciever : Window
    {
        private TCP_Client_and_Server.TcpServer Server;

        public Reciever()
        {
            InitializeComponent();
        }

        private void init()
        {
            Server = new TCP_Client_and_Server.TcpServer(IPAddress.Any, 0);
        }

        private void LoopListen()
        {
            Server.SetupConnection();

             ConsoleView.Items.Add(Server.RecieveData());

            // Recursion BEEIIIATCH
            LoopListen();
        }

        private void DoCommand()
        {
             
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ConsoleView.Items.Add("Wank");
        }
    }
}
