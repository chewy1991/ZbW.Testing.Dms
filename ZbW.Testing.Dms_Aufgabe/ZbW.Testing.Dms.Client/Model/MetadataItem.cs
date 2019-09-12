using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ZbW.Testing.Dms.Client.Model
{
    [ExcludeFromCodeCoverage]
    public class MetadataItem
    {
        // TODO: Write your Metadata properties here
        public string _benutzer { get; set; }
        public string _bezeichnung { get; set; }
        public string _stichwoerter { get; set; }
        public DateTime _erfassungsdatum { get; set; }
        public string _filePath { get; set; }
        public bool _isRemoveFileEnabled { get; set; }
        public string _selectedTypItem { get; set; }
        public DateTime? _valutaDatum { get; set; }

        public Guid _guid { get; set; }

        public string XMLFileName { get; set; }
        public string FileName { get; set; }
        public string SavePath { get; set; }
        public string _Extension { get; set; }
        public MetadataItem() {}

        


        
    }
}