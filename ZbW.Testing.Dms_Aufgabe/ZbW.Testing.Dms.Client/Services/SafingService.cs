using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SafingService
    {
        public void SafeFile(IFilemove filemove,MetadataItem mdi)
        {
            if (File.Exists(mdi._filePath))
            {
                XMLSerialization serialization = new XMLSerialization();
                serialization.SerializeObject(mdi);
                //FileMove filemove = new FileMove();
                filemove.CopyFile(mdi);
            }
            
        }
    }
}
