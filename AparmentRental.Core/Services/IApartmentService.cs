using AparmentRental.Core.DTO;

namespace AparmentRental.Core.Services;

public interface IApartmentService
{
    Task<IEnumerable<ApartmentBasicInformationResponseDto>> GetAllApartmentsBasicInfosAsync();
    Task AddNewApartmentToExistingLandLordAsync(ApartmentCreationRequestDto dto);
    Task<ApartmentBasicInformationResponseDto> GetTheCheapestApartmentAsync();

}