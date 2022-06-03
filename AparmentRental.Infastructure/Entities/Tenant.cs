
namespace AparmentRental.Infrastructure.Entities;

public class Tenant : BaseEntity
{
    public Apartment Apartment { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
}