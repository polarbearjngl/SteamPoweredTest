using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SteamPoweredTest
{
    public class ComboBox:BaseElement
    {
        private SelectElement select;

        public ComboBox(By locator)
        {
            CreateNew(locator);           
        }

        public void SelectElement(string text)
        {
            select = new SelectElement(WebElement);
            select.SelectByText(text);
        }
    }
}
