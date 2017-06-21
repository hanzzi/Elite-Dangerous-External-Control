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
using TCP_Client_and_Server;

namespace Elite_Dangerous_Touch_Server
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private string Hostname;
        private int Port;

        public Client()
        {
            InitializeComponent();
        }

        private void ToggleLanding()
        {
            SendCommand("COMMAND:Landing_Gear");
        }

        private void ToggleHPoints()
        {
            SendCommand("COMMAND:HardPoints");
        }

        private void RequestDocking()
        {
            SendCommand("COMMAND:RequestDocking");
        }

        private void ChangeNetworkConfig()
        {
            Hostname = "INSERTHOSTNAMETEXTBOXHERE";
            Port = 010101;
        }

        private void SendCommand(string command)
        {
            TcpClient client = new TcpClient(Hostname, Port);
            
            client.WriteData(command);
            client.Close();
        }


    }
}
