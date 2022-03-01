Feature: Ahorcado
	Para evitar errores voy a insertar caracteres validos y vacio

@ingresoCaracterInvalido
Scenario: Ingresar caracter invalido en un juego
	Given presiono jugar
	And no tecleo ningun caracter
	When presiono el boton guess
	Then el sistema deberia decirme: Ingrese un caracter valido

@ingresoCaracterInvalido
Scenario: Ingresar caracter valido
	Given presiono jugar
	And tecleo el caracter A
	When presiono el boton guess
	Then el sistema deberia decirme: Anotar el caracter en caso de ser correcto, contar un error si no corresponde a la palabra