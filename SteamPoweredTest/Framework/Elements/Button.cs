using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class Button:BaseElement
    {
        public Button(By locator)
        {
            CreateNew(locator);
        }
    }
}
