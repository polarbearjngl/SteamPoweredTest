using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SteamPoweredTest
{
    public class GameForm:BaseForm
    {
        private string discount = "//div[@class='game_purchase_action']//div[@class='discount_pct']";
        private string originPrice = "//div[@class='game_purchase_action']//div[@class='discount_original_price']";
        private string finalPrice = "//div[@class='game_purchase_action']//div[@class='discount_final_price']";

        private Game ThisGame;
        private Button InstallSteamBtn = new Button(By.XPath("//a[@class='header_installsteam_btn_content']"));

        public GameForm()
        {
            WaitPageToLoad();
            ThisGame = new Game(discount, originPrice, finalPrice);
        }

        public void AssertDiscount(string discount)
        {
            Assert.AreEqual(ThisGame.Discount, discount);
        }

        public void AssertOriginPrice(string originPrice)
        {
            Assert.AreEqual(ThisGame.OriginPrice, originPrice);
        }

        public void AssertFinalPrice(string finalprice)
        {
            Assert.AreEqual(ThisGame.FinalPrice, finalprice);
        }

        public void NavigateToInstallSteam()
        {
            WaitUntilLocated(InstallSteamBtn.Locator);
            InstallSteamBtn.ClickAndWait();
        }

    }
}
