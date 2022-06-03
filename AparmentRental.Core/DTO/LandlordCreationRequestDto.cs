namespace AparmentRental.Core.DTO;

public class LandlordCreationRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string Street { get; set; }
    public string AppartmentNumber { get; set; }
    public string BuildingNumber { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
}