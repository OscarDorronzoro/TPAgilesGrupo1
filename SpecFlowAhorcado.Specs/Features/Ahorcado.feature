Feature: Ahorcado
	Tests de aceptacion en el proceso de juego del Ahorcado

@IngresoCaracterInvalido
Scenario: Ingresar caracter invalido en un juego
	Given presiono jugar
	And tecleo el caracter @
	When presiono la tecla ENTER
	Then el sistema deberia decirme: Ingrese un caracter valido

@IngresoPalabraIncorrecta
Scenario: Ingresar palabra incorrecta en un juego
	Given presiono jugar
	And ingreso la palabra: equivocada
	When presiono arriesgar palabra
	Then el sistema me dice: Has perdido
