using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SteamPoweredTest
{
    [TestClass]
    public class TestClass:BaseTest
    {       
        [TestMethod]
        public void SteamPoweredTest()
        {
            MainForm mainForm = new MainForm(config.Url());

            LogStep(1);

            mainForm.NavigateToCategory(reader.CategoryName(reader.ReadLanguage()), reader.ItemName(reader.ReadLanguage()));

            LogStep(2);

            CategoryForm categoryForm = new CategoryForm();

            categoryForm.NavigateOnTabPanel(reader.TabPanelItem(reader.ReadLanguage()));

            LogStep(3);

            categoryForm.NavigateToMaxDiscountItem();

            LogStep(4);

            AgeInputForm ageInputForm = new AgeInputForm(categoryForm.maxDiscountItem);

            ageInputForm.AgeValidate();

            GameForm gameForm = new GameForm();

            gameForm.AssertDiscount(ageInputForm.gameToCompare.Discount);
            gameForm.AssertFinalPrice(ageInputForm.gameToCompare.FinalPrice);
            gameForm.AssertOriginPrice(ageInputForm.gameToCompare.OriginPrice);

            LogStep(5);

            gameForm.NavigateToInstallSteam();

            InstallForm installForm = new InstallForm();

            LogStep(6);

            installForm.DownloadSteam();

            LogStep(7);

            installForm.NavigateToDownloads();

            DownloadsForm downloadsForm = new DownloadsForm();

            downloadsForm.VerifyDownload();
        }
    }
}
