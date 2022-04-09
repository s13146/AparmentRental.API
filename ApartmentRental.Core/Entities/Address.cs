namespace AparmentRental.Core.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string? FlatNumber { get; set; }
    public string? BulidNumber  { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }

    public int AddressId { get; set; } 
    public Address Addres { get; set; }
    
    
}