using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public class SDLXmlReader
    {
        bool updated = false;
        public XDocument document = null;

        public void UpdateFiles(string[] files)
        {
            try
            {
                foreach (var itemFile in files)
                {
                    UpdateFile(itemFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public XDocument ReadXmlFile(string file)
        {
            return XDocument.Parse(File.ReadAllText(file));
        }

        public void UpdateFile(string file)
        {
            try
            {
                XDocument document = ReadXmlFile(file);

                document.Save(Path.GetFileName(file) + ".bak");

                UpdateContent(document, "Trisoft", "SDL Trisoft");
                UpdateElement(document, "title", "Trisoft", "SDL Trisoft");

                if (updated)
                {
                    Console.WriteLine($"File {file} updated");
                    document.Save(Path.GetFileName(file));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateContent(XDocument xDocument, string replace, string replaceWith)
        {
            try
            {
                List<XElement> allElements = xDocument.Descendants().ToList();
                foreach (XElement element in allElements.Where(e => e.Value.Contains(replace)))
                {
                    string firstResult = Regex.Replace(element.Value, @replaceWith, replace);
                    element.Value = Regex.Replace(firstResult, @replace, replaceWith);
                    updated = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateElement(XDocument xDocument, string strElement, string replace, string replaceWith)
        {
            try
            {
                List<XElement> allElements = xDocument.Descendants().ToList();

                foreach (var docElement in allElements)
                {
                    string firstResult = Regex.Replace(docElement.Attribute(strElement).Value, @replaceWith, replace);
                    docElement.Attribute(strElement).Value = Regex.Replace(firstResult, @replace, replaceWith);
                    updated = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
