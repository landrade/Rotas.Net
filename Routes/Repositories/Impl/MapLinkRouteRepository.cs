using Routes.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Routes.Repositories.Impl
{
    public class MapLinkRouteRepository : IRouteRepository
    {

        public Route GetBy(List<Address> addresses, RouteType type)
        {
            var routeStops = addresses.Select(address => {
                var routeStop = new RouteServiceReference.RouteStop {description = addresses.ToString()};
                                                             var point = new RouteServiceReference.Point
                                                             {
                                                                 x = address.Point.X,
                                                                 y = address.Point.Y
                                                             };
                                                             routeStop.point = point;
                return routeStop;
            }).ToArray();

            var token = ConfigurationManager.AppSettings["WebServiceMapLinkToken"];
            using (var wsProxy = new RouteServiceReference.RouteSoapClient())
            {
                var routeDetails = wsProxy.getRouteTotals(routeStops, buildRouteOptions(type), token);
                return new Route(addresses, type, routeDetails.totalTime, routeDetails.totalDistance, routeDetails.totalfuelCost, routeDetails.totalCost);
            }
            
            
        }

        private RouteServiceReference.RouteOptions buildRouteOptions(RouteType type)
        {
            var routeDetails = new RouteServiceReference.RouteDetails
            {
                descriptionType = 0,
                routeType = (int) type,
                optimizeRoute = true
            };

            var vehicle = new RouteServiceReference.Vehicle
            {
                tankCapacity = 20,
                averageConsumption = 9,
                fuelPrice = 3,
                averageSpeed = 60,
                tollFeeCat = 2
            };

            var routeOptions = new RouteServiceReference.RouteOptions
            {
                language = "portugues",
                routeDetails = routeDetails,
                vehicle = vehicle
            };

            return routeOptions;
        }

    }
}
