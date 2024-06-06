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
            LoadRegistryStartupItems();
            removeStartupToolStripMenuItem.Click += RemoveStartupToolStripMenuItem_Click;
            listBox1.MouseDown += ListBox1_MouseDown;
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
        }

        private void StartUPBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;
        }

        private void LoadRegistryStartupItems()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Registry (Current User):");
            List<string> registryCurrentUserItems = GetRegistryStartupItems(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Run");
            listBox1.Items.AddRange(registryCurrentUserItems.ToArray());
            listBox1.Items.Add("");

            listBox1.Items.Add("Registry (Local Machine):");
            List<string> registryLocalMachineItems = GetRegistryStartupItems(Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Run");
            listBox1.Items.AddRange(registryLocalMachineItems.ToArray());
            listBox1.Items.Add("");
        }

        private List<string> GetRegistryStartupItems(RegistryKey rootKey, string subKeyPath)
        {
            List<string> items = new List<string>();
            using (RegistryKey key = rootKey.OpenSubKey(subKeyPath))
            {
                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        string item = $"{valueName}: {key.GetValue(valueName)}";
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox1.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBox1.SelectedIndex = index;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void RemoveStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            MessageBox.Show($"Selected item: {selectedItem}");

            if (string.IsNullOrEmpty(selectedItem)) return;

            // Remove the selected item, regardless of the section it belongs to
            RemoveRegistryStartupItem(selectedItem);
        }

        private void RemoveRegistryStartupItem(string selectedItem)
        {
            string valueName = selectedItem.Split(':')[0].Trim();

            // Search for the registry key containing the value to remove
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key != null && key.GetValue(valueName) != null)
                {
                    key.DeleteValue(valueName);
                    MessageBox.Show($"Removed startup item: {selectedItem}");
                    LoadRegistryStartupItems();
                    return;
                }
            }

            // If the key is not found in the local machine section, search in the current user section
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key != null && key.GetValue(valueName) != null)
                {
                    key.DeleteValue(valueName);
                    MessageBox.Show($"Removed startup item: {selectedItem}");
                    LoadRegistryStartupItems();
                    return;
                }
            }

            MessageBox.Show($"Cannot remove startup item: {selectedItem}. It doesn't exist in the registry.");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
