using AparmentRental.Core.DTO;
using AparmentRental.Infastructure.Repository;
using AparmentRental.Infrastructure.Entities;

namespace AparmentRental.Core.Services;

public class LandlordService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ILandlordRepository _landlordRepository;

    public LandlordService(IAddressRepository addressRepository, ILandlordRepository landlordRepository)
    {
        _addressRepository = addressRepository;
        _landlordRepository = landlordRepository;
    }
    public async Task AddNewLandlordAsync(LandlordCreationRequestDto dto)
    {
        var address = await _addressRepository.FindAndGetAddressAsync(new Address()
        {
            FlatNumber = dto.AppartmentNumber,
            Street = dto.Street,
            BulidNumber = dto.BuildingNumber,
            City = dto.City,
            Country = dto.Country,
            PostCode = dto.PostCode
        });

        await _landlordRepository.AddAsync(new Landlord
        {
            Account = new Account
            {
                AddresId = address.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                IsAccountActive = true,
                PhoneNumber = dto.Telephone,
                DateOfCreation = DateTime.UtcNow,
                DateOfUpdate = DateTime.UtcNow
            },
            DateOfCreation = DateTime.UtcNow,
            DateOfUpdate = DateTime.UtcNow
        });
    }
}