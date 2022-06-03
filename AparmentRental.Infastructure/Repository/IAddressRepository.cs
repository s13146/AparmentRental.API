using AparmentRental.Infrastructure.Entities;

namespace AparmentRental.Infastructure.Repository;

public interface IAddressRepository : IRepository<Address>
{
    Task<int> GetAddressIdByItsAttributesAsync(string country, string city, string postCode, string street, string buildingNumber, string apartmentNumber);
    Task<Address> CreateAndGetAsync(Address address);
    Task<Address?> FindAndGetAddressAsync(Address address);
}
