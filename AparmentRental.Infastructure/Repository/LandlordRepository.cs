using AparmentRental.Infastructure.Context;
using AparmentRental.Infastructure.Exceptions;
using AparmentRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AparmentRental.Infastructure.Repository;

public class LandlordRepository : ILandlordRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<ILandlordRepository> _logger;

    public LandlordRepository(MainContext mainContext, ILogger<LandlordRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }
    public async Task<IEnumerable<Landlord>> GetAllAsync()
    {
        var landlord = await _mainContext.Landlord.ToListAsync();
        return landlord;
    }

    public async Task<Landlord> GetByIdAsync(int id)
    {
        var landlord = await _mainContext.Landlord.SingleOrDefaultAsync(x => x.Id == id);
        if (landlord == null)
        {
            _logger.LogError("Cannot find landlord with provided id: {LandLordId}", id);
            throw new EntityNotFoundException();
        }

        return landlord;
    }

    public async Task AddAsync(Landlord entity)
    {
        var landlordToAdd = await _mainContext.Landlord.AnyAsync(x => x.Id == entity.Id);
        if (landlordToAdd)
        {
            throw new EntityAlreadyExistsException();
        }
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Landlord entity)
    {
        var landlordToUpdate = await _mainContext.Landlord.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (landlordToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        landlordToUpdate.Apartments = entity.Apartments;
        landlordToUpdate.AccountId = entity.AccountId;
        landlordToUpdate.Account = entity.Account;
        landlordToUpdate.DateOfUpdate = DateTime.UtcNow;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var landLordToDelete = await _mainContext.Landlord.SingleOrDefaultAsync(x => x.Id == id);
        if (landLordToDelete == null)
        {
            throw new EntityNotFoundException();
        }

        _mainContext.Landlord.Remove(landLordToDelete);
        await _mainContext.SaveChangesAsync();
    }
}