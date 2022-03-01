using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPAgilesGrupo1.Model;

namespace TPAgilesGrupo1.Tests.InvitadoTests
{
    [TestClass]
    public class TestsInvitado
    {
        [TestMethod]
        public void TestIngresoNombreVacio()
        {
            Invitado invitado = new Invitado();

            var nombre = "";

            Assert.IsFalse(invitado.ValidarIngreso(nombre));
        }

        [TestMethod]
        public void TestIngresoNombreValido()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "juan";

            Assert.IsTrue(invitado.ValidarIngreso(nombreInvitado));
        }

        [TestMethod]
        public void TestIngresoNombreInvalidoCorto()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "sa";

            Assert.IsTrue(!invitado.ValidarIngreso(nombreInvitado));
        }

        [TestMethod]
        public void TestIngresoNombreValidoConNumeros()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "pedr1to";

            Assert.IsTrue(invitado.ValidarIngreso(nombreInvitado));
        }

        [TestMethod]
        public void TestIngresoNombreInvalidoLargo()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "megustajugaralahorcado";

            Assert.IsTrue(!invitado.ValidarIngreso(nombreInvitado));
        }

        [TestMethod]
        public void TestIngresoNombreInvalidoCaracteres()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "!@#$%@";

            Assert.IsTrue(!invitado.ValidarIngreso(nombreInvitado));
        }

        [TestMethod]
        public void TestIngresoNombreInvalidoEspacio()
        {
            Invitado invitado = new Invitado();

            var nombreInvitado = "juan perez";

            Assert.IsTrue(!invitado.ValidarIngreso(nombreInvitado));
        }
    }
}
