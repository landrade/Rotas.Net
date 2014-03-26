using System;
using System.Collections.Generic;
using System.Linq;
using Routes.Domain;
using Routes.Repositories.Impl;
using Routes.Services;
using Routes.Services.Impl;

namespace RoutesWebServices
{
    public class RouteWebService : IRouteWebService
    {
        private readonly IRouteService _routeService ;
        public RouteWebService()
        {
            _routeService = new RouteServiceImpl(new MapLinkAddressRepository(), new MapLinkRouteRepository());
        }

        public RouteTotalDto GetRouteTotals(List<AddressDto> addresses, int routeType)
        {
            var simpleAddresses = addresses.Select(dto => 
                new SimpleAddress {Street = dto.Street, HouseNumber = dto.HouseNumber, City = dto.City, State = dto.State}).ToList();

            if (routeType != (int) RouteType.Fast && routeType != (int) RouteType.NoTransit)
            {
                throw new ArgumentException("routeType");
            }

            var route = _routeService.GenerateBy(simpleAddresses, (RouteType) routeType);

            return new RouteTotalDto {Time = route.Time, Distance = route.Distance, FuelCost = route.FuelCost, TotalCost = route.TotalCost};

        }
    }
}
