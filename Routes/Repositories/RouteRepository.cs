using Routes.Domain;
using System.Collections.Generic;

namespace Routes.Repositories
{
    public interface IRouteRepository
    {
        Route GetBy(List<Address> addresses, RouteType type); 
    }
}
