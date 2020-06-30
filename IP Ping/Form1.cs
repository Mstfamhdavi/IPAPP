using SHDocVw;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;




namespace IP_Ping
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {

            InitializeComponent();

            label1.Font = new Font("", 10);
            label2.Font = new Font("", 10, FontStyle.Bold);
            textBox1.Font = new Font("", 10);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.button1, "An Average Ping Will Be Shown");
            //#IP_PING
            string x;
            //TODO Making A IP Address Template For Textbox1
            x = textBox1.Text;
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Ip Address", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("" + x, 1000);

                if (reply != null)
                {
                    label1.Text = ("Status :" + reply.Status + " \nTime : " + reply.RoundtripTime.ToString() + " \nAddress : " + reply.Address);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.button2, "Full Result Of Your Ping Will Shown In A Command Prompt");
            //#IP_PING_FULL_RESULT
            string x;
            x = textBox1.Text;
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Ip Address", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = "/c ping -t " + x;
                p.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.button3, "This will Make Your Static IP To The Specefic IP That You Want");
            //#IP_SET
            string x;

            x = textBox1.Text;
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Ip Address", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //#TODO: ADD SUBNET MASK AND DEFAULT GATE WAY
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"ETHERNET\" static " + x);
                p.StartInfo = psi;
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //#IP_ADD
            string x;
            x = textBox1.Text;
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Ip Address", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip add address \"ETHERNET\" " + x);
                p.StartInfo = psi;
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //#IP_OPEN
            // ShellWindows iExplore = new ShellWindows();#Code_1

            InternetExplorer ie = null;//#Code_2
            {
                string x;

                x = textBox1.Text;
                if (textBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Ip Address", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            }
        }

    }
}

      
                   
    















