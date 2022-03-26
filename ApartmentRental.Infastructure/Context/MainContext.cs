using AparmentRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AparmentRental.Infastructure.Context;

public class MainContext : DbContext
{
    public DbSet<Apartment> Apartment { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<Landlord> Landlord { get; set; }
    public DbSet<Tenant> Tenant { get; set; }
    public DbSet<Address> Address { get; set; }
    
    
    public MainContext(DbContextOptions options) : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBulider)
    {
        optionsBulider.UseSqlite("DataSource=abo.ApartmentRental.db");
    }
}