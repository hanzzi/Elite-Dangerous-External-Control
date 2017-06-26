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
            IPAddress addr = IPAddress.Parse($"{IpBox1}.{IpBox2}.{IpBox3}.{IpBox4}");

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

            if (IpBox1.Text == string.Empty || IpBox2.Text == string.Empty || IpBox3.Text == string.Empty || IpBox4.Text == string.Empty || PortBox.Text == string.Empty)
                WarningLabel.IsEnabled = true;
        }
    }
}
