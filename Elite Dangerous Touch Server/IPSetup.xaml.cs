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
        public IPSetup()
        {
            InitializeComponent();
        }

        private IPAddress BuildIpAdress()
        {
            IPAddress addr = IPAddress.Parse($"{IpBox1}.{IpBox2}.{IpBox3}.{IpBox4}");

            return addr;
        }

        private void IpAddressTextBoxHandler1(object sender, TextChangedEventArgs e)
        {
            TextBox currentTextbox = sender as TextBox;
            if (currentTextbox.Text.Length == 3)
                IpBox2.Focus();
        }

        private void IpAddressTextBoxHandler2(object sender, TextChangedEventArgs e)
        {
            if (e.Changes.Count == 3)
            {
                IpBox3.Focus();
                IpBox3.SelectAll();
                IpBox3.Clear();
            }
        }

        private void IpAddressTextBoxHandler3(object sender, TextChangedEventArgs e)
        {
            if (e.Changes.Count == 3)
                IpBox4.Focus();
        }

        private void IpAddressTextBoxHandler4(object sender, TextChangedEventArgs e)
        {
            if (e.Changes.Count == 3)
                PortBox.Focus();
        }
    }
}
