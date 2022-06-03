using AparmentRental.Core.DTO;

namespace ApartmentRental.Core.Services;

public interface ILandlordService
{
    Task AddNewLandlordAsync(LandlordCreationRequestDto dto);
}