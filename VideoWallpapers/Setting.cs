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

                binaryWriter.Close();
            }
        }

        /// <summary>
        /// 파일에서 읽기
        /// </summary>
        /// <param name="strFilename"></param>
        public void LoadFromFile(string strFilename)
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(strFilename, FileMode.Open)))
            {
                strPath = binaryReader.ReadString();
                strName = binaryReader.ReadString();
                iVolume = binaryReader.ReadInt32();
                iBrightness = binaryReader.ReadInt32();

                binaryReader.Close();
            }
        }
    }
}
