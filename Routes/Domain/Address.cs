using System;

namespace Routes.Domain
{
    public class Address
    {
        public readonly String Street;

        public readonly String HouseNumber;

        public readonly String City;

        public readonly String State;

        public readonly Point Point;

        public Address(String street, String houseNumber, String city, String state, Point point)
        {
            if (String.IsNullOrWhiteSpace(street)) throw new ArgumentException("street");
            if (String.IsNullOrWhiteSpace(houseNumber)) throw new ArgumentException("houseNumber");
            if (String.IsNullOrWhiteSpace(city)) throw new ArgumentException("city");
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentException("state");
            if (point == null) throw new ArgumentNullException("point");

            Street = street;
            HouseNumber = houseNumber;
            City = city;
            State = state;
            Point = point;
        }

        protected bool Equals(Address other)
        {
            return string.Equals(Street, other.Street) && string.Equals(HouseNumber, other.HouseNumber) && string.Equals(City, other.City) && string.Equals(State, other.State) && Point.Equals(other.Point);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Street.GetHashCode();
                hashCode = (hashCode*397) ^ HouseNumber.GetHashCode();
                hashCode = (hashCode*397) ^ City.GetHashCode();
                hashCode = (hashCode*397) ^ State.GetHashCode();
                hashCode = (hashCode*397) ^ Point.GetHashCode();
                return hashCode;
            }
        }

    }
}
