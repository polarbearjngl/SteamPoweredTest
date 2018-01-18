using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class PopupMenu:BaseElement
    {
        public Label Item;
         
        public PopupMenu(string locator, string category)
        {
            CreateNew(By.XPath(string.Format(locator,category)));
        }
    }
}
