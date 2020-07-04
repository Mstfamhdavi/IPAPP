using SHDocVw;
using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Windows.Forms;





namespace IP_Ping
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            
           InitializeComponent();
       


                  
            
        }
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (metroComboBox1.SelectedItem.ToString() == "DHCP")
            {
                textBox1.Enabled = false;
            }
            else
                textBox1.Enabled = true;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            //TODO Making A IP Address Template For Textbox1
            //TODO: ADD SUBNET MASK AND DEFAULT GATE WAY
            //Variables AND TEXTBOX 
            //#The Code Bellow  Works For Defualt Browser #CODE_1
            InternetExplorer ie = null;//#Code_2
            string x;
            x = textBox1.Text;



            if (textBox1.Text.Trim() == string.Empty && metroComboBox1.SelectedItem.ToString() != "DHCP")

            {
                MessageBox.Show("Enter Ip Address", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //IP Ping FUll Result

            else if (metroComboBox1.SelectedItem.ToString() == "Full Result Ping")

            {
                var p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = "/c ping -t " + x;
                p.Start();
            }

            //IP Set
            else if (metroComboBox1.SelectedItem.ToString() == "IP Set")
            {

                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"ETHERNET\" static " + x);
                p.StartInfo = psi;
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            //Ip Add
            else if (metroComboBox1.SelectedItem.ToString() == "IP Add")
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip add address \"ETHERNET\" " + x);
                p.StartInfo = psi;
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            //DHCP
            else if (metroComboBox1.SelectedItem.ToString() == "DHCP")
            {

                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"ETHERNET\" dhcp");
                p.StartInfo = psi;
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }

            //IP Open

            else if (metroComboBox1.SelectedItem.ToString() == "IP Open")
            //#The Code Bellow  Works For Defualt Browser #CODE_1

            // if (iExplore.Count > 0)
            {
                //IEnumerator enumerator = iExplore.GetEnumerator();
                //enumerator.MoveNext();
                //InternetExplorer iExplorer = (InternetExplorer)enumerator.Current;
                //iExplorer.Navigate(x, 0x800);
                //Flag 0x800 means new tab

                //The Code Bellow Works for IE #Code_2

                SHDocVw.ShellWindows allBrowser = new SHDocVw.ShellWindows();//gives all browsers
                int browserCount = allBrowser.Count - 1;//no . of browsers
                {
                    ie = allBrowser.Item(browserCount) as InternetExplorer;

                    if (ie != null && ie.FullName.ToLower().Contains("iexplore"))//all IE will have this name
                    {
                        ie.Navigate2("" + x, 0x800);
                    }

                    else
                    {
                        Process p = new Process();
                        ProcessStartInfo psi = new ProcessStartInfo("IExplore", "" + x);
                        p.StartInfo = psi;
                        p.Start();
                    }
                }
            }

            //IP PING

            else if (metroComboBox1.SelectedItem.ToString() == "Ping")

            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("" + x, 1000);

                if (reply != null)
                {
                    label1.Text = ("Status :" + reply.Status + " \nTime : " + reply.RoundtripTime.ToString() + " \nAddress : " + reply.Address);
                }

            }

        }
 
    }
}


    





      
                   
    















