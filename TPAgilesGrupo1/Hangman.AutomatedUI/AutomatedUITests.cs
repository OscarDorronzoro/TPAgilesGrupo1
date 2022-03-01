using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace Hangman.AutomatedUI
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private const string _BaseUrl = "https://google.com/";
        public AutomatedUITests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-dev-shm-usage");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Fact]
        public void Create_Hangman_Game()
        {
            StartGame();
            Assert.Equal($"{_BaseUrl}Game/Index", _driver.Url);
        }

        [Theory]
        [InlineData("z")]
        public void Letter_User_Added(string letter)
        {
            StartGame();
            System.Threading.Thread.Sleep(1000);
            GuessLetter(letter);
            System.Threading.Thread.Sleep(300);
            Assert.Equal("z", _driver.FindElement(By.Id("letterUsed")).Text);
        }

        [Theory]
        [InlineData("zxykqv")]
        public void Lose_Hangman_Game(string word)
        {
            StartGame();
            System.Threading.Thread.Sleep(2000);
            foreach (var character in word)
            {
                GuessLetter(character.ToString());
                System.Threading.Thread.Sleep(3000);
            }
            Assert.True(_driver.FindElement(By.Id("lost")).Displayed);
        }
        private void StartGame()
        {
            _driver.Navigate().GoToUrl(_BaseUrl);
            _driver.FindElement(By.Id("Name")).SendKeys("Tomas");
            _driver.FindElement(By.Name("play")).Click();
        }
        private void GuessLetter(string letter)
        {
            _driver.FindElement(By.Name("Letter")).SendKeys(letter);
            _driver.FindElement(By.Id("guess")).Click();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
