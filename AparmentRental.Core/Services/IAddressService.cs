namespace AparmentRental.Core.Services;

public interface IAddressService
{
    public Task<int> GetAddressIdOrCreateAsync(string country, string city, string postCode, string street, string buildingNumber, string apartmentNumber);

}