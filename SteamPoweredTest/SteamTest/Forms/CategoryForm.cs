using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SteamPoweredTest
{
    public class CategoryForm:BaseForm
    {
        private string tabPanelItem = "//div[@class='tabbar_ctn']//div[contains(text(),'{0}')]";
        private string discounts = "//div[contains(@id,'special') or contains(@id,'iscount')]";
        private string discountsItem = "//a[contains(@class,'tab_item')]";

        private TabPanel Panel = new TabPanel("//div[@class='tabbar_ctn']");
        public Game maxDiscountItem { get; private set; }

        public void NavigateOnTabPanel(string tabName)
        {           
            Panel.Item = new Label(tabPanelItem, tabName);

            WaitUntilLocated(Panel.Item.Locator);
            Panel.Item.ClickAndWait();
        }

        public void NavigateToMaxDiscountItem()
        {
            maxDiscountItem = FindMaxDiscount(discounts, discountsItem);
            WaitUntilLocated(maxDiscountItem.Locator);
            maxDiscountItem.ClickAndWait();
        }

        private Game FindMaxDiscount(string tableLocater, string itemLocator)
        {
            var elements = FindWebElements(By.XPath(tableLocater + itemLocator));
            var enumerator = elements.GetEnumerator();
            var items = new List<Game>();

            for (int i = 1; enumerator.MoveNext(); i++)
            {
                try
                {
                    items.Add(new Game(string.Format(tableLocater + itemLocator + "[{0}]", i)));
                }
                catch (Exception e)
                {
                    if (e.Equals(typeof(NoSuchElementException)))
                        continue;
                }
            }

            items.Sort(delegate (Game a, Game b)
            {
                return a.Discount.CompareTo(b.Discount);
            });

            return items[items.Count - 1];
        }

    }
}
