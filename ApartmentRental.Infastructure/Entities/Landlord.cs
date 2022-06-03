using ApartmentRental.Infrastructure.Entities;

namespace AparmentRental.Infrastructure.Entities;

public class Landlord : BaseEntity
{
    public List<Apartment> Apartments { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}