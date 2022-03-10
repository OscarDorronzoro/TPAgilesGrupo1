using FluentAssertions;
using Hangman;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowAhorcado.Specs.Steps
{
    [Binding]
    public sealed class AhorcadoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Game ahorcado = new Game();
        private string caracter = "";
        private bool resultado;
        private IWebDriver driver;
        private readonly string _baseUrl = "https://ma-ahorcado.azurewebsites.net/";


        public AhorcadoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void TestInitialize()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            //option.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }

        [When("presiono el boton Play")]
        public void GivenPresionoJugar()
        {
            var playButton = driver.FindElement(By.Name("play"));

            playButton.Click();
        }

        [When("ingreso un intento (.*)")]
        public void GivenIngresoCaracter(string character)
        {
            var guessLabel = driver.FindElement(By.Name("Letter"));

            guessLabel.SendKeys(character);
        }

        [Given("ingreso el nombre: (.*)")]
        public void GivenIngresoVacio(string name)
        {
            driver.Navigate().GoToUrl(_baseUrl);
            Thread.Sleep(1000);

            var nameLabel = driver.FindElement(By.Id("Name"));

            if (!name.Equals("."))
            {
                nameLabel.SendKeys(name);
            }           
        }

        [Given("no tecleo ningun caracter")]
        public void GivenNoIngresoCaracter(string character)
        {
            this.caracter = "";
        }

        [When("presiono el boton guess")]
        public void WhenPresionoEnter()
        {
            var guessButton = driver.FindElement(By.Id("guess"));

            guessButton.Click();
        }

        [Then("el sistema ingresa a la url del juego (.*)")]
        public void ThenElSistemaAvanza(string extraUrl)
        {
            var currentUrl = driver.Url;

            currentUrl.Should().Be(_baseUrl + extraUrl);
        }
        [Then("el sistema no ingresa a la url del juego")]
        public void ThenElSistemaNoAvanza()
        {
            var currentUrl = driver.Url;
            
            currentUrl.Should().Be(_baseUrl);
        }

        [Then("el sistema deberia mostrar el caracter ingresado (.*)")]
        public void ThenElSistemaMeDice(string character)
        {
            var letterGuessed = driver.FindElement(By.Id("letterUsed")).Text;

            letterGuessed.Should().Be(character);
        }

        [Then("el sistema ingresa al login del sitio web")]
        public void ThenElSistemaIngresaAlLogin()
        {
            var currentUrl = driver.Url;

            currentUrl.Should().Be(_baseUrl);
        }
        
    }
}