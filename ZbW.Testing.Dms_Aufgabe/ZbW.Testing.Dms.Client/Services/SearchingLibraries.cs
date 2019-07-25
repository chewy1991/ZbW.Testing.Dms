using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SearchingLibraries
    {
        public string[] directories =
            Directory.GetDirectories(ConfigurationManager.AppSettings.Get("RepositoryDir").ToString());

        

        public List<MetadataItem>  FileSearch(string Suchbegriff, string DokuTyp)
        {
            if (Suchbegriff == null)
            {
                Suchbegriff = "";
            }

            if (DokuTyp == null)
            {
                DokuTyp = "";
            }
            XMLSerialization serialization;
            serialization = new XMLSerialization();
            List<MetadataItem> results = new List<MetadataItem>();
            MetadataItem mdi;
            foreach (string e in directories)
            {
                foreach (string d in Directory.GetFiles(e,"*.xml"))
                {
                    
                    
                    mdi = serialization.DeserializeObject(d);

                    
                        results.Add(mdi);
                    

                }

            }
            return results;
        }
    }
}
