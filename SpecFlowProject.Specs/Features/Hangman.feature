Feature: Ahorcado
	Para evitar errores voy a insertar caracteres validos y vacio

@ingresoNombreVacio
Scenario: No ingresar ningun caracter como nombre de jugador
	Given ingreso el nombre: .
	When presiono el boton Play
	Then el sistema no ingresa a la url del juego

@ingresoNombreValido
Scenario: Ingresar un nombre de jugador
	Given ingreso el nombre:  Juan Perez
	When presiono el boton Play
	Then el sistema ingresa a la url del juego Game/Index

@ingresoCaracterValido
Scenario: Ingresar caracter valido en un juego
	Given ingreso el nombre:  Juan Perez
	When presiono el boton Play
	And ingreso un intento a
	When presiono el boton guess
	Then el sistema deberia mostrar el caracter ingresado a

@abrirPaginaLogin
Scenario: Ingreso de url e ingreso al sitio web
	Given ingreso el nombre: .
	Then el sistema ingresa al login del sitio web

@ingresoGameWebPage
Scenario: Ingreso al juego
	Given ingreso el nombre:  Juan Perez
	When presiono el boton Play
	Then el sistema ingresa a la url del juego Game/Index