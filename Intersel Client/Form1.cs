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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (API.Login(usertextbox.Text, passwordtextbox.Text))
            {
                API.Log(usertextbox.Text, "Login");
                Program.SetValue("Username", usertextbox.Text);
                Program.SetValue("Password", passwordtextbox.Text);
                MessageBox.Show("Succesfully logged in!", OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                new Form3().Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usertextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
