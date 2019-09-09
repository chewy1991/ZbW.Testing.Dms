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
        public bool OperationHappened;
        

        public void SerializeObject(MetadataItem mdi)
        {
            OperationHappened = false;
            if (!Directory.Exists(mdi.SavePath))
            {
                Directory.CreateDirectory(mdi.SavePath);
            }

            string path = $@"{mdi.SavePath}\{mdi.XMLFileName}";
            stream = new FileStream(path, FileMode.Create);
            serializer = new XmlSerializer(typeof(MetadataItem));
            serializer.Serialize(stream, mdi);
            stream.Close();
            OperationHappened = true;

        }

        public MetadataItem DeserializeObject(string XMLFilename)
        {
            MetadataItem mdi;
            serializer = new XmlSerializer(typeof(MetadataItem));
            //string path = $@"{folder} / {XMLFilename}";
            //MessageBox.Show(path);

            stream = new FileStream(XMLFilename,FileMode.Open);
            mdi = (MetadataItem)serializer.Deserialize(stream);
            stream.Close();
            return mdi;
        }

    }
}
