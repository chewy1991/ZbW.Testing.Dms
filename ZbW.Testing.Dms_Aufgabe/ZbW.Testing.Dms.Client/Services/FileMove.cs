using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    class FileMove
    {
        public void CopyFile(MetadataItem mdi)
        {
            string copyPath = $@"{mdi.SavePath}\{mdi.FileName}";
            File.Copy(mdi._filePath,copyPath);

            if (mdi._isRemoveFileEnabled == true)
            {
                File.Delete(mdi._filePath);
            }
        }

        public void OpenFile(string path)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = path;
            process.Start();
        }
    }
}
