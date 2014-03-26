using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routes.Domain;
using Routes.Domain.Exceptions;
using Routes.Repositories.Impl;

namespace RoutesTest.Repositories
{
    [TestClass]
    public class MapLinkAddressRepositoryTest
    {
        private MapLinkAddressRepository Repository { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Repository = new MapLinkAddressRepository();
        }

        [TestMethod]
        public void DeveRetornarEnderecoCorreto()
        {
            const string street = "Avenida Alfredo Baltzar da Silveira";
            const string houseNumber = "1";
            const string city = "Rio de Janeiro";
            const string state = "RJ";
            const double pointX = -43.3654568;
            const double pointY = -22.8245486;
            var expectAddress = new Address(street, houseNumber, city, state, new Point(pointX, pointY));
            Assert.AreEqual(expectAddress, Repository.GetBy(street, houseNumber, city, state));
        }

        [TestMethod]
        [ExpectedException(typeof(AddressNotFoundException))]
        public void DeveRetornarExcecaoAddressNotExistsExcepition()
        {
            Repository.GetBy("alalla", "absd", "asdsa", "fasfas");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeveRetornarExcecaoQuandoRuaForNulo()
        {
            Repository.GetBy(null, "abc", "abc", "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecaoQuandoNumeroForNulo()
        {
            Repository.GetBy("abc", null, "abc", "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecaoQuandoCidadeForNulo()
        {
            Repository.GetBy("abc", "abc", null, "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRetornarExcecaoQuandoEstadoForNulo()
        {
            Repository.GetBy("abc", "abc", "abc", null);
        }
    }
}
