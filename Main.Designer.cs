namespace HospitalRecords
{
    partial class Main
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
            menuStrip1 = new MenuStrip();
            applicationToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            patientsToolStripMenuItem = new ToolStripMenuItem();
            addNewToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { applicationToolStripMenuItem, patientsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(505, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            applicationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { signOutToolStripMenuItem });
            applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            applicationToolStripMenuItem.Size = new Size(80, 20);
            applicationToolStripMenuItem.Text = "Application";
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(180, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            signOutToolStripMenuItem.Click += signOutToolStripMenuItem_Click;
            // 
            // patientsToolStripMenuItem
            // 
            patientsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNewToolStripMenuItem });
            patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            patientsToolStripMenuItem.Size = new Size(61, 20);
            patientsToolStripMenuItem.Text = "Patients";
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.Size = new Size(180, 22);
            addNewToolStripMenuItem.Text = "Add Patient Record";
            addNewToolStripMenuItem.Click += addNewToolStripMenuItem_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Munyaradzi Sydney Chinzvende", "Tanaka Maranda", "Tadiwe Mahumbwe", "Mariah Sembwe" });
            listBox1.Location = new Point(12, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(202, 274);
            listBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 343);
            button1.Name = "button1";
            button1.Size = new Size(202, 23);
            button1.TabIndex = 2;
            button1.Text = "VIEW RECORD";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 3;
            label1.Text = "Available Patient Records";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.download__1_;
            pictureBox1.Location = new Point(321, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(322, 279);
            button2.Name = "button2";
            button2.Size = new Size(133, 23);
            button2.TabIndex = 5;
            button2.Text = "SCAN PRINT";
            button2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 387);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem applicationToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem patientsToolStripMenuItem;
        private ToolStripMenuItem addNewToolStripMenuItem;
        private ListBox listBox1;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button2;
    }
}