using System;
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
using System.Runtime.InteropServices;
using System.Threading;

// NuGet
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

        /// <summary>
        /// 밝기 값
        /// </summary>
        public static int m_iBrightness = 50;

        /// <summary>
        /// Background 변수들
        /// </summary>
        public static bool m_bFixed = false;

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

            // 밝기 조절
            SetBrightness(m_iBrightness);

            label_VideoName.Text = "None";
        }

        /// <summary>
        /// 폼 종료 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_notifyIcon.Visible = false;

            // 메모리, 리소스 해제 및 메세지 처리 후 종료
            g_program.ExitThread();

            Dispose();
            Application.Exit();
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
        }

        /// <summary>
        /// 외부에서 폰트 파일 불러와 설정하기
        /// </summary>
        protected void ExternFontFile()
        {
            try
            {
                // PrivateFontCollection에 폰트 메모리 추가
                PrivateFontCollection pivateFontCollection = new PrivateFontCollection();

                // 출력 디렉토리로 복사 설정 = 복사
                pivateFontCollection.AddFontFile(Application.StartupPath + @"\Font\Userfont.ttf");

                m_font = new Font(pivateFontCollection.Families[0], 10, FontStyle.Regular);

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

            if (FNE())
            {
                metroButton_Prev.Enabled = true;
                metroButton_Next.Enabled = true;
            }
            else
            {
                metroButton_Prev.Enabled = false;
                metroButton_Next.Enabled = false;
            }

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

        #endregion

        #region Button Event

        /// <summary>
        /// 파일 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_FileOpen_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\Users\Videos\";
            /// openFileDialog.Filter = "MP3 Audio File (*.mp3) | *.mp3 | Windows Media File(*.wma) | *.wma | WAV Audio File(*.wav) | *.wav | All FILES(*.*) | *.* ";
            /// openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Multiselect      = false;

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

                            m_strFilePath        = strPath;
                            label_VideoPath.Text = strPath;
                            label_VideoName.Text = strName;

                            Play();
                        }
                    }
                }
                catch (Exception)
                {
                    m_strFilePath        = "";
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Pause_Click(object sender, EventArgs e)
        {
            g_program.m_Form2.Pause();

            Select();
        }

        /// <summary>
        /// 다시 재생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Resume_Click(object sender, EventArgs e)
        {
            g_program.m_Form2.Resume();

            Select();
        }

        /// <summary>
        /// 이전 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Prev_Click(object sender, EventArgs e)
        {
            g_program.m_Form2.Prev();

            Select();
        }

        /// <summary>
        /// 다음 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Next_Click(object sender, EventArgs e)
        {
            g_program.m_Form2.Next();

            Select();
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

            g_program.m_Form2.Stop();
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

        #endregion

        #region TrackBar Event

        /// <summary>
        /// 볼륨 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Volume_ValueChanged(object sender, EventArgs e)
        {
            m_iVolume = metroTrackBar_Volume.Value;
            // metroProgressBar_Volume.Value = Convert.ToInt32(metroTrackBar_Volume.Value * 0.98) + 2;
        }

        /// <summary>
        /// 밝기 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            m_iBrightness = metroTrackBar_Brightness.Value;
            // metroProgressBar_Brightness.Value = Convert.ToInt32(metroTrackBar_Brightness.Value * 0.98) + 2;

            SetBrightness(m_iBrightness);
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

        #endregion

    }
}
