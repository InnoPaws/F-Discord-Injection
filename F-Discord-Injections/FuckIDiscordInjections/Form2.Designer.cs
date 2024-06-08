namespace FuckIDiscordInjections
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Form2ContainerControl = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.FindBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.MinizeBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ExitBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Form2DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Form2ContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(653, 381);
            this.listBox1.TabIndex = 0;
            // 
            // Form2ContainerControl
            // 
            this.Form2ContainerControl.Controls.Add(this.FindBtn);
            this.Form2ContainerControl.Controls.Add(this.MinizeBtn);
            this.Form2ContainerControl.Controls.Add(this.ExitBtn);
            this.Form2ContainerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Form2ContainerControl.FillColor = System.Drawing.Color.LightGray;
            this.Form2ContainerControl.Location = new System.Drawing.Point(0, 0);
            this.Form2ContainerControl.Name = "Form2ContainerControl";
            this.Form2ContainerControl.Size = new System.Drawing.Size(653, 28);
            this.Form2ContainerControl.TabIndex = 1;
            this.Form2ContainerControl.Text = "guna2ContainerControl1";
            // 
            // FindBtn
            // 
            this.FindBtn.BackColor = System.Drawing.Color.LightGray;
            this.FindBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.FindBtn.HoverState.ImageSize = new System.Drawing.Size(26, 26);
            this.FindBtn.Image = ((System.Drawing.Image)(resources.GetObject("FindBtn.Image")));
            this.FindBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.FindBtn.ImageRotate = 0F;
            this.FindBtn.ImageSize = new System.Drawing.Size(26, 26);
            this.FindBtn.Location = new System.Drawing.Point(0, 0);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.PressedState.ImageSize = new System.Drawing.Size(26, 26);
            this.FindBtn.Size = new System.Drawing.Size(32, 28);
            this.FindBtn.TabIndex = 2;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // MinizeBtn
            // 
            this.MinizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinizeBtn.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.MinizeBtn.FillColor = System.Drawing.Color.LightGray;
            this.MinizeBtn.IconColor = System.Drawing.Color.Black;
            this.MinizeBtn.Location = new System.Drawing.Point(562, 0);
            this.MinizeBtn.Name = "MinizeBtn";
            this.MinizeBtn.Size = new System.Drawing.Size(45, 28);
            this.MinizeBtn.TabIndex = 1;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.FillColor = System.Drawing.Color.LightGray;
            this.ExitBtn.IconColor = System.Drawing.Color.Black;
            this.ExitBtn.Location = new System.Drawing.Point(608, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(45, 28);
            this.ExitBtn.TabIndex = 0;
            // 
            // Form2DragControl
            // 
            this.Form2DragControl.DockIndicatorTransparencyValue = 0.6D;
            this.Form2DragControl.TargetControl = this.Form2ContainerControl;
            this.Form2DragControl.UseTransparentDrag = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 423);
            this.Controls.Add(this.Form2ContainerControl);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Form2ContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private Guna.UI2.WinForms.Guna2ContainerControl Form2ContainerControl;
        private Guna.UI2.WinForms.Guna2ControlBox MinizeBtn;
        private Guna.UI2.WinForms.Guna2ControlBox ExitBtn;
        private Guna.UI2.WinForms.Guna2ImageButton FindBtn;
        private Guna.UI2.WinForms.Guna2DragControl Form2DragControl;
    }
}