using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using MetroFramework;
using MetroFramework.Controls;

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
            this.metroCheckBox_Random = new MetroFramework.Controls.MetroCheckBox();
            this.label_RandomOn = new System.Windows.Forms.Label();
            this.label_RandomOff = new System.Windows.Forms.Label();
            this.label_Random = new System.Windows.Forms.Label();
            this.label_StartOn = new System.Windows.Forms.Label();
            this.label_StartOff = new System.Windows.Forms.Label();
            this.label_StartupProgram = new System.Windows.Forms.Label();
            this.metroCheckBox_StartupPrograms = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton_Monitor = new MetroFramework.Controls.MetroButton();
            this.label_Monitor = new System.Windows.Forms.Label();
            this.metroButton_Help = new MetroFramework.Controls.MetroButton();
            this.label_Help = new System.Windows.Forms.Label();
            this.m_metroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.videoNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.volumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_StyleMode = new System.Windows.Forms.Label();
            this.m_metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroButton_Light = new MetroFramework.Controls.MetroButton();
            this.metroButton_Dark = new MetroFramework.Controls.MetroButton();

            // ConvtextMenuStrip TrackBar
            this.toolStripMenuItem_VolumeTrackBar = new ToolStripTrackbarItem();
            this.toolStripMenuItem_BrightnessTrackBar = new ToolStripTrackbarItem();

            this.m_metroContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_metroStyleManager)).BeginInit();
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
            this.label_FileOpen.TabIndex = 0;
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
            this.label_VideoPath.Location = new System.Drawing.Point(231, 75);
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
            this.label_VideoName.Location = new System.Drawing.Point(231, 75);
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
            this.metroTrackBar_Brightness.Location = new System.Drawing.Point(234, 130);
            this.metroTrackBar_Brightness.Maximum = 50;
            this.metroTrackBar_Brightness.Minimum = 5;
            this.metroTrackBar_Brightness.MouseWheelBarPartitions = 18;
            this.metroTrackBar_Brightness.Name = "metroTrackBar_Brightness";
            this.metroTrackBar_Brightness.Size = new System.Drawing.Size(330, 23);
            this.metroTrackBar_Brightness.TabIndex = 2;
            this.metroTrackBar_Brightness.UseCustomBackColor = true;
            this.metroTrackBar_Brightness.ValueChanged += new System.EventHandler(this.metroTrackBar_Brightness_ValueChanged);
            this.metroTrackBar_Brightness.MouseEnter += new System.EventHandler(this.metroTrackBar_Brightness_MouseEnter);
            // 
            // metroTrackBar_Volume
            // 
            this.metroTrackBar_Volume.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_Volume.LargeChange = 10;
            this.metroTrackBar_Volume.Location = new System.Drawing.Point(234, 100);
            this.metroTrackBar_Volume.Name = "metroTrackBar_Volume";
            this.metroTrackBar_Volume.Size = new System.Drawing.Size(330, 23);
            this.metroTrackBar_Volume.TabIndex = 1;
            this.metroTrackBar_Volume.UseCustomBackColor = true;
            this.metroTrackBar_Volume.Value = 0;
            this.metroTrackBar_Volume.ValueChanged += new System.EventHandler(this.metroTrackBar_Volume_ValueChanged);
            this.metroTrackBar_Volume.MouseEnter += new System.EventHandler(this.metroTrackBar_Volume_MouseEnter);
            // 
            // metroButton_FileOpen
            // 
            this.metroButton_FileOpen.Highlight = true;
            this.metroButton_FileOpen.Location = new System.Drawing.Point(234, 160);
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
            this.metroButton_Prev.Location = new System.Drawing.Point(346, 190);
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
            this.metroButton_Pause.Location = new System.Drawing.Point(234, 190);
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
            this.metroButton_Resume.Location = new System.Drawing.Point(290, 190);
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
            this.metroButton_Next.Location = new System.Drawing.Point(402, 190);
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
            this.metroButton_Stop.Location = new System.Drawing.Point(458, 190);
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
            this.m_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.M_notifyIcon_MouseClick);
            this.m_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.M_notifyIcon_MouseDoubleClick);
            // 
            // metroButton_Hide
            // 
            this.metroButton_Hide.Highlight = true;
            this.metroButton_Hide.Location = new System.Drawing.Point(514, 190);
            this.metroButton_Hide.Name = "metroButton_Hide";
            this.metroButton_Hide.Size = new System.Drawing.Size(50, 23);
            this.metroButton_Hide.TabIndex = 9;
            this.metroButton_Hide.Text = "Hide";
            this.metroButton_Hide.UseSelectable = true;
            this.metroButton_Hide.Click += new System.EventHandler(this.MetroButton_Hide_Click);
            // 
            // metroCheckBox_Random
            // 
            this.metroCheckBox_Random.Location = new System.Drawing.Point(234, 250);
            this.metroCheckBox_Random.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroCheckBox_Random.Name = "metroCheckBox_Random";
            this.metroCheckBox_Random.Size = new System.Drawing.Size(23, 25);
            this.metroCheckBox_Random.TabIndex = 11;
            this.metroCheckBox_Random.UseSelectable = true;
            this.metroCheckBox_Random.Click += new System.EventHandler(this.MetroCheckBox_Random_Click);
            // 
            // label_RandomOn
            // 
            this.label_RandomOn.AutoSize = true;
            this.label_RandomOn.BackColor = System.Drawing.Color.Transparent;
            this.label_RandomOn.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_RandomOn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label_RandomOn.Location = new System.Drawing.Point(254, 255);
            this.label_RandomOn.Name = "label_RandomOn";
            this.label_RandomOn.Size = new System.Drawing.Size(25, 15);
            this.label_RandomOn.TabIndex = 0;
            this.label_RandomOn.Text = "On";
            this.label_RandomOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_RandomOff
            // 
            this.label_RandomOff.AutoSize = true;
            this.label_RandomOff.BackColor = System.Drawing.Color.Transparent;
            this.label_RandomOff.Enabled = false;
            this.label_RandomOff.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_RandomOff.ForeColor = System.Drawing.Color.Black;
            this.label_RandomOff.Location = new System.Drawing.Point(254, 255);
            this.label_RandomOff.Name = "label_RandomOff";
            this.label_RandomOff.Size = new System.Drawing.Size(27, 15);
            this.label_RandomOff.TabIndex = 0;
            this.label_RandomOff.Text = "Off";
            this.label_RandomOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Random
            // 
            this.label_Random.AutoSize = true;
            this.label_Random.BackColor = System.Drawing.Color.Transparent;
            this.label_Random.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Random.ForeColor = System.Drawing.Color.Black;
            this.label_Random.Location = new System.Drawing.Point(26, 255);
            this.label_Random.Name = "label_Random";
            this.label_Random.Size = new System.Drawing.Size(86, 15);
            this.label_Random.TabIndex = 0;
            this.label_Random.Text = "Random Play";
            // 
            // label_StartOn
            // 
            this.label_StartOn.AutoSize = true;
            this.label_StartOn.BackColor = System.Drawing.Color.Transparent;
            this.label_StartOn.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_StartOn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label_StartOn.Location = new System.Drawing.Point(254, 285);
            this.label_StartOn.Name = "label_StartOn";
            this.label_StartOn.Size = new System.Drawing.Size(25, 15);
            this.label_StartOn.TabIndex = 0;
            this.label_StartOn.Text = "On";
            this.label_StartOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_StartOff
            // 
            this.label_StartOff.AutoSize = true;
            this.label_StartOff.BackColor = System.Drawing.Color.Transparent;
            this.label_StartOff.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_StartOff.ForeColor = System.Drawing.Color.Black;
            this.label_StartOff.Location = new System.Drawing.Point(254, 285);
            this.label_StartOff.Name = "label_StartOff";
            this.label_StartOff.Size = new System.Drawing.Size(27, 15);
            this.label_StartOff.TabIndex = 0;
            this.label_StartOff.Text = "Off";
            this.label_StartOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_StartupProgram
            // 
            this.label_StartupProgram.AutoSize = true;
            this.label_StartupProgram.BackColor = System.Drawing.Color.Transparent;
            this.label_StartupProgram.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_StartupProgram.ForeColor = System.Drawing.Color.Black;
            this.label_StartupProgram.Location = new System.Drawing.Point(26, 285);
            this.label_StartupProgram.Name = "label_StartupProgram";
            this.label_StartupProgram.Size = new System.Drawing.Size(186, 15);
            this.label_StartupProgram.TabIndex = 0;
            this.label_StartupProgram.Text = "Startup Program Registration";
            // 
            // metroCheckBox_StartupPrograms
            // 
            this.metroCheckBox_StartupPrograms.Location = new System.Drawing.Point(234, 280);
            this.metroCheckBox_StartupPrograms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroCheckBox_StartupPrograms.Name = "metroCheckBox_StartupPrograms";
            this.metroCheckBox_StartupPrograms.Size = new System.Drawing.Size(23, 25);
            this.metroCheckBox_StartupPrograms.TabIndex = 12;
            this.metroCheckBox_StartupPrograms.UseSelectable = true;
            this.metroCheckBox_StartupPrograms.Click += new System.EventHandler(this.MetroCheckBox_StartupPrograms_Click);
            // 
            // metroButton_Monitor
            // 
            this.metroButton_Monitor.Highlight = true;
            this.metroButton_Monitor.Location = new System.Drawing.Point(234, 220);
            this.metroButton_Monitor.Name = "metroButton_Monitor";
            this.metroButton_Monitor.Size = new System.Drawing.Size(330, 23);
            this.metroButton_Monitor.TabIndex = 10;
            this.metroButton_Monitor.Text = "Next Monitor";
            this.metroButton_Monitor.UseSelectable = true;
            this.metroButton_Monitor.Click += new System.EventHandler(this.MetroButton_Monitor_Click);
            // 
            // label_Monitor
            // 
            this.label_Monitor.AutoSize = true;
            this.label_Monitor.BackColor = System.Drawing.Color.Transparent;
            this.label_Monitor.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Monitor.ForeColor = System.Drawing.Color.Black;
            this.label_Monitor.Location = new System.Drawing.Point(26, 225);
            this.label_Monitor.Name = "label_Monitor";
            this.label_Monitor.Size = new System.Drawing.Size(93, 15);
            this.label_Monitor.TabIndex = 0;
            this.label_Monitor.Text = "Multi Monitor";
            // 
            // metroButton_Help
            // 
            this.metroButton_Help.Highlight = true;
            this.metroButton_Help.Location = new System.Drawing.Point(234, 310);
            this.metroButton_Help.Name = "metroButton_Help";
            this.metroButton_Help.Size = new System.Drawing.Size(330, 23);
            this.metroButton_Help.TabIndex = 13;
            this.metroButton_Help.Text = "Help";
            this.metroButton_Help.UseSelectable = true;
            this.metroButton_Help.Click += new System.EventHandler(this.MetroButton_Help_Click);
            // 
            // label_Help
            // 
            this.label_Help.AutoSize = true;
            this.label_Help.BackColor = System.Drawing.Color.Transparent;
            this.label_Help.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Help.ForeColor = System.Drawing.Color.Black;
            this.label_Help.Location = new System.Drawing.Point(26, 315);
            this.label_Help.Name = "label_Help";
            this.label_Help.Size = new System.Drawing.Size(34, 15);
            this.label_Help.TabIndex = 0;
            this.label_Help.Text = "Help";
            // 
            // m_metroContextMenu
            // 
            this.m_metroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoNameToolStripMenuItem,
            this.toolStripSeparator1,
            this.volumeToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.toolStripSeparator4,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.pauseToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.prevToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextMonitorToolStripMenuItem,
            this.randomPlayToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.m_metroContextMenu.Name = "m_metroContextMenu";
            this.m_metroContextMenu.ShowCheckMargin = true;
            this.m_metroContextMenu.ShowImageMargin = false;
            this.m_metroContextMenu.Size = new System.Drawing.Size(181, 358);
            // 
            // videoNameToolStripMenuItem
            // 
            this.videoNameToolStripMenuItem.Name = "videoNameToolStripMenuItem";
            this.videoNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.videoNameToolStripMenuItem.Text = "VideoName";
            this.videoNameToolStripMenuItem.Click += new System.EventHandler(this.VideoNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // volumeToolStripMenuItem
            // 
            this.volumeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_VolumeTrackBar});
            this.volumeToolStripMenuItem.Name = "volumeToolStripMenuItem";
            this.volumeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.volumeToolStripMenuItem.Text = "Volume";
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_BrightnessTrackBar});
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "File Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resumeToolStripMenuItem.Text = "Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItem_Click);
            // 
            // prevToolStripMenuItem
            // 
            this.prevToolStripMenuItem.Name = "prevToolStripMenuItem";
            this.prevToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prevToolStripMenuItem.Text = "Prev";
            this.prevToolStripMenuItem.Click += new System.EventHandler(this.PrevToolStripMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.NextToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // nextMonitorToolStripMenuItem
            // 
            this.nextMonitorToolStripMenuItem.Name = "nextMonitorToolStripMenuItem";
            this.nextMonitorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nextMonitorToolStripMenuItem.Text = "Next Monitor";
            this.nextMonitorToolStripMenuItem.Click += new System.EventHandler(this.NextMonitorToolStripMenuItem_Click);
            // 
            // randomPlayToolStripMenuItem
            // 
            this.randomPlayToolStripMenuItem.CheckOnClick = true;
            this.randomPlayToolStripMenuItem.Name = "randomPlayToolStripMenuItem";
            this.randomPlayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.randomPlayToolStripMenuItem.Text = "Random Play";
            this.randomPlayToolStripMenuItem.Click += new System.EventHandler(this.RandomPlayToolStripMenuItem_Click);
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.CheckOnClick = true;
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startupToolStripMenuItem.Text = "Startup Program";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.StartupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Visible = false;
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label_StyleMode
            // 
            this.label_StyleMode.AutoSize = true;
            this.label_StyleMode.BackColor = System.Drawing.Color.Transparent;
            this.label_StyleMode.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_StyleMode.ForeColor = System.Drawing.Color.Black;
            this.label_StyleMode.Location = new System.Drawing.Point(26, 345);
            this.label_StyleMode.Name = "label_StyleMode";
            this.label_StyleMode.Size = new System.Drawing.Size(75, 15);
            this.label_StyleMode.TabIndex = 0;
            this.label_StyleMode.Text = "Style Mode";
            // 
            // m_metroStyleManager
            // 
            this.m_metroStyleManager.Owner = null;
            // 
            // metroButton_Light
            // 
            this.metroButton_Light.Highlight = true;
            this.metroButton_Light.Location = new System.Drawing.Point(234, 340);
            this.metroButton_Light.Name = "metroButton_Light";
            this.metroButton_Light.Size = new System.Drawing.Size(162, 23);
            this.metroButton_Light.TabIndex = 14;
            this.metroButton_Light.Text = "Light";
            this.metroButton_Light.UseSelectable = true;
            this.metroButton_Light.Click += new System.EventHandler(this.MetroButton_Light_Click);
            // 
            // metroButton_Dark
            // 
            this.metroButton_Dark.Highlight = true;
            this.metroButton_Dark.Location = new System.Drawing.Point(402, 340);
            this.metroButton_Dark.Name = "metroButton_Dark";
            this.metroButton_Dark.Size = new System.Drawing.Size(162, 23);
            this.metroButton_Dark.TabIndex = 15;
            this.metroButton_Dark.Text = "Dark";
            this.metroButton_Dark.UseSelectable = true;
            this.metroButton_Dark.Click += new System.EventHandler(this.MetroButton_Dark_Click);



            // 
            // toolStripMenuItem_VolumeTrackBar
            // 
            this.toolStripMenuItem_VolumeTrackBar.Name = "toolStripMenuItem_VolumeTrackBar";
            this.toolStripMenuItem_VolumeTrackBar.Size = new System.Drawing.Size(100, 15);
            this.toolStripMenuItem_VolumeTrackBar.ValueChanged += ToolStripMenuItem_VolumeTrackBar_ValueChanged;
            this.toolStripMenuItem_VolumeTrackBar.MouseEnter += ToolStripMenuItem_VolumeTrackBar_MouseEnter;
            this.toolStripMenuItem_VolumeTrackBar.Minimum = 0;
            this.toolStripMenuItem_VolumeTrackBar.Maximum = 100;
            // 
            // toolStripMenuItem_BrightnessTrackBar
            // 
            this.toolStripMenuItem_BrightnessTrackBar.Name = "toolStripMenuItem_BrightnessTrackBar";
            this.toolStripMenuItem_BrightnessTrackBar.Size = new System.Drawing.Size(100, 15);
            this.toolStripMenuItem_BrightnessTrackBar.ValueChanged += ToolStripMenuItem_BrightnessTrackBar_ValueChanged;
            this.toolStripMenuItem_BrightnessTrackBar.MouseEnter += ToolStripMenuItem_BrightnessTrackBar_MouseEnter;
            this.toolStripMenuItem_BrightnessTrackBar.Minimum = 5;
            this.toolStripMenuItem_BrightnessTrackBar.Maximum = 50;
            this.toolStripMenuItem_BrightnessTrackBar.MouseWheelBarPartitions = 18;



            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(590, 385);
            this.Controls.Add(this.metroButton_Help);
            this.Controls.Add(this.label_Help);
            this.Controls.Add(this.label_Monitor);
            this.Controls.Add(this.metroButton_Monitor);
            this.Controls.Add(this.label_StartOn);
            this.Controls.Add(this.label_StartOff);
            this.Controls.Add(this.label_StartupProgram);
            this.Controls.Add(this.metroCheckBox_StartupPrograms);
            this.Controls.Add(this.metroCheckBox_Random);
            this.Controls.Add(this.label_RandomOn);
            this.Controls.Add(this.label_RandomOff);
            this.Controls.Add(this.label_Random);
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
            this.Controls.Add(this.label_StyleMode);
            this.Controls.Add(this.metroButton_Light);
            this.Controls.Add(this.metroButton_Dark);
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
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.m_metroContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 볼륨 조절 (ContextMenuStrip)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_VolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (m_bTrackBarVolume)
            {
                m_iVolume = toolStripMenuItem_VolumeTrackBar.Value;
                metroTrackBar_Volume.Value = m_iVolume;

                m_setting.iVolume = m_iVolume;
                m_setting.SaveToFile(m_strSettingFile);
            }
            else
            {

            }
        }

        /// <summary>
        /// Mouse Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_VolumeTrackBar_MouseEnter(object sender, EventArgs e)
        {
            m_bTrackBarVolume = true;
        }

        /// <summary>
        /// 밝기 조절 (ContextMenuStrip)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_BrightnessTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (m_bTrackBarBrightness)
            {
                m_iBrightness = toolStripMenuItem_BrightnessTrackBar.Value;
                metroTrackBar_Brightness.Value = m_iBrightness;

                SetBrightness(m_iBrightness);

                m_setting.iBrightness = m_iBrightness;
                m_setting.SaveToFile(m_strSettingFile);
            }
            else
            {

            }
        }

        private void ToolStripMenuItem_BrightnessTrackBar_MouseEnter(object sender, EventArgs e)
        {
            m_bTrackBarBrightness = true;
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
        private MetroFramework.Controls.MetroCheckBox metroCheckBox_Random;
        private System.Windows.Forms.Label label_RandomOn;
        private System.Windows.Forms.Label label_RandomOff;
        private System.Windows.Forms.Label label_Random;
        private System.Windows.Forms.Label label_StartOn;
        private System.Windows.Forms.Label label_StartOff;
        private System.Windows.Forms.Label label_StartupProgram;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox_StartupPrograms;
        private MetroFramework.Controls.MetroButton metroButton_Monitor;
        private System.Windows.Forms.Label label_Monitor;
        private MetroFramework.Controls.MetroButton metroButton_Help;
        private System.Windows.Forms.Label label_Help;
        private MetroFramework.Controls.MetroContextMenu m_metroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem videoNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem volumeToolStripMenuItem;
        private System.Windows.Forms.Label label_StyleMode;
        private MetroFramework.Components.MetroStyleManager m_metroStyleManager;
        private MetroFramework.Controls.MetroButton metroButton_Light;
        private MetroFramework.Controls.MetroButton metroButton_Dark;

        // ConvtextMenuStrip TrackBar
        private ToolStripTrackbarItem toolStripMenuItem_VolumeTrackBar;
        private ToolStripTrackbarItem toolStripMenuItem_BrightnessTrackBar;
    }

    /// <summary>
    /// ContextMenuStrip에 TrackBar를 넣기 위함
    /// https://www.codeproject.com/Tips/274606/Usage-of-a-TrackBar-as-a-ToolStripMenuItem
    /// </summary>
    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip)]
    public class ToolStripTrackbarItem : ToolStripControlHost
    {
        public ToolStripTrackbarItem() : base(CreateControlInstance())
        {
            this.Size = Control.Size;
        }

        public MetroTrackBar MetroTrackBar
        {
            get
            {
                return Control as MetroTrackBar;
            }
        }

        private static Control CreateControlInstance()
        {
            MetroTrackBar metroTrackBar = new MetroTrackBar();
            metroTrackBar.AutoSize = false;

            return metroTrackBar;
        }

        public MetroThemeStyle Theme
        {
            get
            {
                return MetroTrackBar.Theme;
            }
            set
            {
                MetroTrackBar.Theme = value;
            }
        }

        //public MetroStyleManager StyleManager
        //{
        //    get
        //    {
        //        return MetroTrackBar.StyleManager;
        //    }
        //    set
        //    {
        //        MetroTrackBar.StyleManager = value;
        //    }
        //}

        public int Minimum
        {
            get
            {
                return MetroTrackBar.Minimum;
            }
            set
            {
                MetroTrackBar.Minimum = value;
            }
        }

        public int Maximum
        {
            get
            {
                return MetroTrackBar.Maximum;
            }
            set
            {
                MetroTrackBar.Maximum = value;
            }
        }

        public int MouseWheelBarPartitions
        {
            get
            {
                return MetroTrackBar.MouseWheelBarPartitions;
            }
            set
            {
                MetroTrackBar.MouseWheelBarPartitions = value;
            }
        }

        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return MetroTrackBar.Value;
            }
            set
            {
                MetroTrackBar.Value = value;
            }
        }

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            MetroTrackBar metroTrackBar = control as MetroTrackBar;
            metroTrackBar.ValueChanged += new EventHandler(metroTrackBar_ValueChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            MetroTrackBar metroTrackBar = control as MetroTrackBar;
            metroTrackBar.ValueChanged -= new EventHandler(metroTrackBar_ValueChanged);
        }

        void metroTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (this.ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
        }

        public event EventHandler ValueChanged;

    }
}
