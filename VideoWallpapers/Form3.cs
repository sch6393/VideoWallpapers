using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoWallpapers
{
    public partial class Form3 : Form
    {
        /// <summary>
        /// Program 주 진입점 선언
        /// </summary>
        public Program g_program;

        /// <summary>
        /// Background 변수
        /// </summary>
        private bool m_bFixed = false;
        private int m_iMonitor = 0;

        public Form3()
        {
            InitializeComponent();

            Monitor = m_iMonitor;

            Background();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_program.ExitThread();
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

        #region Brightness Control

        protected override void WndProc(ref Message m)
        {
            // WM_NCHITTEST
            if (m.Msg == 0x0084)
            {
                // HTTRANSPARENT
                m.Result = (IntPtr)(-1);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        #endregion

        #region Alt + Tab Unvisible

        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x80;

                return cp;
            }
        }

        #endregion

    }
}
