using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class TabPanel:BaseElement
    {
        public Label Item;

        public TabPanel(string locator)
        {
            CreateNew(By.XPath(locator));
        }
    }
}
