using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Media;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Repositories;

    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;
        private Guid _Guid;
        private string guid;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;
        private FileInfo _extension;

        private DateTime? _valutaDatum;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }

        private bool CheckRequiredFields()
        {
            if (Bezeichnung != null && ValutaDatum != null && TypItems != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Es müssen alle Pflichtfelder ausgefüllt werden!");
                return false;
            }
        }

        private MetadataItem createMetadataItem()
        {
            
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
            mdi._guid = _Guid;
            mdi.SavePath = CreateSavePath();
            mdi.XMLFileName = $"{guid}_Metadata.xml" ;
            _extension = new FileInfo(_filePath);
            mdi._Extension = _extension.Extension;
            mdi.FileName = $"{guid}_Content{mdi._Extension}";
            

            return mdi;
        }

        private string CreateSavePath()
        {
            
            var repoDir = ConfigurationManager.AppSettings.Get("RepositoryDir").ToString();
            repoDir+= @"\";
            repoDir += _valutaDatum.Value.Year; 
            return repoDir;
        }

        

        
        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            _Guid = Guid.NewGuid();
            guid = _Guid.ToString();

            MetadataItem mdi = createMetadataItem();
            // TODO: Add your Code here
            CheckRequiredFields();
            MessageBox.Show(mdi.SavePath);
            

            XMLSerialization serialization = new XMLSerialization();
            serialization.SerializeObject(createMetadataItem());
            FileMove filemove = new FileMove();
            filemove.CopyFile(mdi);


            _navigateBack();
        }
    }
}