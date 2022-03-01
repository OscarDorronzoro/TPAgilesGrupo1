using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class GamePageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public GamePageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.Id("welcomeMessage"), "Welcome message"); }
        }

        /// <summary>
        /// Gets Letter label
        /// </summary>
        private LazyElement LetterLabel
        {
            get { return this.GetLazyElement(By.Name("Letter"), "Insert letter label"); }
        }

        /// <summary>
        /// Gets GuessButton message
        /// </summary>
        private LazyElement GuessButton
        {
            get { return this.GetLazyElement(By.Id("guess"), "Guess Button"); }
        }

        /// <summary>
        /// Gets LetterUsed
        /// </summary>
        private LazyElement LetterUsed
        {
            get { return this.GetLazyElement(By.Id("letterUsed"), "Letter Used"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.WelcomeMessage.Displayed;
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void EnterLetter(string letter)
        {
            this.LetterLabel.SendKeys(letter);
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void PressButton()
        {
            this.GuessButton.Click();
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public bool ValidateLetter()
        {
            return this.LetterUsed.Displayed;
        }

        /// <summary>
        /// Enter the use credentials and log in - Navigation sample
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        /// <returns>The home page</returns>
        public GamePageModel GuessLetter(string letter)
        {
            this.EnterLetter(letter);
            this.PressButton();

            return new GamePageModel(this.TestObject);
        }
    }
}

