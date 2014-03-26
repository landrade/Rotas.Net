using Routes.Domain;
using System;

namespace Routes.Repositories
{
    public interface IAddressRepository
    {
        Address GetBy(String street, String houseNumber, String city, String state);
    }
}
