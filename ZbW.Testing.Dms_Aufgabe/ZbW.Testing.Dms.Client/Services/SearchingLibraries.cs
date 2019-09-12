using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
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

        private List<MetadataItem> _mdis;
        public List<MetadataItem> metadataItemsList
        {
            get { return _mdis; }
            set { _mdis = value; }
        }

        public List<MetadataItem>  GetAllFiles()
        {
            
            XMLSerialization serialization;
            serialization = new XMLSerialization();
            List<MetadataItem> results = new List<MetadataItem>();
            MetadataItem mdi;
            foreach (string e in directories)
            {
                foreach (string d in Directory.GetFiles(e,"*.xml"))
                {
                    mdi = serialization.DeserializeObject((String)d);
                    results.Add(mdi);    
                }

            }

            this.metadataItemsList = results;
            return this.metadataItemsList;
        }
        
        public List<MetadataItem> FileSearch(string Suchbegriff, string DokuTyp)
        {
            var filteredMdi = new List<MetadataItem>();
            foreach (MetadataItem mdi in metadataItemsList)
            {
                if ((String.IsNullOrEmpty(Suchbegriff)) && !(String.IsNullOrEmpty(DokuTyp)))
                {
                    if (mdi._selectedTypItem.Equals(DokuTyp))
                        filteredMdi.Add(mdi);
                }
                if (!(String.IsNullOrEmpty(Suchbegriff)) && !(String.IsNullOrEmpty(DokuTyp)))
                {
                    if ((mdi._stichwoerter.Contains(Suchbegriff) || mdi._bezeichnung.Contains(Suchbegriff)) &&
                        mdi._selectedTypItem.Equals(DokuTyp))
                        filteredMdi.Add(mdi);
                }
                else if ((String.IsNullOrEmpty(Suchbegriff) && String.IsNullOrEmpty(DokuTyp)) || String.IsNullOrEmpty(DokuTyp))
                {
                    MessageBox.Show("Geben Sie einen Suchbegriff und / oder Dokumententyp an!");
                    return null;
                }

            }

            return filteredMdi;

        }
    }
}
