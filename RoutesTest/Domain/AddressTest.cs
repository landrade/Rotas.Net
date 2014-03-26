using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routes.Domain;

namespace RoutesTest.Domain
{
    [TestClass]
    public class AddressTest
    {
        private const String Street = "Alfredo Baltazar da Silveira";
        private const String HouseNumber = "1";
        private const String City = "Rio de Janeiro";
        private const String State = "RJ";
        private readonly Point _point = new Point(123, 321);

        [TestMethod]
        public void DeveCriarComSucesso_QuandoTudoEstiverPreenchidoCorretamente()
        {
            var address = new Address(Street, HouseNumber, City, State, _point);
            Assert.AreEqual(Street, address.Street);
            Assert.AreEqual(HouseNumber, address.HouseNumber);
            Assert.AreEqual(City, address.City);
            Assert.AreEqual(State, address.State);
            Assert.AreEqual(_point, address.Point);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecao_QuandoRuaNaoEstiverPreenchido()
        {
            new Address(null, HouseNumber, City, State, _point);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecao_QuandoNumeroDaCasaNaoEstiverPreenchido()
        {
            var x = new Address(Street, null, City, State, _point);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecao_QuandoCidadeNaoEstiverPreenchida()
        {
            var x = new Address(Street, HouseNumber, null, State, _point);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecao_QuandoEstadoNaoEstiverPreenchido()
        {
            var x = new Address(Street, HouseNumber, City, null, _point);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeveRetornarExcecao_QuandoPointNaoEstiverPreenchido()
        {
            var x = new Address(Street, HouseNumber, City, State, null);
        }
        
    }
}
