﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 추가
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

using Microsoft.Win32;

// NuGet
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace VideoWallpapers
{
    public partial class Form1 : MetroForm
    {
        protected const string constStrApplication = "VideoWallpapers";

        /// <summary>
        /// Program 주 진입점 선언
        /// </summary>
        public Program g_program;

        /// <summary>
        /// 폰트 메모리 등록
        /// </summary>
        /// <param name="pbFont"></param>
        /// <param name="cbFont"></param>
        /// <param name="pdv"></param>
        /// <param name="pcFonts"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        /// <summary>
        /// 폰트 선언
        /// </summary>
        protected FontFamily m_fontFamily;
        protected Font m_font;

        /// <summary>
        /// Form2가 필요로 하는 데이터 변수들
        /// (재생할 파일 경로, 볼륨 값)
        /// </summary>
        public static string m_strFilePath = "";
        public static int m_iVolume = 0;
        public static bool m_bRandom = false;

        protected int m_iVolume2 = 0;

        /// <summary>
        /// 밝기 값
        /// </summary>
        protected int m_iBrightness = 50;

        /// <summary>
        /// Background 변수들
        /// (다중 모니터로 인해 각 폼에서 처리하도록 변경)
        /// </summary>
        // public static bool m_bFixed = false;

        /// <summary>
        /// Setting 
        /// </summary>
        /// protected readonly string m_ro_strSettingFile = Path.Combine(Application.StartupPath, constStrApplication + ".dat");
        protected string m_strSettingFile = Path.Combine(Application.StartupPath, constStrApplication + ".dat");
        protected Setting m_setting = new Setting();

        /// <summary>
        /// Style Mode
        /// false : Light, true : Dark
        /// </summary>
        public static bool m_bStyle = false;

        /// <summary>
        /// 투명 라벨
        /// </summary>
        protected TransparentLabel m_transparentLabel = new TransparentLabel();
        // protected TransparentLabelTop m_transparentLabelTop = new TransparentLabelTop();

        /// <summary>
        /// true : 증가, false : 감소
        /// </summary>
        protected bool m_bTransparent = false;
        public static int m_iTransparent = 255;


        /// <summary>
        /// true : toolStripMenuItem, false : metroTrackBar
        /// </summary>
        public bool m_bTrackBarVolume = false;
        public bool m_bTrackBarBrightness = false;

        /// <summary>
        /// 생성자
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            #region Event Handler Register

            /// <summary>
            /// ThreadException 이벤트 핸들러 등록
            /// </summary>
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            /// <summary>
            /// UnhandledException 이벤트 핸들러 등록
            /// </summary>
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);

            #endregion

            FontCollection();
            FontSet(m_font);

            // StyleManager
            StyleManager = m_metroStyleManager;
        }

        /// <summary>
        /// 폼 로딩 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // TEST
            // Form4.DialogCustom("Error!", "File 'AxInterop.WMPLib.dll', 'Interop.WMPLib.dll', 'MetroFramework.dll' Does not Exist in the Startup Path!");

            // 아이콘 생성
            m_notifyIcon.Visible = true;

            LoadSetting();

            // 밝기 조절
            SetBrightness(m_iBrightness);

            // 랜덤 재생 구분
            metroCheckBox_Random.Checked = m_bRandom;
            randomPlayToolStripMenuItem.Checked = m_bRandom;

            // metroCheckBox_Random.Checked = m_bRandom ? true : false;
            // randomPlayToolStripMenuItem.Checked = m_bRandom ? true : false;

            // Style Mode
            StyleMode();

            // 모니터 출력
            if (m_setting.iMonitor != 0)
            {
                // Form4.DialogCustom("Caution!", "Monitor Index is not 0!");

                for (int i = 0; i < m_setting.iMonitor; i++)
                {
                    MetroButton_Monitor_Click(null, e);
                }
            }

            // 시작프로그램 등록 여부
            using (var varKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (varKey.GetValue(constStrApplication) != null)
                {
                    metroCheckBox_StartupPrograms.Checked = true;
                    startupToolStripMenuItem.Checked = true;
                }
                else
                {
                    metroCheckBox_StartupPrograms.Checked = false;
                    startupToolStripMenuItem.Checked = false;
                }
            }

            // 시작프로그램으로 등록되어있을 경우
            if (metroCheckBox_StartupPrograms.Checked)
            {
                Task.Factory.StartNew(new Action(() =>
                {
                    Invoke(new Action(() =>
                    {
                        HideWindow();
                    }));
                }));

                Thread.Sleep(100);

                label_StartOn.Visible = true;
                label_StartOff.Visible = false;
            }
            else
            {
                label_StartOn.Visible = false;
                label_StartOff.Visible = true;
            }

            // label_VideoName.Text = "None";

            if (label_VideoPath.Text == string.Empty)
            {
                Stop();
            }
            else
            {
                Play();
            }
        }

        /// <summary>
        /// 폼 로딩이 끝난 후
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            VersionCheck();
        }

        /// <summary>
        /// 폼 종료 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProgramExit();
        }

        #region Event Handler

        /// <summary>
        /// 미처리 예외를 캐치 하는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowErrorMessage(e.Exception, "Application_ThreadException.");
        }

        /// <summary>
        /// 미처리 예외를 캐치 하는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                ShowErrorMessage(exception, "An Unhandled Exception Occurred!");
            }
        }

        /// <summary>
        /// 에러 메시지
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="extraMessage"></param>
        protected static void ShowErrorMessage(Exception exception, string strMessage)
        {
            Form4.DialogCustom("Unexpected Error Occurred!", "A Problem With The File or Assembly!");

            //MessageBox.Show(strMessage
            //    + "\n\n"
            //    + "예기치 않은 오류가 발생하였습니다."
            //    + "\n\n"
            //    + exception.Message
            //    + "\n\n"
            // );

            Environment.Exit(0);
        }

        #endregion

        #region Font

        /// <summary>
        /// 폰트 컬렉션 생성
        /// </summary>
        protected void FontCollection()
        {
            // 해당 폰트 길이만큼 바이트 배열 생성
            byte[] byteFontArray = Properties.Resources.NanumGothic;
            int iLength = Properties.Resources.NanumGothic.Length;

            // 메모리를 생성한 후 바이트 배열을 복사
            IntPtr ptrData = Marshal.AllocCoTaskMem(iLength);
            Marshal.Copy(byteFontArray, 0, ptrData, iLength);

            // 폰트 리소스 메모리 추가
            uint uiFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)byteFontArray.Length, IntPtr.Zero, ref uiFonts);

            // PrivateFontCollection 폰트 메모리 추가
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddMemoryFont(ptrData, iLength);

            // 남은 메모리 반환
            Marshal.FreeCoTaskMem(ptrData);

            // 초기값
            m_fontFamily = privateFontCollection.Families[0];
            m_font = new Font(m_fontFamily, 15f, FontStyle.Regular);
        }

        /// <summary>
        /// 폰트 설정
        /// </summary>
        /// <param name="font"></param>
        protected void FontSet(Font font)
        {
            // label_Title.Font = new Font(m_fontFamily, 16, FontStyle.Regular);

            label_Name.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_VideoName.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_VideoPath.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_FileOpen.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_Volume.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_Brightness.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_Buttons.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_Random.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_RandomOn.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_RandomOff.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_StartupProgram.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_StartOn.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label_StartOff.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_Monitor.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_Help.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            label_StyleMode.Font = new Font(m_fontFamily, 10, FontStyle.Regular);

            m_metroContextMenu.Font = new Font(m_fontFamily, 10, FontStyle.Regular); ;
        }

        /// <summary>
        /// 외부에서 폰트 파일 불러와 설정하기
        /// </summary>
        protected void ExternFontFile()
        {
            try
            {
                // PrivateFontCollection에 폰트 메모리 추가
                PrivateFontCollection privateFontCollection = new PrivateFontCollection();

                // 출력 디렉토리로 복사 설정 = 복사
                privateFontCollection.AddFontFile(Application.StartupPath + @"\Font\Userfont.ttf");

                m_font = new Font(privateFontCollection.Families[0], 10, FontStyle.Regular);

                FontSet(m_font);
            }
            catch (Exception)
            {
                // MessageBox.Show("Font 폴더에 'Userfont.ttf' 파일이 존재하지 않습니다!\n시스템 기본 폰트로 실행합니다.", "에러 발생", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Form4.DialogCustom("Error!", "'Userfont.ttf' File Does not Exist in the Font Folder! Run as the System Default Font!");
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// 밝기 조절
        /// Form3의 기본 Opacity 값은 50%으로 설정
        /// </summary>
        protected void SetBrightness(int itmp)
        {
            float ftmp = itmp * 0.01f;

            if (ftmp < 0.5f)
            {
                g_program.m_Form3.Opacity = 1 - (2 * ftmp);
                g_program.m_Form3.BackColor = Color.Black;
            }
            else
            {
                g_program.m_Form3.Opacity = 2 * (ftmp - 0.5f);
                g_program.m_Form3.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 재생
        /// </summary>
        protected void Play()
        {
            Stop();

            ObjectActive(m_bRandom);

            g_program.m_Form2.Play();
        }

        /// <summary>
        /// 정지
        /// </summary>
        protected void Stop()
        {
            g_program.m_Form2.Stop();
        }

        /// <summary>
        /// File Name Extension 구분
        /// </summary>
        /// <returns></returns>
        protected bool FNE()
        {
            if (label_VideoPath.Text.Length != 0)
            {
                int itmp = label_VideoPath.Text.LastIndexOf(".");
                string strFNE = label_VideoPath.Text.Substring(itmp + 1, 3);

                // 리스트를 지원하는 확장자 추가
                if (strFNE == "wpl" || strFNE == "m3u")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 숨기기
        /// </summary>
        protected void HideWindow()
        {
            Hide();

            m_notifyIcon.ShowBalloonTip(1000, constStrApplication, "Click to Open!", ToolTipIcon.None);
        }

        /// <summary>
        /// 재활성화
        /// </summary>
        protected void ShowWindow()
        {
            Visible = true;

            if (WindowState == FormWindowState.Minimized)
            {
                // 최소화 멈춤
                WindowState = FormWindowState.Normal;
            }

            Activate();
        }

        /// <summary>
        /// 랜덤 재생 시 오브젝트 설정
        /// true : 랜덤 재생 ON, false : 랜덤 재생 OFF
        /// </summary>
        /// <param name="bFlag"></param>
        protected void ObjectActive(bool bFlag)
        {
            if (FNE())
            {
                metroCheckBox_Random.Enabled = true;
                metroButton_Prev.Enabled = true;
                metroButton_Next.Enabled = true;
                label_RandomOn.Enabled = true;
                label_RandomOff.Enabled = true;

                randomPlayToolStripMenuItem.Enabled = true;
                prevToolStripMenuItem.Enabled = true;
                nextToolStripMenuItem.Enabled = true;
            }
            else
            {
                metroCheckBox_Random.Enabled = false;
                metroButton_Prev.Enabled = false;
                metroButton_Next.Enabled = false;
                label_RandomOn.Enabled = false;
                label_RandomOff.Enabled = false;

                randomPlayToolStripMenuItem.Enabled = false;
                prevToolStripMenuItem.Enabled = false;
                nextToolStripMenuItem.Enabled = false;
            }

            metroCheckBox_Random.Checked = bFlag;
            label_RandomOn.Visible = bFlag;
            label_RandomOff.Visible = !bFlag;
        }

        /// <summary>
        /// 파일 열기
        /// </summary>
        protected void FileOpen()
        {
            Stream stream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\Users\Videos\";
            /// openFileDialog.Filter = "MP3 Audio File (*.mp3) | *.mp3 | Windows Media File(*.wma) | *.wma | WAV Audio File(*.wav) | *.wav | All FILES(*.*) | *.* ";
            /// openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            string strPath = openFileDialog.FileName;
                            string strName = openFileDialog.SafeFileName;

                            m_strFilePath = strPath;
                            label_VideoPath.Text = strPath;
                            label_VideoName.Text = strName;

                            SaveSetting();

                            Play();
                        }
                    }
                }
                catch (Exception)
                {
                    m_strFilePath = "";
                    label_VideoPath.Text = "";
                    label_VideoName.Text = "";

                    // MessageBox.Show("에러! 파일을 열 수 없습니다!");
                    Form4.DialogCustom("Error!", "Can not Open File!");
                }
            }
        }

        /// <summary>
        /// 일시 정지
        /// </summary>
        protected void Pause()
        {
            g_program.m_Form2.Pause();

            // Select();
        }

        /// <summary>
        /// 다시 재생
        /// </summary>
        protected void Resume()
        {
            g_program.m_Form2.Resume();

            // Select();
        }

        /// <summary>
        /// 이전 목록
        /// </summary>
        protected void Prev()
        {
            g_program.m_Form2.Prev();

            // Select();
        }

        /// <summary>
        /// 다음 목록
        /// </summary>
        protected void Next()
        {
            g_program.m_Form2.Next();

            // Select();
        }

        /// <summary>
        /// 출력 모니터 변경
        /// </summary>
        protected void MultiMonitor()
        {
            // 화면 전환
            g_program.m_Form2.Monitor++;
            g_program.m_Form3.Monitor++;

            // 전환에 성공하였으면 설정을 저장하고 그렇지 않으면 정지
            if (g_program.m_Form2.Fixed && g_program.m_Form3.Fixed)
            {
                m_setting.iMonitor = g_program.m_Form2.Monitor;
                m_setting.SaveToFile(m_strSettingFile);
            }
            else
            {
                // MessageBox.Show("출력 모니터를 변경할 수 없습니다.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form4.DialogCustom("Error!", "Can not Change Output Monitor!");
            }
        }

        /// <summary>
        /// 랜덤 재생
        /// </summary>
        protected void RandomPlay(object objSender)
        {
            // 체크박스를 풀어도 목록 리스트가 새로 정렬이 되지 않음 (랜덤이 된 리스트를 그대로 가져옴)

            // 해결방안 1. axWindowsMediaPlayer의 메모리를 해제했다가 다시 할당
            // → 실패 (참조 오류 발생, 컨트롤을 Form Design에서 생성하면 안됨, 좀 더 확인이 필요)

            // 해결방안 2. Form2의 메모리를 해제했다가 다시 할당
            // → 실패 (Form3도 같이 진행되어야만 가능하나 Form3는 ApplicationContext의 상속을 받고 있어 안됨)

            // 해결방안 3. Loop와 Shuffle은 서로 다른 기능
            // → 성공 (Loop는 영상 또는 목록의 반복 재생을 설정하고 Shuffle은 목록 재생을 랜덤으로 할지를 설정)

            // m_bRandom = metroCheckBox_Random.Checked ? true : false;

            if (objSender.Equals(metroCheckBox_Random))
            {
                m_bRandom = metroCheckBox_Random.Checked ? true : false;
                randomPlayToolStripMenuItem.Checked = m_bRandom;
            }
            else
            {
                m_bRandom = randomPlayToolStripMenuItem.Checked ? true : false;
                metroCheckBox_Random.Checked = m_bRandom;
            }

            m_setting.bRandom = m_bRandom;
            m_setting.SaveToFile(m_strSettingFile);

            Play();
        }

        /// <summary>
        /// 시작 프로그램 등록
        /// </summary>
        protected void StartupPrograms(object objSender)
        {
            using (var varKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (objSender.Equals(metroCheckBox_StartupPrograms))
                {
                    if (metroCheckBox_StartupPrograms.Checked)
                    {
                        varKey.SetValue(constStrApplication, Application.ExecutablePath.ToString());
                        label_StartOn.Visible = true;
                        label_StartOff.Visible = false;
                        startupToolStripMenuItem.Checked = true;

                        // MessageBox.Show("등록 성공!", "시작 프로그램 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        varKey.DeleteValue(constStrApplication, false);
                        label_StartOn.Visible = false;
                        label_StartOff.Visible = true;
                        startupToolStripMenuItem.Checked = false;

                        // MessageBox.Show("해제 성공!", "시작 프로그램 해제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (startupToolStripMenuItem.Checked)
                    {
                        varKey.SetValue(constStrApplication, Application.ExecutablePath.ToString());
                        label_StartOn.Visible = true;
                        label_StartOff.Visible = false;
                        metroCheckBox_StartupPrograms.Checked = true;

                        // MessageBox.Show("등록 성공!", "시작 프로그램 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        varKey.DeleteValue(constStrApplication, false);
                        label_StartOn.Visible = false;
                        label_StartOff.Visible = true;
                        metroCheckBox_StartupPrograms.Checked = false;

                        // MessageBox.Show("해제 성공!", "시작 프로그램 해제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 도움말
        /// </summary>
        protected void Help()
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        /// <summary>
        /// 프로그램 종료
        /// </summary>
        protected void ProgramExit()
        {
            m_notifyIcon.Visible = false;

            // 메모리, 리소스 해제 및 메세지 처리 후 종료
            g_program.ExitThread();

            Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Style Mode
        /// </summary>
        protected void StyleMode()
        {
            MetroThemeStyle metroThemeStyle = m_bStyle ? MetroThemeStyle.Dark : MetroThemeStyle.Light;

            m_metroStyleManager.Theme = metroThemeStyle;

            // Metro 오브젝트가 StyleManager로 변경이 안됨 (???)
            // Label의 경우 Metro에 속해있지 않아서 직접 색깔을 변경해줘야 함
            foreach (Control control in Controls)
            {
                if (typeof(MetroButton) == control.GetType())
                {
                    (control as MetroButton).Theme = metroThemeStyle;
                }
                else if (typeof(MetroCheckBox) == control.GetType())
                {
                    (control as MetroCheckBox).Theme = metroThemeStyle;
                }
                else if (typeof(MetroTrackBar) == control.GetType())
                {
                    (control as MetroTrackBar).Theme = metroThemeStyle;
                }
                // ContextMenuStrip 적용 안되던 문제 해결
                // StyleManager의 Theme 기본 값이 Default로 적용되지 않아서 생긴 문제
                else if (typeof(MetroContextMenu) == control.GetType())
                {
                    (control as MetroContextMenu).Theme = metroThemeStyle;
                }
                else if (typeof(Label) == control.GetType())
                {
                    if (control.Name == label_RandomOn.Name ||
                        control.Name == label_StartOn.Name)
                        continue;
                    else
                    {
                        (control as Label).ForeColor = (metroThemeStyle == MetroThemeStyle.Light) ? Color.Black : Color.White;
                    }
                }
            }

            m_setting.bStyle = m_bStyle;
            m_setting.SaveToFile(m_strSettingFile);

            // 오브젝트가 자동으로 업데이트 되지 않음
            Refresh();
        }

        /// <summary>
        /// 버전 체크
        /// </summary>
        protected async void VersionCheck()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string strtmp = await webClient.DownloadStringTaskAsync(@"https://raw.githubusercontent.com/sch6393/VideoWallpapers/master/VideoWallpapers/Properties/AssemblyInfo.cs");

                    int iStart = strtmp.LastIndexOf("AssemblyVersion");

                    iStart = strtmp.IndexOf('\"', iStart) + 1;
                    int iEnd = strtmp.IndexOf('\"', iStart);

                    string strVersion = strtmp.Substring(iStart, iEnd - iStart);

                    if (Version.Parse(strVersion) > Version.Parse(Application.ProductVersion))
                    {
                        TransparentLabel();

                        TransparentLabelTop transparentLabelTop = new TransparentLabelTop();
                        transparentLabelTop.Height = 16;
                        transparentLabelTop.Width = 151;
                        transparentLabelTop.Top = 40;
                        transparentLabelTop.Left = 415;
                        transparentLabelTop.Text = "TOPTOPTOPTOPTOP";
                        transparentLabelTop.Font = new Font(m_fontFamily, 10, FontStyle.Bold);
                        this.Controls.Add(transparentLabelTop);
                        transparentLabelTop.Visible = true;
                        transparentLabelTop.BringToFront();
                        transparentLabelTop.Cursor = Cursors.Hand;
                        transparentLabelTop.Click += TransparentLabelTop_Click; ;

                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = 100;
                        timer.Tick += Timer_Tick;
                        timer.Enabled = true;
                    }
                }
                catch (WebException )//webEx)
                {
                    Form4.DialogCustom("Caution!", "Unable to Check Version Without Internet Connection!");
                }
                catch (Exception )//ex)
                {
                    Form4.DialogCustom("Error!", "Failed to Version Check!");
                }
            }
        }

        /// <summary>
        /// 투명 라벨 소멸 & 생성
        /// </summary>
        protected void TransparentLabel()
        {
            m_transparentLabel.Dispose();

            m_transparentLabel = new TransparentLabel();
            m_transparentLabel.Height = 16;
            m_transparentLabel.Width = 151;
            m_transparentLabel.Top = 40;
            m_transparentLabel.Left = 415;
            m_transparentLabel.Text = "New Version Available";
            m_transparentLabel.Font = new Font(m_fontFamily, 10, FontStyle.Bold);
            m_transparentLabel.ForeColor = Color.DeepSkyBlue;
            this.Controls.Add(m_transparentLabel);
            m_transparentLabel.Visible = true;
            // m_transparentLabel.BringToFront();
            // m_transparentLabel.SendToBack();
            // m_transparentLabel.Cursor = Cursors.Hand;
            // m_transparentLabel.Click += M_transparentLabel_Click;
        }

        /// <summary>
        /// 정주기 (100ms)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (m_bTransparent)
            {
                m_iTransparent += 20;
            }
            else
            {
                m_iTransparent -= 20;
            }

            if (m_iTransparent > 235)
            {
                m_bTransparent = false;
            }
            else if (m_iTransparent < 235 && m_iTransparent > 25)
            {

            }
            else if (m_iTransparent < 25)
            {
                m_bTransparent = true;
            }

            TransparentLabel();
        }

        /// <summary>
        /// New Version Available 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransparentLabelTop_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/sch6393/VideoWallpapers/releases");
        }

        #endregion

        #region Setting

        /// <summary>
        /// Setting 파일 로드
        /// </summary>
        protected void LoadSetting()
        {
            if (File.Exists(m_strSettingFile))
            {
                m_setting.LoadFromFile(m_strSettingFile);
            }

            ApplySetting();
        }

        /// <summary>
        /// Setting 파일 저장
        /// </summary>
        protected void SaveSetting()
        {
            m_setting.strPath = label_VideoPath.Text;
            m_setting.strName = label_VideoName.Text;
            m_setting.iVolume = metroTrackBar_Volume.Value;
            m_setting.iBrightness = metroTrackBar_Brightness.Value;
            m_setting.bRandom = m_bRandom;
            m_setting.bStyle = m_bStyle;

            m_setting.SaveToFile(m_strSettingFile);
        }

        /// <summary>
        /// Setting 파일 적용
        /// </summary>
        protected void ApplySetting()
        {
            m_strFilePath = m_setting.strPath;
            label_VideoPath.Text = m_setting.strPath;
            label_VideoName.Text = m_setting.strName;

            m_iVolume = m_setting.iVolume;
            metroTrackBar_Volume.Value = m_setting.iVolume;

            m_iBrightness = m_setting.iBrightness;
            metroTrackBar_Brightness.Value = m_setting.iBrightness;

            m_bRandom = m_setting.bRandom;

            m_bStyle = m_setting.bStyle;

            ObjectActive(m_bRandom);
        }

        #endregion


        #region Button Event

        /// <summary>
        /// 파일 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_FileOpen_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        /// <summary>
        /// 일시 정지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Pause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        /// <summary>
        /// 다시 재생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Resume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        /// <summary>
        /// 이전 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Prev_Click(object sender, EventArgs e)
        {
            Prev();
        }

        /// <summary>
        /// 다음 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Next_Click(object sender, EventArgs e)
        {
            Next();
        }

        /// <summary>
        /// 정지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Stop_Click(object sender, EventArgs e)
        {
            m_strFilePath        = "";
            label_VideoPath.Text = "";
            label_VideoName.Text = "None";

            m_setting.strPath = "";
            m_setting.strName = "None";
            m_setting.SaveToFile(m_strSettingFile);

            Stop();
        }

        /// <summary>
        /// 숨기기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Hide_Click(object sender, EventArgs e)
        {
            HideWindow();
        }

        /// <summary>
        /// 출력 모니터 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Monitor_Click(object sender, EventArgs e)
        {
            MultiMonitor();
        }

        /// <summary>
        /// 도움말
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Help_Click(object sender, EventArgs e)
        {
            Help();
        }

        /// <summary>
        /// Light
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Light_Click(object sender, EventArgs e)
        {
            m_bStyle = false;

            StyleMode();
        }

        /// <summary>
        /// Dark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Dark_Click(object sender, EventArgs e)
        {
            m_bStyle = true;

            StyleMode();
        }

        #endregion

        #region TrackBar Event

        /// <summary>
        /// 볼륨 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Volume_ValueChanged(object sender, EventArgs e)
        {
            if (m_bTrackBarVolume)
            {

            }
            else
            {
                m_iVolume = metroTrackBar_Volume.Value;
                toolStripMenuItem_VolumeTrackBar.Value = m_iVolume;

                m_setting.iVolume = m_iVolume;
                m_setting.SaveToFile(m_strSettingFile);
            }
        }

        /// <summary>
        /// Mouse Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Volume_MouseEnter(object sender, EventArgs e)
        {
            m_bTrackBarVolume = false;
        }

        /// <summary>
        /// 밝기 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            if (m_bTrackBarBrightness)
            {

            }
            else
            {
                m_iBrightness = metroTrackBar_Brightness.Value;

                SetBrightness(m_iBrightness);

                m_setting.iBrightness = m_iBrightness;
                m_setting.SaveToFile(m_strSettingFile);
            }
        }

        /// <summary>
        /// Mouse Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Brightness_MouseEnter(object sender, EventArgs e)
        {
            m_bTrackBarBrightness = false;
        }

        #endregion

        #region NotifyIcon Event

        /// <summary>
        /// 팁 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowWindow();
        }

        /// <summary>
        /// 아이콘 더블 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        /// <summary>
        /// 아이콘 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // 우클릭시
            if (e.Button == MouseButtons.Right)
            {
                m_notifyIcon.ContextMenuStrip = m_metroContextMenu;

                MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                methodInfo.Invoke(m_notifyIcon, null);

                videoNameToolStripMenuItem.Text = label_VideoName.Text;

                if (m_bStyle)
                {
                    toolStripMenuItem_VolumeTrackBar.Theme = MetroThemeStyle.Dark;
                    toolStripMenuItem_BrightnessTrackBar.Theme = MetroThemeStyle.Dark;
                }
                else
                {
                    toolStripMenuItem_VolumeTrackBar.Theme = MetroThemeStyle.Light;
                    toolStripMenuItem_BrightnessTrackBar.Theme = MetroThemeStyle.Light;
                }

                toolStripMenuItem_VolumeTrackBar.Value = m_iVolume;
                toolStripMenuItem_BrightnessTrackBar.Value = m_iBrightness;
            }
        }

        #endregion

        #region CheckBox Event

        /// <summary>
        /// 랜덤 재생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroCheckBox_Random_Click(object sender, EventArgs e)
        {
            RandomPlay(sender);
        }

        /// <summary>
        /// 시작 프로그램 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroCheckBox_StartupPrograms_Click(object sender, EventArgs e)
        {
            StartupPrograms(sender);
        }

        #endregion

        #region ContextMenuStrip Event

        /// <summary>
        /// 재활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        /// <summary>
        /// 파일 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        /// <summary>
        /// 일시 정지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
        }

        /// <summary>
        /// 다시 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resume();
        }

        /// <summary>
        /// 이전 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prev();
        }

        /// <summary>
        /// 다음 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Next();
        }

        /// <summary>
        /// 정지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_strFilePath = "";
            label_VideoPath.Text = "";
            label_VideoName.Text = "None";

            m_setting.strPath = "";
            m_setting.strName = "None";
            m_setting.SaveToFile(m_strSettingFile);

            Stop();
        }

        /// <summary>
        /// 출력 모니터 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiMonitor();
        }

        /// <summary>
        /// 랜덤 재생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomPlay(sender);
        }

        /// <summary>
        /// 시작 프로그램 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartupPrograms(sender);
        }

        /// <summary>
        /// 도움말
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help();
        }

        /// <summary>
        /// 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramExit();
        }

        #region 미사용 (텍스트 입력 방식이라서 불편함)

        ///// <summary>
        ///// 숫자, 백스페이스, 엔터
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void VolumeSetToolStripMenuItem_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // BackSpace
        //    if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 13)
        //    {
        //        e.Handled = true;
        //    }
        //    // Enter
        //    else if (e.KeyChar == 13)
        //    {
        //        int itmp = Convert.ToInt32(volumeSetToolStripMenuItem.Text);

        //        if (itmp < 0 || itmp > 100)
        //        {
        //            Form4.DialogCustom("Error!", "Please Input 0 ~ 100!");
        //            return;
        //        }

        //        m_iVolume = Convert.ToInt32(volumeSetToolStripMenuItem.Text);
        //        metroTrackBar_Volume.Value = m_iVolume;

        //        m_setting.iVolume = metroTrackBar_Volume.Value;
        //        m_setting.SaveToFile(m_strSettingFile);
        //    }
        //}

        //private void VolumeSetToolStripMenuItem_Leave(object sender, EventArgs e)
        //{
        //    return;
        //}

        ///// <summary>
        ///// 숫자, 백스페이스, 엔터
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BrightnessSetToolStripMenuItem_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // BackSpace
        //    if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 13)
        //    {
        //        e.Handled = true;
        //    }
        //    // Enter
        //    else if (e.KeyChar == 13)
        //    {
        //        int itmp = Convert.ToInt32(brightnessSetToolStripMenuItem.Text);

        //        if (itmp < 10 || itmp > 100)
        //        {
        //            Form4.DialogCustom("Error!", "Please Input 10 ~ 100!");
        //            return;
        //        }

        //        m_iBrightness = Convert.ToInt32(brightnessSetToolStripMenuItem.Text);
        //        m_iBrightness /= 2;

        //        metroTrackBar_Brightness.Value = m_iBrightness;

        //        m_setting.iBrightness = metroTrackBar_Brightness.Value;
        //        m_setting.SaveToFile(m_strSettingFile);
        //    }
        //}

        //private void BrightnessSetToolStripMenuItem_Leave(object sender, EventArgs e)
        //{
        //    return;
        //}

        #endregion

        #endregion

    }

    #region Transparent Label Class

    /// <summary>
    /// 투명 라벨
    /// </summary>
    public class TransparentLabel : Control
    {

        public TransparentLabel()
        {
            TabStop = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x20;

                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(Form1.m_iTransparent, 0, 191, 255)))
            {
                e.Graphics.DrawString(Text, Font, solidBrush, -1, 0);
            }
        }
    }

    /// <summary>
    /// 투명 라벨 Top
    /// </summary>
    public class TransparentLabelTop : Control
    {

        public TransparentLabelTop()
        {
            TabStop = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x20;

                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0, 0, 0, 0)))
            {
                e.Graphics.DrawString(Text, Font, solidBrush, -1, 0);
            }
        }
    }

    #endregion

}
