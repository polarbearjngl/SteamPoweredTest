using OpenQA.Selenium;

namespace SteamPoweredTest
{
    public class AgeInputForm:BaseForm
    {
        private string continueBtn = "//a[contains(@class,'tn_grey_white') and contains(@onclick,'HideAgeGate')]";
        private string ageSubmitBtn = "//a[contains(@class,'btn') and contains(@onclick,'AgeGateSubmit')]";
        private string dayComboBox = "//select[@name='ageDay']";
        private string monthComboBox = "//select[@name='ageMonth']";
        private string yearComboBox = "//select[@name='ageYear']";
        
        private int type;      
        private Button ContinueBtn;
        private ComboBox AgeCmbBox;
        private Label Text = new Label("//h2");

        public Game gameToCompare;

        public AgeInputForm(Game game)
        {
            gameToCompare = game;

            FluentWaitUntil(Text.Locator);
            
            string text = Text.getAttribute(Text.Locator,"textContent");

            if (text == reader.AgeConfirm(reader.ReadLanguage()))
                type = 1;
            else if (text == reader.AgeInput(reader.ReadLanguage()))
                type = 2;
            else
                type = 3;
        }

        public void AgeValidate()
        {
            switch (type)
            {
                case (1):

                    WaitUntilLocated(By.XPath(continueBtn));
                    ContinueBtn = new Button(By.XPath(continueBtn));

                    WaitUntilLocated(ContinueBtn.Locator);
                    ContinueBtn.ClickAndWait();
                    break;

                case (2):

                    AgeCmbBox = new ComboBox(By.XPath(dayComboBox));
                    AgeCmbBox.SelectElement(reader.Day());

                    AgeCmbBox = new ComboBox(By.XPath(monthComboBox));
                    AgeCmbBox.SelectElement(reader.Month());

                    AgeCmbBox = new ComboBox(By.XPath(yearComboBox));
                    AgeCmbBox.SelectElement(reader.Year());

                    ContinueBtn = new Button(By.XPath(ageSubmitBtn));

                    WaitUntilLocated(ContinueBtn.Locator);
                    ContinueBtn.ClickAndWait();
                    break;

                case (3):
                    break;
            }
        }
    }
}
