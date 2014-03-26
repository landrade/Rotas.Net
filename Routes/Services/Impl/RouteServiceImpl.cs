using Routes.Domain;
using Routes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Routes.Services.Impl
{
    public class RouteServiceImpl : IRouteService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IRouteRepository _routeRepository;

        public RouteServiceImpl(IAddressRepository addressRepository, IRouteRepository routeRepository)
        {
            if (addressRepository == null) throw new ArgumentNullException("addressRepository");
            if (routeRepository == null) throw new ArgumentNullException("routeRepository");
            _addressRepository = addressRepository;
            _routeRepository = routeRepository;
        }

        public Route GenerateBy(List<SimpleAddress> addresses, RouteType routeType)
        {
            if (addresses == null) throw new ArgumentNullException("addresses");

            var domainAddress = addresses.Select(simpleAddress => _addressRepository.GetBy(simpleAddress.Street, simpleAddress.HouseNumber, simpleAddress.City, simpleAddress.State)).ToList();

            return _routeRepository.GetBy(domainAddress, routeType);
        }


    }
}
