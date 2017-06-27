using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for IPSetup.xaml
    /// </summary>
    public partial class IPSetup : Window
    {
        private bool IsFirstRun = true;

        public IPSetup()
        {
            InitializeComponent();
            IpBox1.Focus();
            IpBox1.SelectAll();
        }

        private IPAddress BuildIpAdress()
        {
            IPAddress addr = IPAddress.Parse($"{IpBox1.Text}.{IpBox2.Text}.{IpBox3.Text}.{IpBox4.Text}");

            return addr;
        }

        private void IpAddressTextBoxHandler1(object sender, TextChangedEventArgs e)
        {
            if (IsFirstRun)
                return;
            // When the textbox reaches a length of 3 the focus is changed to the next textbox to the right to ease usability.
            TextBox currentTextbox = sender as TextBox;
            if (currentTextbox.Text.Length == 3)
            {
                IpBox2.Focus();
                IpBox2.SelectAll();
            }
        }

        private void IpAddressTextBoxHandler2(object sender, TextChangedEventArgs e)
        {
            if (IsFirstRun)
                return;

            TextBox currentTextbox = sender as TextBox;
            if (currentTextbox.Text.Length == 3)
            {
                IpBox3.Focus();
                IpBox3.SelectAll();
            }
        }

        private void IpAddressTextBoxHandler3(object sender, TextChangedEventArgs e)
        {
            if (IsFirstRun)
                return;

            TextBox currentTextbox = sender as TextBox;
            if (currentTextbox.Text.Length == 3)
            {
                IpBox4.Focus();
                IpBox4.SelectAll();
            }
        }

        private void IpAddressTextBoxHandler4(object sender, TextChangedEventArgs e)
        {
            if (IsFirstRun)
            {
                IsFirstRun = false;
                return;
            }

            TextBox currentTextbox = sender as TextBox;
            if (currentTextbox.Text.Length == 3)
            {
                PortBox.Focus();
                PortBox.SelectAll();
            }
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            string ipAddress = $"{IpBox1.Text}.{IpBox2.Text}.{IpBox3.Text}.{IpBox4.Text}";

            if (!isValidIPAddress(ipAddress))
                WarningLabel.IsEnabled = true;

            else if (isValidPort(PortBox.Text))
            {

                Client client = new Client(ipAddress, Convert.ToInt32(PortBox.Text));
                client.Show();
                this.Hide();
            }
        }

        private bool isValidIPAddress(string addr)
        {
            // Checks if the string is empty
            if (String.IsNullOrWhiteSpace(addr))
                return false;

            // Checks if the string has 4 scopes
            string[] splitvalues = addr.Split('.');
            if (splitvalues.Length != 4)
                return false;
            
            // Checks if the values in the scopes is equal to or lower than 255
            byte tempForParse;
            bool test = splitvalues.All(r => byte.TryParse(r, out tempForParse));
            return test;
        }

        private bool isValidPort(string port)
        {
            if (String.IsNullOrWhiteSpace(port))
                return false;

            // checks if the string is numeric
            Regex numeric = new Regex(@"^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // checks if the string is numeric and if it fit in the scope of available ports
            if (numeric.IsMatch(port))
            {
                try
                {
                    if (Convert.ToInt32(port) < 65536)
                        return true;

                } catch (OverflowException)
                {
                }
            }
            return false;
        }
    }
}
