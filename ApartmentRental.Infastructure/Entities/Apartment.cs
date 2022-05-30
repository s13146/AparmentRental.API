using Microsoft.VisualBasic.CompilerServices;

namespace AparmentRental.Core.Entities;

public class Apartment : BaseEntity
{
    public decimal Price { get; set; }
    public string RoomNumber { get; set; }
    public int Floor { get; set; }
    public bool IsElevator { get; set; }

    public int LandlordId { get; set; }
    
    public Landlord Landlord { get; set; }
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public IEnumerable<Image> Images { get; set; }

}