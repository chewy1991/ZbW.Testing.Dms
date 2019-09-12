using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;

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
