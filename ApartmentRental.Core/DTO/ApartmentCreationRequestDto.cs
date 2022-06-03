namespace AparmentRental.Core.DTO;

public class ApartmentCreationRequestDto
{
    public decimal Price { get; set; }
    public int RoomsNumber { get; set; }
    public int Square { get; set; }
    public int Floor { get; set; }
    public bool IsElevator { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public string ApartmentNumber { get; set; }
    public string BuildingNumber { get; set; }
    public string Country { get; set; }
    public int LandlordId { get; set; }

    public ApartmentCreationRequestDto(decimal price, int roomsNumber, int square, int floor, bool isElevator, string city, string street, string postCode, string apartmentNumber, string buildingNumber, string country, int landlordId)
    {
        Price = price;
        RoomsNumber = roomsNumber;
        Square = square;
        Floor = floor;
        IsElevator = isElevator;
        City = city;
        Street = street;
        PostCode = postCode;
        ApartmentNumber = apartmentNumber;
        BuildingNumber = buildingNumber;
        Country = country;
        LandlordId = landlordId;
    }
}