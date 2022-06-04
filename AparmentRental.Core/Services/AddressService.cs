
using AparmentRental;
using AparmentRental.Infastructure.Repository;
using AparmentRental.Infrastructure.Entities;

namespace AparmentRental.Core.Services;

public class AddressService : IAddressService

{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int> GetAddressIdOrCreateAsync(string country, string city, string postCode, string street, string buildingNumber,
        string apartmentNumber)
    {
        var id = await _addressRepository.GetAddressIdByItsAttributesAsync(country, city, postCode, street,
            buildingNumber, apartmentNumber);
        if (id != 0)
        {
            return id;
        }

        var address = await _addressRepository.CreateAndGetAsync(new Address()
        {
            Country = country,
            City = city,
            PostCode = postCode,
            Street = street,
            BulidNumber = buildingNumber,
            FlatNumber = apartmentNumber
        });
        return address.Id;
    }
}