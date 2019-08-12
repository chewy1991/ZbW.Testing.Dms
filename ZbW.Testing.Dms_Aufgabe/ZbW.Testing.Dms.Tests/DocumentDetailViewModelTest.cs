using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.Views;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Tests
{
    [TestFixture]
    public class DocumentDetailViewModelTest
    {
        
        
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

        
    }
}
