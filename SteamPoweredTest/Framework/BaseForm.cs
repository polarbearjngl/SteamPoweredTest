using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SteamPoweredTest
{
    public class BaseForm: BaseEntity
    {       
        protected XMLReader reader = new XMLReader();
        protected BrowserConfig config = new BrowserConfig();

        protected void NavigateTo(string url)
        {
            browser.driver.Url = url;
        }

        protected ReadOnlyCollection<IWebElement> FindWebElements(By locator)
        {
            return browser.driver.FindElements(locator);
        }
    }
}
