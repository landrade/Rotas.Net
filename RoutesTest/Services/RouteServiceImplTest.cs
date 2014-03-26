using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Routes.Domain;
using Routes.Repositories;
using Routes.Services;
using Routes.Services.Impl;

namespace RoutesTest.Services
{
    [TestClass]
    public class RouteServiceImplTest
    {
        private IRouteService _service;

        private readonly IRouteRepository _routeRepository = Mock.Of<IRouteRepository>(x =>
               x.GetBy(It.IsAny<List<Address>>(), It.IsAny<RouteType>()) ==
                   new Route(new List<Address> { new Address("Teste", "1", "TesteCidade", "TesteEstatdo",
                new Point(-43.3654568, -22.8245486)) }, RouteType.Fast, "1234", 123, 321, 4321));

        readonly IAddressRepository _addressRepository = Mock.Of<IAddressRepository>(x =>
                x.GetBy(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>()) ==
                new Address("Teste", "1", "TesteCidade", "TesteEstatdo",
                new Point(-43.3654568, -22.8245486)));

        [TestInitialize]
        public void Setup()
        {
            _service = new RouteServiceImpl(_addressRepository, _routeRepository);
        }

        [TestMethod]
        public void DeveRetornarRotaComSucesso()
        {
            var simpleAddress = new SimpleAddress()
            {
                Street = "Teste",
                HouseNumber = "1",
                City = "TesteCidade",
                State = "TesteEstatdo"
            };
            var route = _service.GenerateBy(new List<SimpleAddress> { simpleAddress }, RouteType.Fast);
            Assert.AreEqual(new Address("Teste", "1", "TesteCidade", "TesteEstatdo",
                new Point(-43.3654568, -22.8245486)), route.Stops[0]);
            Assert.AreEqual(RouteType.Fast, route.Type);
            Assert.AreEqual("1234", route.Time);
            Assert.AreEqual(123, route.Distance);
            Assert.AreEqual(321, route.FuelCost);
            Assert.AreEqual(4321, route.TotalCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeveRetornarExcecao_QuandoEnderecosForNulo()
        {
            _service.GenerateBy(null, RouteType.Fast);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeveRetornarExcecao_QuandoAddressRepositoryForNulo()
        {
            new RouteServiceImpl(null, _routeRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeveRetornarExcecao_QuandoRouteRepositoryForNulo()
        {
            new RouteServiceImpl(_addressRepository, null);
        }
    }
}
