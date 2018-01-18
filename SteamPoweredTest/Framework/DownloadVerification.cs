using System;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SteamPoweredTest
{
    public class DownloadVerification: BaseEntity
    {
        private string chromeDownloads = "DOWNLOADS-MANAGER";
        private string firefoxDownloads = ".download";

        private string state = "";
        private Stopwatch timer = new Stopwatch();
        double seconds;

        public void Verify(string browser)
        {       
            seconds = Double.Parse(new BrowserConfig().DownloadTimer());

            switch (browser)
            {
                case "Chrome":
                    ChromeDownload();
                    break;
                case "Firefox":
                    FirefoxDownload();
                    break;
            }
        }

        private void ChromeDownload()
        {
            FluentWaitUntil(By.TagName(chromeDownloads));
            var manager = browser.driver.FindElement(By.TagName(chromeDownloads));
            var list = GetRootElements(manager);

            timer.Start();            
            foreach (IWebElement Elem in list)
            {
                do
                {
                    state = GetState(Elem);
                }
                while (state != "COMPLETE" && timer.Elapsed < TimeSpan.FromSeconds(seconds));
            }
            timer.Stop();

            Assert.AreEqual(state, "COMPLETE");       
        }

        private void FirefoxDownload()
        {
            FluentWaitUntil(By.CssSelector(firefoxDownloads));
            var item = browser.driver.FindElement(By.CssSelector(firefoxDownloads));

            timer.Start();
            do
            {
                state = item.GetAttribute("state");
            }
            while (state != "1" && timer.Elapsed < TimeSpan.FromSeconds(seconds));
            timer.Stop();

            Assert.AreEqual(state, "1");
        
        }

        private ReadOnlyCollection<IWebElement> GetRootElements(IWebElement element)
        {
            ReadOnlyCollection<IWebElement> elements = (ReadOnlyCollection<IWebElement>)((IJavaScriptExecutor)browser.driver).
                ExecuteScript("return document.querySelector('downloads-manager')" +
                ".shadowRoot.querySelector('#downloads-list').getElementsByTagName('downloads-item');", element);
            return elements;
        }

        private string GetState(IWebElement element)
        {
            return (string)((IJavaScriptExecutor)browser.driver).ExecuteScript("return arguments[0].__data__.data.state", element);
        }
    }
}
