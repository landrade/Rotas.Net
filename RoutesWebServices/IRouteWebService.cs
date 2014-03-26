using System.Collections.Generic;
using System.ServiceModel;

namespace RoutesWebServices
{
    [ServiceContract(Namespace = "http://webservice.landrade.com.br")]
    public interface IRouteWebService
    {
        [OperationContract]
        RouteTotalDto GetRouteTotals(List<AddressDto> addresses, int routeType);
    }
}
