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

        public Client(string ipAddress, int port)
        {
            InitializeComponent();
            Hostname = ipAddress;
            Port = port;
        }

        #region Commands

        // Syntax: 
        // COMMAND: Is the most basic keybinds built into Elite
        // SCRIPT: More advanced control not inherently built into Elite 

        private void ToggleGears()
        {
            SendCommand("COMMAND:Landing_Gear");
        }

        private void ToggleHPoints()
        {
            SendCommand("COMMAND:HardPoints");
        }

        private void RequestDocking()
        {
            SendCommand("SCRIPT:RequestDocking");
        }

        private void SilentRunning()
        {
            SendCommand("COMMAND:SilentRunning");
        }

        private void TargetFront()
        {
            SendCommand("COMMAND:TargetForward");
        }

        private void NextTarget()
        {
            SendCommand("COMMAND:NextTarget");
        }

        private void HighThreat()
        {
            SendCommand("COMMAND:HighThreat");
        }

        private void FrameShift()
        {
            SendCommand("COMMAND:FrameShift");
        }

        private void SubSystemNext()
        {
            SendCommand("COMMAND:SUBSYSNext");
        }

        private void SubSystemPrevious()
        {
            SendCommand("COMMAND:SUBSYSPrev");
        }

        private void DropHeatSink()
        {
            SendCommand("COMMAND:DropHeatSink");
        }

        private void ToggleLights()
        {
            SendCommand("COMMAND:ToggleLights");
        }

        private void SensorUP()
        {
            SendCommand("COMMAND:SensorUP");
        }

        private void SensorDOWN()
        {
            SendCommand("COMMAND:SensorDOWN");
        }

        private void PowerWeapons()
        {
            SendCommand("COMMAND:PowerWeapons");
        }

        private void PowerSystems()
        {
            SendCommand("COMMAND:PowerSystem");
        }

        private void PowerEngines()
        {
            SendCommand("COMMAND:PowerEngines");
        }

        private void PowerEqual()
        {
            SendCommand("COMMAND:PowerEqual");
        }

        private void ToggleScoop()
        {
            SendCommand("COMMAND:ToggleScoop");
        }

        private void OpenGalaxyMap()
        {
            SendCommand("COMMAND:OpenGalaxyMap");
        }

        #endregion

        private void SendCommand(string command)
        {
            TcpClient client = new TcpClient(Hostname, Port);
            
            client.WriteData(command);
            client.Close();
        }  


    }
}
