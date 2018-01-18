using System;
using System.Xml.Linq;

namespace SteamPoweredTest
{
    public class XMLReader
    {        
        private XDocument localization = XDocument.Parse(Properties.Resources.Localization);
        private XDocument validdata = XDocument.Parse(Properties.Resources.ValidData);

        public string CategoryName(string language)
        {
            return localization.Root.Element("Category").Attribute(language).Value;
        }

        public string ItemName(string language)
        {
            return localization.Root.Element("Item").Attribute(language).Value;
        }

        public string TabPanelItem(string language)
        {
            return localization.Root.Element("TabPanelItem").Attribute(language).Value;
        }

        public string AgeInput(string language)
        {
            return localization.Root.Element("AgeInput").Attribute(language).Value;
        }

        public string AgeConfirm(string language)
        {
            return localization.Root.Element("AgeConfirm").Attribute(language).Value;
        }

        public string DownloadBtn(string language)
        {
            return localization.Root.Element("DownloadBtn").Attribute(language).Value;
        }

        public string Day()
        {
            return validdata.Root.Element("ValidAge").Attribute("day").Value;
        }

        public string Month()
        {
            return validdata.Root.Element("ValidAge").Attribute("month").Value;
        }

        public string Year()
        {
            return validdata.Root.Element("ValidAge").Attribute("year").Value;
        }

        public void WriteLanguage(string language)
        {
            XDocument file = new XDocument();
            file.Add(new XElement("CurrentLanguage", language));
            file.Save(System.IO.Directory.GetCurrentDirectory() + "\\lang.xml",SaveOptions.None);
        }

        public string ReadLanguage()
        {
            return  XDocument.Load(System.IO.Directory.GetCurrentDirectory() + "\\lang.xml", LoadOptions.None).
                 Element("CurrentLanguage").Value;
        }

    }
}
