using Routes.Domain.Exceptions;
using System;
using System.Configuration;

namespace Routes.Repositories.Impl
{
    public class MapLinkAddressRepository : IAddressRepository
    {
        public Domain.Address GetBy(string street, string houseNumber, string city, string state)
        {
            if (String.IsNullOrWhiteSpace(street)) throw new ArgumentException("street");
            if (String.IsNullOrWhiteSpace(houseNumber)) throw new ArgumentException("houseNumber");
            if (String.IsNullOrWhiteSpace(city)) throw new ArgumentException("city");
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentException("state");

            var mapLinkCity = new AddressFinderServiceReference.City {name = city, state = state};

            var mapLinkAddress = new AddressFinderServiceReference.Address
            {
                street = street,
                houseNumber = houseNumber,
                city = mapLinkCity
            };

            var token = ConfigurationManager.AppSettings["WebServiceMapLinkToken"];

            using (var webserviceProxy = new AddressFinderServiceReference.AddressFinderSoapClient())
            {
                try
                {
                    var mapLinkPoint = webserviceProxy.getXY(mapLinkAddress, token);
                    return new Domain.Address(street, houseNumber, city, state, new Domain.Point(mapLinkPoint.x, mapLinkPoint.y));
                }
                catch (Exception ex)
                {
                    throw new AddressNotFoundException(ex.Message, ex);
                }    
            }
        }
    }
}
