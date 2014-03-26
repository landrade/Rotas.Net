using System;
using System.Collections.Generic;

namespace Routes.Domain
{
    public class Route
    {
        public readonly List<Address> Stops;

        public readonly RouteType Type;

        public readonly String Time;

        public readonly Double Distance;

        public readonly Double FuelCost;

        public readonly Double TotalCost;

        public Route(List<Address> stops, RouteType type, string time, double distance, double fuelCost, double totalCost)
        {
            Stops = stops;
            Type = type;
            Time = time;
            Distance = distance;
            FuelCost = fuelCost;
            TotalCost = totalCost;
        }
    }
}
