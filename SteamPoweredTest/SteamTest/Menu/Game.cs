using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class Game : BaseElement
    {
        private string discount = "//div[@class='discount_pct']";
        private string originPrice = "//div[@class='discount_original_price']";
        private string finalPrice = "//div[@class='discount_final_price']";

        public string Discount { get; private set; }
        public string OriginPrice { get; private set; }
        public string FinalPrice { get; private set; }

        public Game(string itemLocator)
        {
            CreateNew(By.XPath(itemLocator));

            Discount = getAttribute(By.XPath(itemLocator + discount), "textContent");
            OriginPrice = getAttribute(By.XPath(itemLocator + originPrice), "textContent");
            FinalPrice = getAttribute(By.XPath(itemLocator + finalPrice), "textContent");
        }

        public Game(string discountLoc, string originPriceLoc, string finalPriceLoc)
        {
            Discount = getAttribute(By.XPath(discountLoc), "textContent");
            OriginPrice = getAttribute(By.XPath(originPriceLoc), "textContent");
            FinalPrice = getAttribute(By.XPath(finalPriceLoc), "textContent");
        }

    }
}
