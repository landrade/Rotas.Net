using System;
using System.Runtime.Serialization;

namespace RoutesWebServices
{
    [DataContract(Name = "address", Namespace = "http://webservice.landrade.com.br")]
    public class AddressDto
    {
        [DataMember(IsRequired = true)]
        public string Street { get; set; }
        [DataMember(IsRequired = true)]
        public string HouseNumber { get; set; }
        [DataMember(IsRequired = true)]
        public string City { get; set; }
        [DataMember(IsRequired = true)]
        public string State { get; set; }
    }
}