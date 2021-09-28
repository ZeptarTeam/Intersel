using InterselClient_API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidLLC_client
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void usernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            usernametextbox.Text = Program.GetValue("Username");
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently under development!", "Intersel - version 1.0");
        }
    }
}
