using System;
using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class MainForm: BaseForm
    {
        private string popupMenu = "//a[contains(@class,'pulldown') and contains(text(),'{0}')]";
        private string popupMenuItem = "//a[@class='popup_menu_item' and contains(text(),'{0}')]";

        private PopupMenu Menu;
        private Label LanguageLbl;

        public MainForm(string url)
        {
            NavigateTo(url);
            WaitPageToLoad();
            LanguageLbl = new Label("//html[@lang]");

            reader.WriteLanguage(LanguageLbl.getAttribute(LanguageLbl.Locator,"lang"));

        }      

        public void NavigateToCategory(string category,string genre)
        {            
            Menu = new PopupMenu(popupMenu, category);
            Menu.MouseOver();

            Menu.Item = new Label(popupMenuItem, genre);

            WaitUntilClickable(Menu.Item.Locator);

            Menu.Item.ClickAndWait();
        }

    }
}
