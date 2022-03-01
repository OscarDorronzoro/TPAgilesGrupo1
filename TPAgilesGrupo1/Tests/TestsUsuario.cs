using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPAgilesGrupo1.Model;

namespace TPAgilesGrupo1.Tests.UsuarioTests
{
    [TestClass]
    public class TestsIngresoMail
    {
        [TestMethod]
        public void TestIngresoMailVacio()
        {
            Usuario usuario = new Usuario();

            var mail = "";

            Assert.IsFalse(usuario.ValidarMail(mail));
        }

        [TestMethod]
        public void TestIngresoMailSinArroba()
        {
            Usuario usuario = new Usuario();

            var mail = "mail.com";

            Assert.IsFalse(usuario.ValidarMail(mail));
        }

        [TestMethod]
        public void TestIngresoMailSinUsuario()
        {
            Usuario usuario = new Usuario();

            var mail = "@mail.com";

            Assert.IsFalse(usuario.ValidarMail(mail));
        }

        [TestMethod]
        public void TestIngresoMailSinDominio()
        {
            Usuario usuario = new Usuario();

            var mail = "usuario@";

            Assert.IsFalse(usuario.ValidarMail(mail));
        }

        [TestMethod]
        public void TestIngresoMailValido()
        {
            Usuario usuario = new Usuario();

            var mail = "usuario@mail.com";

            Assert.IsTrue(usuario.ValidarMail(mail));
        }
    }

    [TestClass]
    public class TestsIngresoContrasena
    {
        [TestMethod]
        public void TestIngresoContrasenaVacia()
        {
            Usuario usuario = new Usuario();

            string contrasena = "";

            Assert.IsFalse(usuario.ValidarContrasena(contrasena));
        }

        [TestMethod]
        public void TestIngresoContrasenaCorta()
        {
            Usuario usuario = new Usuario();

            string contrasena = "!23456";

            Assert.IsFalse(usuario.ValidarContrasena(contrasena));
        }

        [TestMethod]
        public void TestIngresoContrasenaLarga()
        {
            Usuario usuario = new Usuario();

            string contrasena = "123456789.123456789.123456798.123456789.123456789.123456789.!"; // 61 caracteres

            Assert.IsFalse(usuario.ValidarContrasena(contrasena));
        }

        [TestMethod]
        public void TestIngresoContrasenaSinSimbolos()
        {
            Usuario usuario = new Usuario();

            string contrasena = "123456789";

            Assert.IsFalse(usuario.ValidarContrasena(contrasena));
        }

        [TestMethod]
        public void TestIngresoContrasenaValida()
        {
            Usuario usuario = new Usuario();

            string contrasena = "1234567abc.!";

            Assert.IsTrue(usuario.ValidarContrasena(contrasena));
        }
    }

    [TestClass]
    public class TestsLogIn
    {
        [TestMethod]
        public void TestIngresoUsuarioInvalido()
        {
            Usuario.InicializarUsuario();
            Usuario usuario = new Usuario("pedro@gmail.com", "1234abc!!");

            Assert.IsFalse(usuario.LogIn());
        }

        [TestMethod]
        public void TestIngresoUsuarioValido()
        {
            Usuario.InicializarUsuario();
            Usuario usuario = new Usuario("pepe@gmail.com", "1234567abc!!");

            Assert.IsTrue(usuario.LogIn());
        }
    }
}
