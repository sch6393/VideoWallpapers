using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Principal;
using Microsoft.Win32;

namespace VideoWallpapers
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// Background 변수
        /// </summary>
        private bool m_bFixed = false;
        private int m_iMonitor = 0;

        public Form2()
        {
            InitializeComponent();

            Monitor = m_iMonitor;

            Background();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Timer.Stop();
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            SetVolume();
        }

        #region Background

        protected bool Background()
        {
            m_bFixed = VideoWallpapers.Wallpaper.Background(this.Handle);

            if (m_bFixed)
            {
                Utility.FillMonitor(this, MonitorInfo);
            }

            return m_bFixed;
        }

        public WinApi.MONITORINFO MonitorInfo
        {
            get
            {
                if (Monitor < Utility.g_staticMONITORINFO.Length)
                    return Utility.g_staticMONITORINFO[Monitor];

                return new WinApi.MONITORINFO()
                {
                    rcMonitor = Screen.PrimaryScreen.Bounds,
                    rcWork = Screen.PrimaryScreen.WorkingArea,
                };
            }
        }

        public bool Fixed
        {
            get
            {
                return m_bFixed;
            }
        }

        public int Monitor
        {
            get
            {
                return m_iMonitor;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= Screen.AllScreens.Length)
                {
                    value = 0;
                }

                if (m_iMonitor != value)
                {
                    m_iMonitor = value;

                    Background();
                }
            }
        }

        #endregion

        #region WindowsMediaPlayer

        public void Play()
        {
            m_Timer.Start();

            /// SetCurrentEffectPreset();

            axWindowsMediaPlayer.settings.setMode("Loop", true);

            if (Form1.m_bRandom)
            {
                axWindowsMediaPlayer.settings.setMode("Shuffle", true);
            }
            else
            {
                axWindowsMediaPlayer.settings.setMode("Shuffle", false);
            }

            axWindowsMediaPlayer.URL = Form1.m_strFilePath;

            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        public void Pause()
        {
            m_Timer.Stop();

            axWindowsMediaPlayer.Ctlcontrols.pause();
        }

        public void Resume()
        {
            m_Timer.Start();

            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        public void Stop()
        {
            m_Timer.Stop();

            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        public void Prev()
        {
            axWindowsMediaPlayer.Ctlcontrols.previous();
        }

        public void Next()
        {
            axWindowsMediaPlayer.Ctlcontrols.next();
        }

        private void SetVolume()
        {
            axWindowsMediaPlayer.settings.volume = Form1.m_iVolume;
        }

        #endregion

        #region Visualize Preset

        /// <summary>
        /// 시각화 프리셋
        /// </summary>
        /// <param name="value"></param>
        protected void SetCurrentEffectPreset(/*int value*/)
        {
            // CurrentEffectType   = "Battery", "Bars", "Alchemy"
            // CurrentEffectPreset = dword:00000003

            // CurrentDisplayView  = "VizView", "AlbumArtView"
            // UserDisplayView     = "VizView", "AlbumArtView"
            // UserWMPDisplayView  = "VizView", "AlbumArtView"

            // 레지스트리를 건드리는 기능이라서 많이 불안정 -> 보류
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string strPath = string.Format("{0}\\Software\\Microsoft\\MediaPlayer\\Preferences", windowsIdentity.User.Value);
            RegistryKey registryKey = Registry.Users.OpenSubKey(strPath, true);

            if (registryKey == null)
                throw new Exception("Error! Registry not found!");

            registryKey.SetValue("CurrentEffectPreset", 1, RegistryValueKind.DWord);
        }

        #endregion

        #region Alt + Tab Unvisible

        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams createParams = base.CreateParams;

                createParams.ExStyle |= 0x80;

                return createParams;
            }
        }

        #endregion

    }
}
