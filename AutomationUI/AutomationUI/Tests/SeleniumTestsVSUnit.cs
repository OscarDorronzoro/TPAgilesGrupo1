using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
        /// <summary>
        /// Open page test
        /// </summary>
        [TestMethod]
        public void OpenLoginPageTest()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterValidName()
        {
            string name = "Juan Perez";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            GamePageModel homepage = page.LoginWithValidCredentials(name);
            Assert.IsTrue(homepage.IsPageLoaded());
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterInvalidName()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            LoginPageModel loginPage = page.LoginWithInvalidCredentials();
            Assert.IsTrue(loginPage.IsPageLoaded());
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void ValidateGamePageTest()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            string name = "Juan Perez";
            page.EnterCredentials(name);
            page.PressPlayButton();

            GamePageModel gamePage = new GamePageModel(this.TestObject);
            Assert.IsTrue(
                gamePage.IsPageLoaded(),
                "The game web page '{0}' is not loaded");
        }

        /// <summary>
        /// Guess Letter
        /// </summary>
        [TestMethod]
        public void GuessLetterTest()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            string name = "Juan Perez";
            page.EnterCredentials(name);
            page.PressPlayButton();

            GamePageModel gamePage = new GamePageModel(this.TestObject);
            GamePageModel gamePagePlayed = gamePage.GuessLetter("a");

            Assert.IsTrue(
                gamePagePlayed.ValidateLetter(),
                "No letter guessed");
        }
    }
}
