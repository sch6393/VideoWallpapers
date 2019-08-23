using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Runtime.InteropServices;

using MetroFramework.Forms;

namespace VideoWallpapers
{
    public partial class Form5 : MetroForm
    {
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

        public Form5()
        {
            InitializeComponent();

            FontCollection();
            FontSet(m_font);
        }

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

            label1.Font = new Font(m_fontFamily, 10, FontStyle.Bold);
            label2.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            label3.Font = new Font(m_fontFamily, 10, FontStyle.Bold);
            label4.Font = new Font(m_fontFamily, 10, FontStyle.Bold);

            linkLabel1.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            linkLabel2.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            linkLabel3.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
            linkLabel4.Font = new Font(m_fontFamily, 10, FontStyle.Regular);
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

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://support.microsoft.com/en-us/help/316992/file-types-supported-by-windows-media-player");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://support.microsoft.com/en-us/help/926373/you-receive-a-codec-error-message--or-audio-plays-but-video-does-not-p");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://support.microsoft.com/en-us/help/268260/how-to-export-a-playlist-in-windows-media-player");
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sch6393");
        }
    }
}
