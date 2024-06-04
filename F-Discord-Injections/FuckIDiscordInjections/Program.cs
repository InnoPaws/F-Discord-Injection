using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuckIDiscordInjections
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("Thanks for installing my program :)\nI really hope you enjoy this software and i hope it helps you out thank you!\nRemember Don't Install random stuff you see on the internet \nalways use tria.ge and virustotal before you run anything or download any software");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
