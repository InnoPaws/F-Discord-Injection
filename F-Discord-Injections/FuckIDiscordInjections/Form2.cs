using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuckIDiscordInjections
{
    public partial class Form2 : Form
    {
        private ContextMenuStrip contextMenu;

        public Form2()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);

            // Initialize the context menu
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Delete", null, new EventHandler(DeleteItem_Click));
            listBox1.ContextMenuStrip = contextMenu;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private int clickCount = 0;
        private void FindBtn_Click(object sender, EventArgs e)
        {
            clickCount++;

            if (clickCount > 1)
            {
                var result = MessageBox.Show("Are you sure you want to search again?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    listBox1.Items.Clear();

                    LoadHiddenItems();
                }
                else
                {
                    clickCount = 1;
                }
            }
            else
            {
                LoadHiddenItems();
            }
        }

        private void LoadHiddenItems()
        {
            try
            {
                string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string tempFolder = Path.GetTempPath();
                string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string[] foldersToScan = { appDataFolder, localAppDataFolder, tempFolder, desktopFolder, userFolder };

                foreach (string folder in foldersToScan)
                {
                    ScanFolderForHiddenFiles(folder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading hidden items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScanFolderForHiddenFiles(string folderPath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                foreach (var fileInfo in directoryInfo.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileAttributes attributes = File.GetAttributes(fileInfo.FullName);

                        if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        {
                            listBox1.Items.Add(fileInfo.FullName);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception)
            {
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && MouseButtons != MouseButtons.Right)
            {
                string selectedFile = listBox1.SelectedItem.ToString();
                var result = MessageBox.Show("Do you want to open this file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(selectedFile) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while trying to open the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedFile = listBox1.SelectedItem.ToString();
                var result = MessageBox.Show("Are you sure you want to delete this file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        File.SetAttributes(selectedFile, FileAttributes.Normal); // Remove hidden attribute if necessary
                        File.Delete(selectedFile);
                        listBox1.Items.Remove(selectedFile);
                        MessageBox.Show("File deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while trying to delete the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
