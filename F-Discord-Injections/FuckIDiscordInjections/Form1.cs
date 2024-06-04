using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace FuckIDiscordInjections
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void youtubelabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@InnoPaws");
        }

        private void KillBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] discordProcesses = Process.GetProcessesByName("Discord");

                foreach (Process process in discordProcesses)
                {
                    process.Kill();
                    process.WaitForExit(); 
                    MessageBox.Show($"Killed process {process.ProcessName} with ID {process.Id}", "Discord Killed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Sucesses! Please Open Discord.", "Discord Killed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (discordProcesses.Length == 0)
                {
                    MessageBox.Show("No Discord processes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAndReapirBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JavaScript files (*.js)|*.js";
                openFileDialog.Title = "Select a JavaScript File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    if (fileName.Equals("index.js", StringComparison.OrdinalIgnoreCase))
                    {
                        DialogResult result = MessageBox.Show("Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                File.WriteAllText(filePath, "module.exports = require(\"./core.asar\");");

                                MessageBox.Show("Done! Malware Injection Removed. Please kill Discord and run it again to refresh Discord's index.js", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred while processing the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("alright");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("This is not a valid JavaScript file. The file name must be 'index.js'. - [DISCORD ONLY]", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void CreateBATBtn_Click(object sender, EventArgs e)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int minLength = 5;
            int maxLength = 10;
            Random random = new Random();
            int length = random.Next(minLength, maxLength + 1);
            string randomName = GenerateRandomString(chars, length);
            string batchFileName = $"{randomName}.bat";
            string tempDirectory = Path.GetTempPath();
            string batchFilePath = Path.Combine(tempDirectory, batchFileName);

            string[] batchFileContent = {
            "@echo off",
            "setlocal enabledelayedexpansion",
            "set \"folder_list=Discord DiscordCanary DiscordPTB DiscordDevelopment\"",
            "timeout /t 5",
            "taskkill /F /IM Discord.exe",
            "taskkill /F /IM Update.exe",
            "for %%F in (%folder_list%) do (",
            "    set \"deneme_path=%LOCALAPPDATA%\\%%F\"",
            "    if exist \"!deneme_path!\" (",
            "        for /r \"!deneme_path!\" %%D in (discord_desktop_core) do (",
            "            if exist \"%%D\\index.js\" (",
            "                (echo module.exports = require(\"./core.asar\");) > \"%%D\\index.js\"",
            "                echo Updated index.js in %%D",
            "            )",
            "        )",
            "    )",
            ")",
            "start \"\" \"C:\\Users\\%USERNAME%\\AppData\\Local\\Discord\\Update.exe\" --processStart Discord.exe",
            "pause"
        };

            try
            {
                File.WriteAllLines(batchFilePath, batchFileContent);

                MessageBox.Show("Batch file created successfully: " + batchFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string runKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
                using (RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true))
                {
                    startupKey.SetValue(batchFileName, batchFilePath);
                }
                MessageBox.Show("Batch file added to registry startup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("All operations completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string GenerateRandomString(string characters, int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
