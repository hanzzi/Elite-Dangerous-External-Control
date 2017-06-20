using System;
using System.Collections.Generic;
using System.Linq;
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
        private string Hostname;
        private int Port;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleLanding()
        {

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
