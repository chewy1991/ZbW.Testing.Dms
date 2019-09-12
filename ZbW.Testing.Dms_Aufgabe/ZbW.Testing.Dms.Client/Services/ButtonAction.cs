using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;

namespace ZbW.Testing.Dms.Client.Services
{
    public class ButtonAction
    {
        public void OpenFile(IFilemove filemove, string path)
        {
            if(File.Exists(path))
            filemove.OpenFile(path);
        }
    }
}
