using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class AddingClass
    {
        public bool CheckRequiredFields(string bez, List<string> typ, DateTime? valut)
        {
            if (bez != null && valut != null && typ != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Es müssen alle Pflichtfelder ausgefüllt werden!");
                return false;
            }
        }
        public MetadataItem createMetadataItem(string Benutzer, string Bezeichnung, string Stichwoerter, DateTime Erfassungsdatum, string _filePath, bool IsRemoveFileEnabled, string SelectedTypItem, DateTime? ValutaDatum, Guid guid)
        {
            FileInfo _extension;

            var mdi = new MetadataItem();
            mdi._benutzer = Benutzer;

            mdi._bezeichnung = Bezeichnung;

            if (Stichwoerter == null)
            {
                mdi._stichwoerter = "";
            }
            else
            {
                mdi._stichwoerter = Stichwoerter;
            }

            mdi._erfassungsdatum = Erfassungsdatum;
            mdi._filePath = _filePath;
            mdi._isRemoveFileEnabled = IsRemoveFileEnabled;
            mdi._selectedTypItem = SelectedTypItem;
            mdi._valutaDatum = ValutaDatum.Value;
            mdi._guid = guid;
            mdi.SavePath = CreateSavePath(ValutaDatum);
            mdi.XMLFileName = $"{guid}_Metadata.xml";
            _extension = new FileInfo(_filePath);
            mdi._Extension = _extension.Extension;
            mdi.FileName = $"{guid}_Content{mdi._Extension}";


            return mdi;
        }
        public string CreateSavePath(DateTime? valutaDatum)
        {
            
                var repoDir = ConfigurationManager.AppSettings.Get("RepositoryDir").ToString();
                repoDir += @"\";
                repoDir += valutaDatum.Value.Year;
            
            
            return repoDir;
        }

    }
}
