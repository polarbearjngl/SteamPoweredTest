using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SteamPoweredTest
{
    public class BaseElement: BaseEntity
    {
        public By Locator { get; protected set; }
        public IWebElement WebElement { get; protected set; }

        protected void CreateNew(By locator)
        {
            Locator = locator;
            WebElement = browser.driver.FindElement(locator);
        }

        protected IWebElement FindWebElement(By locator)
        {
            return browser.driver.FindElement(locator);
        }

        public string getAttribute(By locator, string attributeName)
        {
            return browser.driver.FindElement(locator).GetAttribute(attributeName);
        }

        public void ClickAndWait_ViaJS()
        {
            Click_ViaJS();
            WaitPageToLoad();
        }

        public void ClickAndWait_ViaAction()
        {
            Click_ViaAction();
            WaitPageToLoad();
        }

        public void ClickAndWait()
        {
            WaitPageToLoad();
            WebElement.Click();
            WaitPageToLoad();
        }

        public void Click_ViaJS()
        {
            var js = (IJavaScriptExecutor)browser.driver;
            js.ExecuteScript("arguments[0].click();", WebElement);
        }

        public void Click_ViaAction()
        {
            new Actions(browser.driver).Click(WebElement).Build().Perform();
        }

        public void Click()
        {
            WebElement.Click();
        }

        public void MouseOver()
        {
            new Actions(browser.driver).MoveToElement(WebElement).Build().Perform();
        }

    }
}
