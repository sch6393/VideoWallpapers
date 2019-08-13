using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace VideoWallpapers
{
    /// <summary>
    /// ApplicationContext 상속을 받고 클래스를 Public으로 변경
    /// </summary>
    public class Program : ApplicationContext
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NFWCheck();
            DLLFileCheck();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }

        /// <summary>
        /// Form 변수 선언
        /// </summary>
        public Form1 m_Form1 = new Form1();
        public Form2 m_Form2 = new Form2();
        public Form3 m_Form3 = new Form3();

        /// <summary>
        /// 선언자
        /// </summary>
        Program()
        {
            m_Form1.g_program = m_Form3.g_program = this;
            m_Form1.Show();
            m_Form2.Show();

            // Form3가 밝기 조절 폼이므로 맨 마지막에 실행되어야 함
            m_Form3.Show();
        }

        #region .Net Version Check

        /// <summary>
        /// 넷프레임워크 버전 체크
        /// </summary>
        static void NFWCheck()
        {
            string strNFWVer = Environment.Version.ToString();

            // v4.6 기준
            string strNFWVer1 = strNFWVer.Substring(0, 1);      // 4
            // string strNFWVer2 = strNFWVer.Substring(4, 5);   // 30319
            string strNFWVer3 = strNFWVer.Substring(10, 5);     // 42000

            int iNFWVer1 = Convert.ToInt32(strNFWVer1);
            // int iNFWVer2 = Convert.ToInt32(strNFWVer2);
            int iNFWVer3 = Convert.ToInt32(strNFWVer3);

            if (iNFWVer1 < 4 || iNFWVer3 < 34209)
            {
                // m_NotifyIcon.Visible = false;

                // MessageBox.Show("NET Framework v4.5.2 이상 버전을 설치해주세요!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form4.DialogCustom("Error!", "Please Install .NET Framework v4.5.2 or Later Version!");
                Environment.Exit(0);
            }
        }

        #endregion

        #region DLL File Check

        /// <summary>
        /// DLL 파일 체크
        /// </summary>
        static void DLLFileCheck()
        {
            string strAxIWMP = Application.StartupPath + "/AxInterop.WMPLib.dll";
            string strIWMP = Application.StartupPath + "/Interop.WMPLib.dll";
            string strMetro = Application.StartupPath + "/MetroFramework.dll";

            FileInfo fileInfo_AxI = new FileInfo(strAxIWMP);
            FileInfo fileInfo_I = new FileInfo(strIWMP);

            if (!fileInfo_AxI.Exists || !fileInfo_I.Exists)
            {
                // MessageBox.Show("시작 경로에 'AxInterop.WMPLib.dll', 'Interop.WMPLib.dll', 'MetroFramework.dll'이 없습니다!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form4.DialogCustom("Error!", "File 'AxInterop.WMPLib.dll', 'Interop.WMPLib.dll', 'MetroFramework.dll' Does not Exist in the Startup Path!");

                // m_NotifyIcon.Visible = false;

                Environment.Exit(0);
            }
        }

        #endregion

    }
}
