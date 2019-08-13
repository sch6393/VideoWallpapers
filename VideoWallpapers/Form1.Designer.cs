namespace VideoWallpapers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_Brightness = new System.Windows.Forms.Label();
            this.label_FileOpen = new System.Windows.Forms.Label();
            this.label_Buttons = new System.Windows.Forms.Label();
            this.label_Volume = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_VideoPath = new System.Windows.Forms.Label();
            this.label_VideoName = new System.Windows.Forms.Label();
            this.metroTrackBar_Brightness = new MetroFramework.Controls.MetroTrackBar();
            this.metroTrackBar_Volume = new MetroFramework.Controls.MetroTrackBar();
            this.metroButton_FileOpen = new MetroFramework.Controls.MetroButton();
            this.metroButton_Prev = new MetroFramework.Controls.MetroButton();
            this.metroButton_Pause = new MetroFramework.Controls.MetroButton();
            this.metroButton_Resume = new MetroFramework.Controls.MetroButton();
            this.metroButton_Next = new MetroFramework.Controls.MetroButton();
            this.metroButton_Stop = new MetroFramework.Controls.MetroButton();
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.metroButton_Hide = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label_Brightness
            // 
            this.label_Brightness.AutoSize = true;
            this.label_Brightness.BackColor = System.Drawing.Color.Transparent;
            this.label_Brightness.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Brightness.ForeColor = System.Drawing.Color.Black;
            this.label_Brightness.Location = new System.Drawing.Point(26, 135);
            this.label_Brightness.Name = "label_Brightness";
            this.label_Brightness.Size = new System.Drawing.Size(121, 15);
            this.label_Brightness.TabIndex = 0;
            this.label_Brightness.Text = "Brightness Control";
            // 
            // label_FileOpen
            // 
            this.label_FileOpen.AutoSize = true;
            this.label_FileOpen.BackColor = System.Drawing.Color.Transparent;
            this.label_FileOpen.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_FileOpen.ForeColor = System.Drawing.Color.Black;
            this.label_FileOpen.Location = new System.Drawing.Point(26, 165);
            this.label_FileOpen.Name = "label_FileOpen";
            this.label_FileOpen.Size = new System.Drawing.Size(64, 15);
            this.label_FileOpen.TabIndex = 10;
            this.label_FileOpen.Text = "File Open";
            // 
            // label_Buttons
            // 
            this.label_Buttons.AutoSize = true;
            this.label_Buttons.BackColor = System.Drawing.Color.Transparent;
            this.label_Buttons.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Buttons.ForeColor = System.Drawing.Color.Black;
            this.label_Buttons.Location = new System.Drawing.Point(26, 195);
            this.label_Buttons.Name = "label_Buttons";
            this.label_Buttons.Size = new System.Drawing.Size(98, 15);
            this.label_Buttons.TabIndex = 0;
            this.label_Buttons.Text = "Action Buttons";
            // 
            // label_Volume
            // 
            this.label_Volume.AutoSize = true;
            this.label_Volume.BackColor = System.Drawing.Color.Transparent;
            this.label_Volume.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Volume.ForeColor = System.Drawing.Color.Black;
            this.label_Volume.Location = new System.Drawing.Point(26, 105);
            this.label_Volume.Name = "label_Volume";
            this.label_Volume.Size = new System.Drawing.Size(104, 15);
            this.label_Volume.TabIndex = 0;
            this.label_Volume.Text = "Volume Control";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Transparent;
            this.label_Name.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Name.ForeColor = System.Drawing.Color.Black;
            this.label_Name.Location = new System.Drawing.Point(26, 75);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(81, 15);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "Video Name";
            // 
            // label_VideoPath
            // 
            this.label_VideoPath.AutoSize = true;
            this.label_VideoPath.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_VideoPath.Location = new System.Drawing.Point(223, 75);
            this.label_VideoPath.Name = "label_VideoPath";
            this.label_VideoPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_VideoPath.Size = new System.Drawing.Size(71, 15);
            this.label_VideoPath.TabIndex = 0;
            this.label_VideoPath.Text = "동영상 경로";
            this.label_VideoPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_VideoPath.Visible = false;
            // 
            // label_VideoName
            // 
            this.label_VideoName.AutoSize = true;
            this.label_VideoName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_VideoName.Location = new System.Drawing.Point(223, 75);
            this.label_VideoName.Name = "label_VideoName";
            this.label_VideoName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_VideoName.Size = new System.Drawing.Size(71, 15);
            this.label_VideoName.TabIndex = 0;
            this.label_VideoName.Text = "동영상 이름";
            this.label_VideoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroTrackBar_Brightness
            // 
            this.metroTrackBar_Brightness.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_Brightness.LargeChange = 10;
            this.metroTrackBar_Brightness.Location = new System.Drawing.Point(226, 130);
            this.metroTrackBar_Brightness.Maximum = 50;
            this.metroTrackBar_Brightness.Minimum = 5;
            this.metroTrackBar_Brightness.MouseWheelBarPartitions = 18;
            this.metroTrackBar_Brightness.Name = "metroTrackBar_Brightness";
            this.metroTrackBar_Brightness.Size = new System.Drawing.Size(330, 23);
            this.metroTrackBar_Brightness.SmallChange = 5;
            this.metroTrackBar_Brightness.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTrackBar_Brightness.TabIndex = 2;
            this.metroTrackBar_Brightness.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar_Brightness.UseCustomBackColor = true;
            this.metroTrackBar_Brightness.ValueChanged += new System.EventHandler(this.metroTrackBar_Brightness_ValueChanged);
            // 
            // metroTrackBar_Volume
            // 
            this.metroTrackBar_Volume.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_Volume.LargeChange = 10;
            this.metroTrackBar_Volume.Location = new System.Drawing.Point(226, 100);
            this.metroTrackBar_Volume.Name = "metroTrackBar_Volume";
            this.metroTrackBar_Volume.Size = new System.Drawing.Size(330, 23);
            this.metroTrackBar_Volume.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTrackBar_Volume.TabIndex = 1;
            this.metroTrackBar_Volume.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar_Volume.UseCustomBackColor = true;
            this.metroTrackBar_Volume.Value = 0;
            this.metroTrackBar_Volume.ValueChanged += new System.EventHandler(this.metroTrackBar_Volume_ValueChanged);
            // 
            // metroButton_FileOpen
            // 
            this.metroButton_FileOpen.Highlight = true;
            this.metroButton_FileOpen.Location = new System.Drawing.Point(226, 160);
            this.metroButton_FileOpen.Name = "metroButton_FileOpen";
            this.metroButton_FileOpen.Size = new System.Drawing.Size(330, 23);
            this.metroButton_FileOpen.TabIndex = 3;
            this.metroButton_FileOpen.Text = "File Open";
            this.metroButton_FileOpen.UseSelectable = true;
            this.metroButton_FileOpen.Click += new System.EventHandler(this.metroButton_FileOpen_Click);
            // 
            // metroButton_Prev
            // 
            this.metroButton_Prev.Highlight = true;
            this.metroButton_Prev.Location = new System.Drawing.Point(338, 190);
            this.metroButton_Prev.Name = "metroButton_Prev";
            this.metroButton_Prev.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Prev.TabIndex = 6;
            this.metroButton_Prev.Text = "Prev";
            this.metroButton_Prev.UseSelectable = true;
            this.metroButton_Prev.Click += new System.EventHandler(this.metroButton_Prev_Click);
            // 
            // metroButton_Pause
            // 
            this.metroButton_Pause.Highlight = true;
            this.metroButton_Pause.Location = new System.Drawing.Point(226, 190);
            this.metroButton_Pause.Name = "metroButton_Pause";
            this.metroButton_Pause.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Pause.TabIndex = 4;
            this.metroButton_Pause.Text = "Pause";
            this.metroButton_Pause.UseSelectable = true;
            this.metroButton_Pause.Click += new System.EventHandler(this.metroButton_Pause_Click);
            // 
            // metroButton_Resume
            // 
            this.metroButton_Resume.Highlight = true;
            this.metroButton_Resume.Location = new System.Drawing.Point(282, 190);
            this.metroButton_Resume.Name = "metroButton_Resume";
            this.metroButton_Resume.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Resume.TabIndex = 5;
            this.metroButton_Resume.Text = "Resume";
            this.metroButton_Resume.UseSelectable = true;
            this.metroButton_Resume.Click += new System.EventHandler(this.metroButton_Resume_Click);
            // 
            // metroButton_Next
            // 
            this.metroButton_Next.Highlight = true;
            this.metroButton_Next.Location = new System.Drawing.Point(394, 190);
            this.metroButton_Next.Name = "metroButton_Next";
            this.metroButton_Next.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Next.TabIndex = 7;
            this.metroButton_Next.Text = "Next";
            this.metroButton_Next.UseSelectable = true;
            this.metroButton_Next.Click += new System.EventHandler(this.metroButton_Next_Click);
            // 
            // metroButton_Stop
            // 
            this.metroButton_Stop.Highlight = true;
            this.metroButton_Stop.Location = new System.Drawing.Point(450, 190);
            this.metroButton_Stop.Name = "metroButton_Stop";
            this.metroButton_Stop.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Stop.TabIndex = 8;
            this.metroButton_Stop.Text = "Stop";
            this.metroButton_Stop.UseSelectable = true;
            this.metroButton_Stop.Click += new System.EventHandler(this.metroButton_Stop_Click);
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Text = "VideoWallpapers";
            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.BalloonTipClicked += new System.EventHandler(this.M_notifyIcon_BalloonTipClicked);
            this.m_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.M_notifyIcon_MouseDoubleClick);
            // 
            // metroButton_Hide
            // 
            this.metroButton_Hide.Highlight = true;
            this.metroButton_Hide.Location = new System.Drawing.Point(506, 190);
            this.metroButton_Hide.Name = "metroButton_Hide";
            this.metroButton_Hide.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Hide.TabIndex = 38;
            this.metroButton_Hide.Text = "Hide";
            this.metroButton_Hide.UseSelectable = true;
            this.metroButton_Hide.Click += new System.EventHandler(this.MetroButton_Hide_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 230);
            this.Controls.Add(this.metroButton_Hide);
            this.Controls.Add(this.metroButton_Stop);
            this.Controls.Add(this.metroButton_Next);
            this.Controls.Add(this.metroButton_Resume);
            this.Controls.Add(this.metroButton_Pause);
            this.Controls.Add(this.metroButton_Prev);
            this.Controls.Add(this.metroButton_FileOpen);
            this.Controls.Add(this.metroTrackBar_Brightness);
            this.Controls.Add(this.metroTrackBar_Volume);
            this.Controls.Add(this.label_VideoName);
            this.Controls.Add(this.label_Brightness);
            this.Controls.Add(this.label_FileOpen);
            this.Controls.Add(this.label_Buttons);
            this.Controls.Add(this.label_Volume);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_VideoPath);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Resizable = false;
            this.Text = "VideoWallpapers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Brightness;
        private System.Windows.Forms.Label label_FileOpen;
        private System.Windows.Forms.Label label_Buttons;
        private System.Windows.Forms.Label label_Volume;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_VideoPath;
        private System.Windows.Forms.Label label_VideoName;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_Brightness;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_Volume;
        private MetroFramework.Controls.MetroButton metroButton_FileOpen;
        private MetroFramework.Controls.MetroButton metroButton_Prev;
        private MetroFramework.Controls.MetroButton metroButton_Pause;
        private MetroFramework.Controls.MetroButton metroButton_Resume;
        private MetroFramework.Controls.MetroButton metroButton_Next;
        private MetroFramework.Controls.MetroButton metroButton_Stop;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private MetroFramework.Controls.MetroButton metroButton_Hide;
    }
}