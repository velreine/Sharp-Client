using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace Sharp_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Start sending updates...")
            {
                button1.Text = "Sending updates...";
                timer1.Start();
            }
            else
            {
                button1.Text = "Start sending updates...";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;



            Random rnd = new Random(secondsSinceEpoch);

            textBox1.Text = Convert.ToString(rnd.Next(100));
            textBox2.Text = Convert.ToString(rnd.Next(100));



        }
    }
}
