using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routes.Domain;
using Routes.Repositories;
using Routes.Repositories.Impl;
using Routes.Services;

namespace RoutesTest.Repositories
{
    [TestClass]
    public class MapLinkRouteRepositoryTest
    {

        private IRouteRepository Repository;

        [TestInitialize]
        public void Setup()
        {
            Repository = new MapLinkRouteRepository();
        }

        [TestMethod]
        public void DeveRetornarComSucessoNaRotaMaisRapida()
        {
            var address1 = new Address("Avenida Alfredo Baltazar da Silveira", "1", "Rio de Janeiro", "RJ", new Point(-43.3654568, -22.8245486));
            var address2 = new Address("Avenida Rio Branco", "23", "Rio de Janeiro", "RJ", new Point(-43.1806801, -22.8972873));
            var addresses = new List<Address> {address1, address2};
            var route = Repository.GetBy(addresses, RouteType.Fast);
            Assert.AreEqual(addresses, route.Stops);
            Assert.AreEqual(RouteType.Fast, route.Type);
            Assert.IsNotNull(route.Time);
            Assert.IsNotNull(route.Distance);
            Assert.IsNotNull(route.FuelCost);
            Assert.IsNotNull(route.TotalCost);
        }
    }
}
