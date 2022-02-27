using TechTalk.SpecFlow;
using FluentAssertions;
using TPAgilesGrupo1.Model;

namespace SpecFlowAhorcado.Specs.Steps
{
    [Binding]
    public sealed class AhorcadoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly Ahorcado ahorcado = new Ahorcado();
        private string caracter;
        private bool resultado;
        private string palabra;

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

        [Given("ingreso la palabra: (.*)")]
        public void GivenIngresoPalabra(string palabra)
        {
            this.palabra = palabra;
        }

        [When("presiono la tecla ENTER")]
        public void WhenPresionoEnter()
        {
            this.resultado = ahorcado.ValidarIngresoLetra(caracter);
        }

        [When("presiono arriesgar palabra")]
        public void WhenPresionoArriesgarPalabra()
        {
            this.resultado = ahorcado.PalabraCorrecta == this.palabra;
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
