Feature: Ahorcado
	Para evitar errores voy a insertar caracteres invalidos

@ingresoCaracterInvalido
Scenario: Ingresar caracter invalido en un juego
	Given presiono jugar
	And tecleo el caracter @
	When presiono la tecla ENTER
	Then el sistema deberia decirme: Ingrese un caracter valido

Feature: Ahorcado
	Para comprobar la funcionalidad de arriesgar voy a ingresar un intento

@ingresoCaracterInvalido
Scenario: Ingresar palabra o frase
	Given presiono jugar
	And tecleo el intento entero
	When presiono la tecla ENTER
	Then el sistema deberia decirme: Ganaste si acerte, o contarme como error si fallo

Feature: Ahorcado
	Para validar ingreso de caracteres correcto, voy a ingresar un caracter valido

@ingresoCaracterInvalido
Scenario: Ingresar caracter valido
	Given presiono jugar
	And tecleo el caracter A
	When presiono la tecla ENTER
	Then el sistema deberia decirme: Anotar el caracter en caso de ser correcto, contar un error si no corresponde a la palabra


