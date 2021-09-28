using AsteroidLLC_client.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidLLC_client
{
    // If you injected 'index.js' with a stub, you could use this feature to clean the injection.
    class RevertStub
    {
        internal static void RS()
        {
            foreach (var i in Discord())
            {
                try
                {
                    File.WriteAllText(Index(i), "module.exports = require('./core.asar');");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Intersel - Revert Stub Exception");
                }
            }
        }

        static List<string> Discord()
        {
            List<string> list = new List<string>();
            foreach (var i in Directory.GetDirectories(Environment.GetEnvironmentVariable("LocalAppData")))
            {
                if (i.Contains("cord"))
                {

                    list.Add(i);
                }

            }
            return list;
        }

        static string Index(string localappdata)
        {
            string path = "";
            try
            {
                foreach (var dir1 in Directory.GetDirectories(localappdata))
                {
                    if (dir1.Contains("app-"))
                    {

                        foreach (var app in Directory.GetDirectories(dir1))
                        {
                            if (app.Contains("modules"))
                            {
                                foreach (var i in Directory.GetDirectories(app))
                                {
                                    if (i.Contains("discord_desktop_core"))
                                    {
                                        path = i + @"\discord_desktop_core\index.js";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                path = "Discord is not installed!";
            }
            return path;
        }
    }
}