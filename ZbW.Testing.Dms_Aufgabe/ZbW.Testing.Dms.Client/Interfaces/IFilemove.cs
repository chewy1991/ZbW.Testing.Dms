﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Interfaces
{
    public interface IFilemove
    {
        void CopyFile(MetadataItem mdi);
        void OpenFile(string path);
    }
}
