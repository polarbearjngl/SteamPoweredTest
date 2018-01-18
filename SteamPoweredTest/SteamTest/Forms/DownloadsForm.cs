
namespace SteamPoweredTest
{
    public class DownloadsForm:BaseForm
    {
        public void VerifyDownload()
        {
            new DownloadVerification().Verify(new BrowserConfig().Browser());
        }
    }
}
