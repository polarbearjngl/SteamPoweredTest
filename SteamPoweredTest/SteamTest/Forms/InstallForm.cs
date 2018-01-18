using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class InstallForm:BaseForm
    {
        private string downloadBtn = "//div[contains(@class,'install')]//*[text()='{0}']";

        private Button DownloadButton;

        public void DownloadSteam()
        {
            DownloadButton = new Button(By.XPath(string.Format(downloadBtn, reader.DownloadBtn(reader.ReadLanguage()))));
            WaitUntilLocated(DownloadButton.Locator);
            DownloadButton.ClickAndWait();
        }

        public void NavigateToDownloads()
        {
            NavigateTo(config.DownloadsPath());            
        }
    }
}
