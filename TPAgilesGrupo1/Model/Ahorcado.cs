using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPAgilesGrupo1.Model
{
    public class Ahorcado
    {
        private int IntentosRestantes = 6;
        public string PalabraCorrecta;
        private string PalabraCorrectaModificada;
        
        public int Puntaje = 0;
        private int PuntosPorIntento = 10;

        public List<String> Resultados = new List<String>();
        public string Instrucciones = "El objetivo de este juego es adivinar la palabra secreta que ha pensado " +
            "el otro jugador. Debes lograrlo antes de ser 'ahorcado'. Para esto debes seguir las siguientes reglas: " +
            "\n1. Puedes arriesgar a adivinar la palabra completa en un intento." +
            "\n2. Puedes adivinar tirando letras al azar. Cada letra erronéa es un intento que se resta." +
            "\n3. Tienes 6 oportunidades, una correspondiente a cada parte del muñeco que se va a dibujar " +
            "(cabeza, torso, dos brazos, dos piernas). Cuando se terminas los intentos, pierdes." +
            "\n4. Puedes saber la cantidad de letras que posee la palabra a adivinar.";


        public Ahorcado()
        {
            PalabraCorrecta = "METODOLOGIAS AGILES";
        }
        public Ahorcado(string palabra)
        {
            PalabraCorrecta = palabra;
        }

        public bool ValidarIntento(string intento)
        {
            return intento.ToUpper().Equals(PalabraCorrecta);
        }

        public bool ValidarIngresoLetra(string intentoLetra)
        {
            Regex expresionRegular = new Regex(@"[a-zA-Z]");

            var letraValidada = expresionRegular.Matches(intentoLetra);

            return letraValidada.Count == 1 ? true : false;
        }
        
        public int Jugar(string intento)
        {
            PalabraCorrectaModificada = PalabraCorrecta.Replace(" ", "");
            int lenAnterior = PalabraCorrectaModificada.Length;

            PalabraCorrectaModificada = PalabraCorrectaModificada.Replace(intento, "");

            if (lenAnterior == PalabraCorrectaModificada.Length)
            {
                IntentosRestantes--;
                if (Puntaje - PuntosPorIntento < 0)
                {
                    Puntaje = 0;
                }
                else
                {
                    Puntaje -= PuntosPorIntento;
                }
            }
            else
            {
                Puntaje += PuntosPorIntento;
            }

            return IntentosRestantes;
        }

        public string CompartirResultado()
        {
            Resultados.Add($"Mi puntaje es {Puntaje}.");
            Resultados.Add($"Mi puntaje es {Puntaje}. Con {IntentosRestantes} vidas restantes.");
            Resultados.Add($"He adivinado la palabra correcta: {PalabraCorrecta}. Mi puntaje es {Puntaje}.");
            Resultados.Add($"He ganado el juego con un puntaje de {Puntaje}, y con {IntentosRestantes} vidas restantes.");

            int Seed = 100;
            int random = new Random(Seed).Next(4);

            return Resultados[random];
        }
    }
}
