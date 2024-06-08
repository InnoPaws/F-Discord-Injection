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
using System.ServiceProcess;
using System.Diagnostics.Eventing.Reader;


namespace FuckIDiscordInjections
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;
        private Timer notificationTimer;
        public Form1()
        {
            InitializeComponent();
            LoadRegistryStartupItems();
            removeStartupToolStripMenuItem.Click += RemoveStartupToolStripMenuItem_Click;
            listBox1.MouseDown += ListBox1_MouseDown;
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Thanks!";
            trayIcon.Icon = SystemIcons.Information;

            notificationTimer = new Timer();
            notificationTimer.Interval = 5000;
            notificationTimer.Tick += NotificationTimer_Tick;

            ShowNotification("Thanks For Using My Program", "Thanks for installing my program :)\nI really hope you enjoy this software and i hope it helps you out thank you!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunCommandPrompt();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            notificationTimer.Stop();
        }

        private void ShowNotification(string title, string message)
        {
            trayIcon.BalloonTipTitle = title;
            trayIcon.BalloonTipText = message;
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(5000);
            notificationTimer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trayIcon != null)
            {
                trayIcon.Dispose();
            }
            if (notificationTimer != null)
            {
                notificationTimer.Dispose();
            }
        }

        private void youtubelabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@InnoPaws");
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
        }
        private void StartUPBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;
        }
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 2;
        }
        private void LogsBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;
        }
        private void HackerBtn_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 4;
        }
        private void SendCmdBtn_Click(object sender, EventArgs e)
        {
            string command = SendCmdTextBox.Text;
            SendCommand(command);
            SendCmdTextBox.Text = "";
        }
        private void RefreshCMDBtn_Click(object sender, EventArgs e)
        {
            consoleRichTextBox.Clear();
            CloseCommandPrompt();
            RunCommandPrompt();
        }

        private void RemoveSuperHiddenBtn_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
        private void Base64EncodeBtn_Click(object sender, EventArgs e)
        {
            EncodeBase64();
        }

        private void Base64DecodeBtn_Click(object sender, EventArgs e)
        {
            DecodeBase64();
        }
        private void FixMyPCBtn_Click(object sender, EventArgs e)
        {
            if (EnableTaskMgrBtn.Checked)
            {
                EnableTaskManager();
            }

            if (EnableControlBtn.Checked)
            {
                EnableControlPanel();
            }

            if (EnableCMDBtn.Checked)
            {
                EnableCommandPrompt();
            }

            if (EnableRegeditBrn.Checked)
            {
                EnableRegedit();
            }

            if (EnableResetMyPCBtn.Checked)
            {
                EnableWinRE();
            }

            if (EnableDefenderBtn.Checked)
            {
                EnableWindowsDefender();
                StartWindowsDefenderServices();
            }

            if (HostRepairBtn.Checked)
            {
                string hostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
                string defaultHostsContent = @"
# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#    127.0.0.1       localhost
#    ::1             localhost
";

                try
                {
                    File.WriteAllText(hostsFilePath, defaultHostsContent);
                    listBox2.Items.Add("The hosts file has been repaired successfully.");
                    MessageBox.Show("The hosts file has been repaired successfully.", "Host File Repaired!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    listBox2.Items.Add($"An error occurred while repairing the hosts file: {ex.Message}");
                    MessageBox.Show($"An error occurred while repairing the hosts file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (TempCleanerBtn.Checked)
            {
                CleanTemp(listBox2);
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
                listBox2.Items.Add("Please select an item to remove.");
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            listBox2.Items.Add($"Selected item: {selectedItem}");

            if (string.IsNullOrEmpty(selectedItem)) return;

            RemoveRegistryStartupItem(selectedItem);
        }

        private void RemoveRegistryStartupItem(string selectedItem)
        {
            string valueName = selectedItem.Split(':')[0].Trim();

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key != null && key.GetValue(valueName) != null)
                {
                    key.DeleteValue(valueName);
                    listBox2.Items.Add($"Removed startup item: {selectedItem}");
                    MessageBox.Show($"Removed startup item: {selectedItem}");
                    LoadRegistryStartupItems();
                    return;
                }
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key != null && key.GetValue(valueName) != null)
                {
                    key.DeleteValue(valueName);
                    listBox2.Items.Add($"Removed startup item: {selectedItem}");
                    MessageBox.Show($"Removed startup item: {selectedItem}");
                    LoadRegistryStartupItems();
                    return;
                }
            }
            listBox2.Items.Add($"Cannot remove startup item: {selectedItem}. It doesn't exist in the registry.");
            MessageBox.Show($"Cannot remove startup item: {selectedItem}. It doesn't exist in the registry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static void EnableTaskManager()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }

                if (key.GetValue("DisableTaskMgr") != null)
                {
                    key.DeleteValue("DisableTaskMgr");
                    MessageBox.Show("Task Manager enabled successfully.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Task Manager is already enabled.", "Already Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling Task Manager: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void EnableControlPanel()
        {
            ModifyRegistryValue(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoControlPanel", false);
        }

        static void EnableCommandPrompt()
        {
            ModifyRegistryValue(@"Software\Policies\Microsoft\Windows\System", "DisableCMD", false);
        }

        static void EnableRegedit()
        {
            ModifyRegistryValue(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", false);
        }

        static void ModifyRegistryValue(string subKey, string valueName, bool disable)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey, true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(subKey);
                }

                if (disable)
                {
                    key.SetValue(valueName, 1, RegistryValueKind.DWord);
                    MessageBox.Show($"{valueName} disabled successfully.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                        MessageBox.Show($"{valueName} enabled successfully.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{valueName} is already enabled.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying {valueName}: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void EnableWindowsDefender()
        {
            string[] subKeys = {
                @"SOFTWARE\Policies\Microsoft\Windows Defender",
                @"SOFTWARE\Microsoft\Windows Defender\Real-Time Protection",
                @"SOFTWARE\Microsoft\Windows Defender\Spynet"
            };

            try
            {
                // Enable core Defender settings
                EnableRegistrySetting(subKeys[0], "DisableAntiSpyware", false);
                EnableRegistrySetting(subKeys[0], "DisableRealtimeMonitoring", false);

                // Enable Real-Time Protection settings
                EnableRegistrySetting(subKeys[1], "DisableBehaviorMonitoring", false);
                EnableRegistrySetting(subKeys[1], "DisableOnAccessProtection", false);
                EnableRegistrySetting(subKeys[1], "DisableScanOnRealtimeEnable", false);

                // Enable Cloud Protection
                EnableRegistrySetting(subKeys[2], "SpynetReporting", true, 2); // Set to 2 for "Advanced MAPS"
                EnableRegistrySetting(subKeys[2], "SubmitSamplesConsent", true, 2); // Set to 2 for "Always Prompt"

                MessageBox.Show("Windows Defender settings enabled successfully.", "Already Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling Windows Defender settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void EnableRegistrySetting(string subKey, string valueName, bool isDword, object value = null)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(subKey, true) ?? Registry.LocalMachine.CreateSubKey(subKey);

                if (isDword)
                {
                    key.SetValue(valueName, value ?? 0, RegistryValueKind.DWord);
                }
                else
                {
                    if (key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                    }
                }

                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying {valueName} in {subKey}: {ex.Message}", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static void StartWindowsDefenderServices()
        {
            string[] services = { "WinDefend", "WdNisSvc" };

            foreach (string serviceName in services)
            {
                try
                {
                    ServiceController sc = new ServiceController(serviceName);

                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        MessageBox.Show($"{serviceName} service started successfully.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{serviceName} service is already running.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting {serviceName} service: " + ex.Message, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        static void EnableWinRE()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "reagentc";
            processInfo.Arguments = "/enable";
            processInfo.Verb = "runas"; 
            processInfo.UseShellExecute = true;

            try
            {
                Process process = Process.Start(processInfo);
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Successfully enabled WinRE.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to enable WinRE. Exit code: {process.ExitCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindAndReapirBtn_Click_1(object sender, EventArgs e)
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
                                listBox2.Items.Add("Done! Malware Injection Removed. Please kill Discord and run it again to refresh Discord's index.js");
                                MessageBox.Show("Done! Malware Injection Removed. Please kill Discord and run it again to refresh Discord's index.js", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                listBox2.Items.Add("An error occurred while processing the file: " + ex.Message);
                                MessageBox.Show("An error occurred while processing the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            listBox2.Items.Add("Alright");
                            MessageBox.Show("alright");
                        }

                    }
                    else
                    {
                        listBox2.Items.Add("This is not a valid JavaScript file. The file name must be 'index.js'. - [DISCORD ONLY]");
                        MessageBox.Show("This is not a valid JavaScript file. The file name must be 'index.js'. - [DISCORD ONLY]", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void CreateBATBtn_Click_1(object sender, EventArgs e)
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
                listBox2.Items.Add($"Batch file created sucessfully: {batchFilePath}");
                MessageBox.Show("Batch file created successfully: " + batchFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string runKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
                using (RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true))
                {
                    startupKey.SetValue(batchFileName, batchFilePath);
                }
                listBox2.Items.Add("Batch file added to registry startup.");
                MessageBox.Show("Batch file added to registry startup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox2.Items.Add("All operations completed sucessfully.");
                MessageBox.Show("All operations completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add($"An Error Occurred: {ex.Message}");
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KillBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process[] discordProcesses = Process.GetProcessesByName("Discord");

                foreach (Process process in discordProcesses)
                {
                    process.Kill();
                    process.WaitForExit();
                    listBox2.Items.Add($"Killed process {process.ProcessName} with ID {process.Id}");
                    listBox2.Items.Add("Success! Please Open Discord.");
                    MessageBox.Show($"Killed process {process.ProcessName} with ID {process.Id}", "Discord Killed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Sucesses! Please Open Discord.", "Discord Killed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (discordProcesses.Length == 0)
                {
                    listBox2.Items.Add("No Discord processes found.");
                    MessageBox.Show("No Discord processes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                listBox2.Items.Add($"An error occurred: {ex.Message}");
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void youtubelabel_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@InnoPaws");
        }

        static void CleanTemp(ListBox listBox2)
        {
            string tempFolderPath = Path.GetTempPath();

            string debugMessage = "Temp folder path: " + tempFolderPath;
            listBox2.Items.Add(debugMessage);

            try
            {
                string[] files = Directory.GetFiles(tempFolderPath);

                foreach (string file in files)
                {
                    try
                    {
                        File.Delete(file);
                        string successFileMessage = "Deleted file: " + file;
                        listBox2.Items.Add(successFileMessage);
                    }
                    catch (Exception ex)
                    {
                        string errorFileMessage = "Failed to delete file: " + file + "\nException: " + ex.Message;
                        listBox2.Items.Add(errorFileMessage);
                    }
                }

                string[] directories = Directory.GetDirectories(tempFolderPath);

                foreach (string directory in directories)
                {
                    try
                    {
                        Directory.Delete(directory, true);
                        string successDirectoryMessage = "Deleted directory: " + directory;
                        listBox2.Items.Add(successDirectoryMessage);
                    }
                    catch (Exception ex)
                    {
                        string errorDirectoryMessage = "Failed to delete directory: " + directory + "\nException: " + ex.Message;
                        listBox2.Items.Add(errorDirectoryMessage);
                    }
                }

                string successMessage = "Temp folder cleaned successfully.";
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox2.Items.Add(successMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "Failed to clean temp folder.\nException: " + ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBox2.Items.Add(errorMessage);
            }
        }

        private void EncodeBase64()
        {
            try
            {
                string input = Base64Text.Text;
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                string encodedText = Convert.ToBase64String(inputBytes);
                Base64Text.Text = encodedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encoding text: " + ex.Message);
            }
        }

        private void DecodeBase64()
        {
            try
            {
                string encodedText = Base64Text.Text;
                byte[] outputBytes = Convert.FromBase64String(encodedText);
                string decodedText = System.Text.Encoding.UTF8.GetString(outputBytes);
                Base64Text.Text = decodedText;
            }
            catch (FormatException)
            {
                MessageBox.Show("The input is not a valid Base64 encoded string.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error decoding text: " + ex.Message);
            }
        }

        private Process process;
        private void RunCommandPrompt()
        {
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }

        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText("[Error] " + e.Data + Environment.NewLine);
            }
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(AppendText), text);
                return;
            }
            consoleRichTextBox.AppendText(text);
            consoleRichTextBox.SelectionStart = consoleRichTextBox.Text.Length;
            consoleRichTextBox.ScrollToCaret();
        }

        private void SendCommand(string command)
        {
            if (process != null && !process.HasExited)
            {
                process.StandardInput.WriteLine(command);
            }
        }
        private void CloseCommandPrompt()
        {
            if (process != null && !process.HasExited)
            {
                process.Kill();
            }
        }
    }
}
