using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using System.Xml;


namespace ZbW.Testing.Dms.Client.Services
{
    public class XMLSerialization
    {
        private static XmlSerializer serializer;
        private static FileStream stream;
        

        public void SerializeObject(MetadataItem mdi)
        {
            if (!Directory.Exists(mdi.SavePath))
            {
                Directory.CreateDirectory(mdi.SavePath);
            }

            string path = $@"{mdi.SavePath}\{mdi.XMLFileName}";
            stream = new FileStream(path, FileMode.Create);
            serializer = new XmlSerializer(typeof(MetadataItem));
            serializer.Serialize(stream, mdi);
            stream.Close();

        }

        public MetadataItem DeserializeObject(string XMLFilename)
        {
            serializer = new XmlSerializer(typeof(MetadataItem));
            //string path = $@"{folder} / {XMLFilename}";
            //MessageBox.Show(path);
            stream = new FileStream(XMLFilename,FileMode.Open);
            return (MetadataItem) serializer.Deserialize(stream);
        }

    }
}
