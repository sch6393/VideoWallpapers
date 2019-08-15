using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace VideoWallpapers
{
    public class Setting
    {
        public string strPath
        {
            get;
            set;
        } = "";

        public string strName
        {
            get;
            set;
        } = "None";

        public int iVolume
        {
            get;
            set;
        } = 0;

        public int iBrightness
        {
            get;
            set;
        } = 50;

        public bool bRandom
        {
            get;
            set;
        } = false;

        public int iMonitor
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 파일에 저장
        /// </summary>
        /// <param name="strFilename"></param>
        public void SaveToFile(string strFilename)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(strFilename, FileMode.Create)))
            {
                binaryWriter.Write(strPath);
                binaryWriter.Write(strName);
                binaryWriter.Write(iVolume);
                binaryWriter.Write(iBrightness);
                binaryWriter.Write(bRandom);
                binaryWriter.Write(iMonitor);

                binaryWriter.Close();
            }
        }

        /// <summary>
        /// 파일에서 읽기
        /// (바이너리 구조가 바뀌었을 때 에러가 발생하므로 try~catch 추가)
        /// </summary>
        /// <param name="strFilename"></param>
        public void LoadFromFile(string strFilename)
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(strFilename, FileMode.Open)))
            {
                try
                {
                    strPath = binaryReader.ReadString();
                    strName = binaryReader.ReadString();
                    iVolume = binaryReader.ReadInt32();
                    iBrightness = binaryReader.ReadInt32();
                    bRandom = binaryReader.ReadBoolean();
                    iMonitor = binaryReader.ReadInt32();
                }
                catch
                {

                }
                finally
                {
                    binaryReader.Close();
                }
            }
        }
    }
}
