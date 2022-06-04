using AparmentRental.Core.DTO;
using AparmentRental.Core.Services;
using AparmentRental.Infastructure.Exceptions;
using AparmentRental.Infastructure.Repository;
using AparmentRental.Infrastructure.Entities;
using ApartmentRental.Infastructure.Repository;


namespace ApartmentRental.Core.Services;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly ILandlordRepository _landlordRepository;
    private readonly IAddressService _addressService;

    public ApartmentService(IApartmentRepository apartmentRepository, ILandlordRepository landlordRepository, IAddressService addressService)
    {
        _apartmentRepository = apartmentRepository;
        _landlordRepository = landlordRepository;
        _addressService = addressService;
    }

    public async Task<IEnumerable<ApartmentBasicInformationResponseDto>> GetAllApartmentsBasicInfosAsync()
    {
        var apartments = await _apartmentRepository.GetAllAsync();
        return apartments.Select(x => new ApartmentBasicInformationResponseDto(
            x.Price,
            x.RoomNumber,
            x.SquareMeters,
            x.IsElevator,
            x.Address.City,
            x.Address.Street
            ));
    }

    public async Task AddNewApartmentToExistingLandLordAsync(ApartmentCreationRequestDto dto)
    {
        var landlord = await _landlordRepository.GetByIdAsync(dto.LandlordId);
        if (landlord == null)
        {
            throw new EntityNotFoundException();
        }
        var addressId = await _addressService.GetAddressIdOrCreateAsync(dto.Country, dto.City, dto.PostCode, dto.Street,
            dto.BuildingNumber, dto.ApartmentNumber);

        await _apartmentRepository.AddAsync(new Apartment
        {
            AddressId = addressId,
            Floor = dto.Floor,
            LandlordId = landlord.Id,
            IsElevator = dto.IsElevator,
            Price = dto.Price,
            SquareMeters = dto.Square,
            RoomNumber = dto.RoomsNumber
        });
    }

    public async Task<ApartmentBasicInformationResponseDto?> GetTheCheapestApartmentAsync()
    {
        var apartments = await _apartmentRepository.GetAllAsync();
        var cheapestOne = apartments.MinBy(x => x.Price);

        if (cheapestOne is null) return null;

        return new ApartmentBasicInformationResponseDto(
            cheapestOne.Price,
            cheapestOne.RoomNumber,
            cheapestOne.SquareMeters,
            cheapestOne.IsElevator,
            cheapestOne.Address.City,
            cheapestOne.Address.Street);
    }
}