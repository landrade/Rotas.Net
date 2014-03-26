using System;
using System.Runtime.Serialization;

namespace RoutesWebServices
{
    [DataContract(Name = "routeDetails", Namespace = "http://webservice.landrade.com.br")]
    public class RouteTotalDto
    {
        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public Double Distance { get; set; }

        [DataMember]
        public Double FuelCost { get; set; }

        [DataMember]
        public Double TotalCost { get; set; }
    }
}