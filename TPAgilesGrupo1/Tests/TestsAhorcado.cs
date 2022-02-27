using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPAgilesGrupo1.Model;

namespace TPAgilesGrupo1.Tests.AhorcadoTests
{
    [TestClass]
    public class TestArriesgarPalabra
    {
        [TestMethod]
        public void TestIntentoVacio()
        {
            Ahorcado juego = new Ahorcado();

            Assert.IsFalse(juego.ValidarIntento(""));
        }

        [TestMethod]
        public void TestIntentoCorrecto()
        {
            Ahorcado juego = new Ahorcado();

            var intento = "METODOLOGIAS AGILES";

            Assert.IsTrue(juego.ValidarIntento(intento));
        }

        [TestMethod]
        public void TestIntentoMinusculasMayusculasCorrecto()
        {
            Ahorcado juego = new Ahorcado();

            var intento = "MetodOlOgias AgIlEs";

            Assert.IsTrue(juego.ValidarIntento(intento));
        }

        [TestMethod]
        public void TestIntentoIncorrecto()
        {
            Ahorcado juego = new Ahorcado();

            var intento = "SCRUM ES UNA METODOLOGIA AGIL";

            Assert.IsFalse(juego.ValidarIntento(intento));
        }
    }

    [TestClass]
    public class TestsIngresarLetra
    {
        [TestMethod]
        public void TestIngresoLetraValida()
        {
            Ahorcado ahorcado = new Ahorcado();

            var letra = "a";

            Assert.IsTrue(ahorcado.ValidarIngresoLetra(letra));
        }

        [TestMethod]
        public void TestIngresoVacio()
        {
            Ahorcado ahorcado = new Ahorcado();

            var letra = "";

            Assert.IsFalse(ahorcado.ValidarIngresoLetra(letra));
        }

        [TestMethod]
        public void TestIngresoLetraMayusculaValida()
        {
            Ahorcado ahorcado = new Ahorcado();

            var letra = "A";

            Assert.IsTrue(ahorcado.ValidarIngresoLetra(letra));
        }

        [TestMethod]
        public void TestIngresoNumero()
        {
            Ahorcado ahorcado = new Ahorcado();

            var letra = "5";

            Assert.IsFalse(ahorcado.ValidarIngresoLetra(letra));
        }

        [TestMethod]
        public void TestIngresoCaracterNoAlfabetico()
        {
            Ahorcado ahorcado = new Ahorcado();

            var letra = "@";

            Assert.IsFalse(ahorcado.ValidarIngresoLetra(letra));
        }
    }

    [TestClass]
    public class TestsJuego
    {
        private int JugarIntentos(string[] intentos)
        {
            Ahorcado ahorcado = new Ahorcado();
            int intentosRestantes = 6;

            foreach (var intento in intentos)
            {
                intentosRestantes = ahorcado.Jugar(intento);
            }

            return intentosRestantes;
        }

        [TestMethod]
        public void TestJuegoPerfecto()
        {
            string [] intentos = { "M", "E","T","O","L","D","G","I","A","S" };

            Assert.IsTrue(JugarIntentos(intentos) == 6);
        }

        [TestMethod]
        public void TestJuegoParcialmenteCorrecto()
        {
            string[] intentos = { "M","Z", "E", "T", "W","O", "L", "D","N", "G", "I", "A", "S" };

            Assert.IsTrue(JugarIntentos(intentos) == 3);
        }

        [TestMethod]
        public void TestJuegoPerdido()
        {
            string[] intentos = { "Q", "Z", "U", "C", "W", "O", "V"};

            Assert.IsTrue(JugarIntentos(intentos) <= 0);
        }
    }

    [TestClass]
    public class TestsDefinirPalabra
    {
        [TestMethod]
        public void TestDefinirPalabra()
        {
            string palabraAAdivinar = "palabra";
            Ahorcado ahorcado = new Ahorcado(palabraAAdivinar);

            Assert.AreEqual(palabraAAdivinar, ahorcado.PalabraCorrecta);
        }
    }

    [TestClass]
    public class TestsPuntaje
    {
        private int JugarIntentos(string[] intentos)
        {
            Ahorcado ahorcado = new Ahorcado();

            foreach (var intento in intentos)
            {
                ahorcado.Jugar(intento);
            }

            return ahorcado.Puntaje;
        }

        [TestMethod]
        public void TestJuegoPerdido()
        {
            string[] intentos = { "Q", "Z", "U", "C", "W", "O", "V" };

            int puntaje = JugarIntentos(intentos);

            Assert.AreEqual(0, puntaje);
        }

        [TestMethod]
        public void TestJuegoParcialmenteCorrecto()
        {
            string[] intentos = { "M", "Z", "E", "T", "W", "O", "L", "D", "N", "G", "I", "A", "S" };

            int puntaje = JugarIntentos(intentos);

            Assert.AreEqual(70, puntaje);
        }

        [TestMethod]
        public void TestJuegoPerfecto()
        {
            string[] intentos = { "M", "E", "T", "O", "L", "D", "G", "I", "A", "S" };

            int puntaje = JugarIntentos(intentos);

            Assert.AreEqual(100, puntaje);
        }
    }

    [TestClass]
    public class TestsResultado
    {
        [TestMethod]
        public void TestCompartirResultado()
        {
            Ahorcado ahorcado = new Ahorcado();
            ahorcado.Puntaje = 20;
            int Seed = 100;
            int random = new Random(Seed).Next(4);

            string resultado = ahorcado.CompartirResultado();

            Assert.AreEqual(ahorcado.Resultados[random], resultado);
        }
    }

    [TestClass]
    public class TestsInstrucciones
    {
        [TestMethod]
        public void TestInstrucciones()
        {
            Ahorcado ahorcado = new Ahorcado();

            string instrucciones = "El objetivo de este juego es adivinar la palabra secreta que ha pensado " +
            "el otro jugador. Debes lograrlo antes de ser 'ahorcado'. Para esto debes seguir las siguientes reglas: " +
            "\n1. Puedes arriesgar a adivinar la palabra completa en un intento." +
            "\n2. Puedes adivinar tirando letras al azar. Cada letra erronéa es un intento que se resta." +
            "\n3. Tienes 6 oportunidades, una correspondiente a cada parte del muñeco que se va a dibujar " +
            "(cabeza, torso, dos brazos, dos piernas). Cuando se terminas los intentos, pierdes." +
            "\n4. Puedes saber la cantidad de letras que posee la palabra a adivinar.";

            Assert.AreEqual(instrucciones, ahorcado.Instrucciones);
        }
    }
}
