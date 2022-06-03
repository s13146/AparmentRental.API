using AparmentRental.Core.DTO;

namespace AparmentRental.Core.Services;

public interface ILandlordService
{
    Task AddNewLandlordAsync(LandlordCreationRequestDto dto);
}