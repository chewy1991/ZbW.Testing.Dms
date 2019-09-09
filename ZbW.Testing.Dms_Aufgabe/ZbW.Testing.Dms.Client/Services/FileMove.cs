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
    public class FileMove
    {
        public bool OperationHasHappend { get; set; }
        public void CopyFile(MetadataItem mdi)
        {
            OperationHasHappend = false;
            string copyPath = $@"{mdi.SavePath}\{mdi.FileName}";
            if (File.Exists(mdi._filePath))
            {
                File.Copy(mdi._filePath, copyPath);

                if (mdi._isRemoveFileEnabled == true)
                {
                    File.Delete(mdi._filePath);
                }

                OperationHasHappend = true;
            }
            
        }

        public void OpenFile(string path)
        {
            
            OperationHasHappend = false;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            if (File.Exists(path))
            {
                process.StartInfo.FileName = path;
                process.Start();
                OperationHasHappend = true;
            }
            //else
            //{
            //    throw new FileNotFoundException();
            //}
            
            
        }
    }
}
