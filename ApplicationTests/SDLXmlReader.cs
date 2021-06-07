using Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace ApplicationTests
{
    [TestClass]
    public class SDLXmlReader
    {
        public string XmlString
        {
            get
            {
                string xml = "<?xml version=\"1.0\" encoding=\"utf - 16\"?>";
                xml += "<test title=\"This Trisoft will be updated\">";
                xml += "<line1>Trisoft has been renamed to SDL Trisoft</line1>";
                xml += "</test>";

                return xml;
            }
        }

        [TestMethod]
        public void SDLXmlReader_UpdateContent_True()
        {
            //Arrange           
            XDocument xDoc = XDocument.Parse(XmlString);
            XDocument oldDoc = XDocument.Parse(XmlString);

            //Act
            var reader = new Application.SDLXmlReader();
            reader.UpdateContent(xDoc, "Trisoft", "SDL Trisoft");

            //Assert
            Assert.AreNotEqual(oldDoc, xDoc);
        }

        [TestMethod]
        public void SDLXmlReader_UpdateElement_True()
        {
            //Arrange
            XDocument xDoc = XDocument.Parse(XmlString);
            XDocument oldDoc = XDocument.Parse(XmlString);

            //Act
            var reader = new Application.SDLXmlReader();
            reader.UpdateElement(xDoc, "title", "Trisoft", "SDL Trisoft");

            //Assert
            Assert.AreNotEqual(oldDoc, xDoc);
        }
    }
}
