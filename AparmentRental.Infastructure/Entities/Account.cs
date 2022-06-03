using AparmentRental.Infrastructure.Entities;

namespace AparmentRental.Infrastructure.Entities;

public class Account : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAccountActive { get; set; }
    
    public int AddresId { get; set; }
    public Address Address { get; set; }
}