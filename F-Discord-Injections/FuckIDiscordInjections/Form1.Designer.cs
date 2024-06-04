namespace FuckIDiscordInjections
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.FindAndReapirBtn = new System.Windows.Forms.Button();
            this.CreateBATBtn = new System.Windows.Forms.Button();
            this.KillBtn = new System.Windows.Forms.Button();
            this.youtubelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuck Discord Injections";
            // 
            // FindAndReapirBtn
            // 
            this.FindAndReapirBtn.Location = new System.Drawing.Point(13, 41);
            this.FindAndReapirBtn.Name = "FindAndReapirBtn";
            this.FindAndReapirBtn.Size = new System.Drawing.Size(149, 23);
            this.FindAndReapirBtn.TabIndex = 1;
            this.FindAndReapirBtn.Text = "Find / Repair JS";
            this.FindAndReapirBtn.UseVisualStyleBackColor = true;
            this.FindAndReapirBtn.Click += new System.EventHandler(this.FindAndReapirBtn_Click);
            // 
            // CreateBATBtn
            // 
            this.CreateBATBtn.Location = new System.Drawing.Point(168, 41);
            this.CreateBATBtn.Name = "CreateBATBtn";
            this.CreateBATBtn.Size = new System.Drawing.Size(129, 23);
            this.CreateBATBtn.TabIndex = 2;
            this.CreateBATBtn.Text = "Create Batch";
            this.CreateBATBtn.UseVisualStyleBackColor = true;
            this.CreateBATBtn.Click += new System.EventHandler(this.CreateBATBtn_Click);
            // 
            // KillBtn
            // 
            this.KillBtn.Location = new System.Drawing.Point(103, 70);
            this.KillBtn.Name = "KillBtn";
            this.KillBtn.Size = new System.Drawing.Size(107, 23);
            this.KillBtn.TabIndex = 3;
            this.KillBtn.Text = "Kill Discord";
            this.KillBtn.UseVisualStyleBackColor = true;
            this.KillBtn.Click += new System.EventHandler(this.KillBtn_Click);
            // 
            // youtubelabel
            // 
            this.youtubelabel.AutoSize = true;
            this.youtubelabel.Location = new System.Drawing.Point(301, 96);
            this.youtubelabel.Name = "youtubelabel";
            this.youtubelabel.Size = new System.Drawing.Size(13, 13);
            this.youtubelabel.TabIndex = 4;
            this.youtubelabel.Text = "?";
            this.youtubelabel.Click += new System.EventHandler(this.youtubelabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 109);
            this.Controls.Add(this.youtubelabel);
            this.Controls.Add(this.KillBtn);
            this.Controls.Add(this.CreateBATBtn);
            this.Controls.Add(this.FindAndReapirBtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "lol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FindAndReapirBtn;
        private System.Windows.Forms.Button CreateBATBtn;
        private System.Windows.Forms.Button KillBtn;
        private System.Windows.Forms.Label youtubelabel;
    }
}

