using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SteamPoweredTest
{
    public class BaseEntity
    {
        protected BrowserFactory browser = BrowserFactory.GetBrowser();

        protected void WaitUntilLocated(By locator)
        {
            browser.wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        protected void WaitUntilClickable(By locator)
        {
            browser.wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void WaitPageToLoad()
        {
            var js = (IJavaScriptExecutor)browser.driver;
            browser.wait.Until(d => js.ExecuteScript("return jQuery.active").Equals((long)0));
            browser.wait.Until(d => js.ExecuteScript("return document.readyState").Equals("complete"));           
        }

        protected void FluentWaitUntil(By locator)
        {
            var wait = new DefaultWait<IWebDriver>(browser.driver);
            wait.Timeout = new BrowserConfig().WebDriverWait();
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => (d).FindElement(locator));
        }

    }

}
