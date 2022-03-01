using TechTalk.SpecFlow;
using FluentAssertions;
using Hangman;
using Hangman.Data.Interfaces;

namespace SpecFlowAhorcado.Specs.Steps
{
    [Binding]
    public sealed class AhorcadoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Game ahorcado = new Game();
        private string caracter = "";
        private bool resultado;

        public AhorcadoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("presiono jugar")]
        public void GivenPresionoJugar()
        {
            // Clickear UI
        }

        [Given("tecleo el caracter (.*)")]
        public void GivenIngresoCaracter(string character)
        {
            this.caracter = character;
        }

        [Given("no tecleo ningun caracter")]
        public void GivenNoIngresoCaracter(string character)
        {
            this.caracter = "";
        }

        [When("presiono el boton guess")]
        public void WhenPresionoEnter()
        {
            this.resultado = ahorcado.CheckLetter(caracter);
        }

        [Then("el sistema deberia decirme: (.*)")]
        public void ThenElSistemaDeberiaDecirme(string mensaje)
        {
            if (!this.resultado)
            {
                mensaje.Should().Be("Ingrese un caracter valido");
            }
            else
            {
                mensaje.Should().Be("");
            }

        }

        [Then("el sistema me dice: (.*)")]
        public void ThenElSistemaMeDice(string mensaje)
        {
            if (!this.resultado)
            {
                mensaje.Should().Be("Has perdido");
            }
            else
            {
                mensaje.Should().Be("");
            }

        }
    }
}