using Routes.Domain;
using System.Collections.Generic;

namespace Routes.Services
{
    public interface IRouteService
    {
        Route GenerateBy(List<SimpleAddress> addresses, RouteType routeType);
    }
}
