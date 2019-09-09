using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.Views;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Tests
{
    [TestFixture]
    public class DocumentDetailViewModelTest
    {
        [SetUp]
        public void SetUp()
        {
            if (!(File.Exists(@"C:\Users\addik\Desktop\test1\testenmitdel.docx")))
            {
                File.Create(@"C:\Users\addik\Desktop\test1\testenmitdel.docx");
            }
        }

       /* [TearDown]
        public void Teardown()
        {
            if (!(File.Exists(@"C:\Users\addik\Desktop\test1\testenmitdel.docx")))
            {
                File.Create(@"C:\Users\addik\Desktop\test1\testenmitdel.docx");
            }

        }*/
        
        
        [Test]
        public void CheckRequiredFields_AllFieldsNull_True()
        {
            //arrange
            var sut = new AddingClass();
            List<string> list = new List<string>();
            list.Add("HE");
            //act
            var result = sut.CheckRequiredFields("He", list, DateTime.Now);
            //assert
            Assert.True(result);
        }
        [Test]
        public void CheckRequiredFields_AllFieldsNull_False()
        {
            //arrange
            List<string> list = new List<string>();
            var sut = new AddingClass();
            list.Add(null);
            //act
            var result = sut.CheckRequiredFields(null, null, null);
            
            //assert
            Assert.False(result);
        }
        [Test]
        public void CheckRequiredFields_JustBezeichnungNotNull_False()
        {
            //arrange
            List<string> list = new List<string>();
            var sut = new AddingClass();
            list.Add("he");
            //act
            var result = sut.CheckRequiredFields("he", null, null);

            //assert
            Assert.False(result);
        }
        [Test]
        public void CheckRequiredFields_JustTypNotNull_False()
        {
            //arrange
            List<string> list = new List<string>();
            var sut = new AddingClass();
            list.Add("he");
            //act
            var result = sut.CheckRequiredFields(null, list, null);

            //assert
            Assert.False(result);
        }
        [Test]
        public void CheckRequiredFields_JustValutadatumNotNull_False()
        {
            //arrange
            List<string> list = new List<string>();
            var sut = new AddingClass();
            list.Add("he");
            //act
            var result = sut.CheckRequiredFields(null, null, DateTime.Now);

            //assert
            Assert.False(result);
        }

        [Test]
        public void CopyFile_IfisRemoveFileEnabledfalse_IsTrue()
        {
            //arrange
            MetadataItem mdi = new MetadataItem();
            mdi._benutzer = "Adrian";
            mdi._bezeichnung = "hh";
            mdi._erfassungsdatum = DateTime.Now;
            mdi._filePath = @"C:\Users\addik\Desktop\test1\testen.docx";
            mdi._valutaDatum = DateTime.Now;
            mdi.SavePath = @"C:\Users\addik\Desktop\test2";
            mdi.FileName = "testen.docx";
            mdi.XMLFileName = "Metadata.xml";
            FileMove filemove = new FileMove();
            
            if (File.Exists(@"C:\Users\addik\Desktop\test2\testen.docx"))
            {
                File.Delete(@"C:\Users\addik\Desktop\test2\testen.docx");
            }

            
            filemove.CopyFile(mdi);
            //arrange
            bool happend = File.Exists(@"C:\Users\addik\Desktop\test2\testen.docx");
            //Assert
            Assert.True(happend);
        }

        [Test]
        public void CopyFile_IfIsRemoveFileEnabledTrue_IsTrue()
        {
            MetadataItem mdi = new MetadataItem();
            mdi._benutzer = "Adrian";
            mdi._bezeichnung = "hh";
            mdi._erfassungsdatum = DateTime.Now;
            mdi._filePath = @"C:\Users\addik\Desktop\test1\testenmitdel.docx";
            mdi._valutaDatum = DateTime.Now;
            mdi.SavePath = @"C:\Users\addik\Desktop\test2";
            mdi.FileName = "testenmitdel.docx";
            mdi.XMLFileName = "Metadata.xml";
            mdi._isRemoveFileEnabled = true;
            FileMove filemove = new FileMove();
            
            if (File.Exists(@"C:\Users\addik\Desktop\test2\testenmitdel.docx"))
            {
                File.Delete(@"C:\Users\addik\Desktop\test2\testenmitdel.docx");
            } 
            //arrange
            bool happend = File.Exists(@"C:\Users\addik\Desktop\test1\testenmitdel.docx");
            filemove.CopyFile(mdi);
            bool deleted = !File.Exists(@"C:\Users\addik\Desktop\test1\testenmitdel.docx");
            //Assert
            Assert.True(happend && deleted);

        }

        [Test]
        public void FileMove_OpenFile_IsTrue()
        {
            //arrange
            FileMove file = new FileMove();
            var path = $@"C:\Users\addik\Desktop\test1\testen.docx";
            var check = false;
            //act
            file.OpenFile(path);
            check = file.OperationHasHappend;

            //Assert
            Assert.IsTrue(check);
        }

        [Test]
        public void FileMove_OpenFileWrongPath_IsFalse()
        {
            //arrange
            FileMove file = new FileMove();
            var path = $@"C:\Users\addik\Desktop\test1\testen2.docx";
            var check = false;
            //act
            file.OpenFile(path);
            check = file.OperationHasHappend;

            //Assert
            Assert.IsFalse(check);
        }

        //[Test]
        //public void AddinClass_CreateMetaData_IsTrue()
        //{
        //    //arrange
        //    var adding = new AddingClass();
        //    var Benutzer = "Adrian";
        //    var Bezeichnung = "Test";
        //    var Stichwoerter = "Test2";
        //    DateTime Erfassungsdatum = DateTime.Now;
        //    var filepath = @"C:\Users\addik\Desktop\test1\";
        //    var IsRemoveEnabled = false;
        //    var SelectedTypItem = "Verträge";
        //    DateTime? Valutadata = DateTime.Now;
        //    Guid guid = Guid.NewGuid();
        //    var mdi = new MetadataItem();

        //    //act

        //    mdi = adding.createMetadataItem(Benutzer, Bezeichnung, Stichwoerter, Erfassungsdatum, filepath,
        //        IsRemoveEnabled, SelectedTypItem,Valutadata, guid);

        //    //Assert

        //    Assert.IsTrue((Benutzer == mdi._benutzer && Bezeichnung == mdi._bezeichnung && Stichwoerter == mdi._stichwoerter && Erfassungsdatum == mdi._erfassungsdatum && filepath == mdi._filePath && IsRemoveEnabled == mdi._isRemoveFileEnabled && SelectedTypItem == mdi._selectedTypItem && Valutadata == mdi._valutaDatum && guid == mdi._guid));


        //}
    }
}
