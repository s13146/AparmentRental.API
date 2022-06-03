using AparmentRental.Infastructure.Context;
using AparmentRental.Infastructure.Exceptions;
using AparmentRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AparmentRental.Infastructure.Repository;

public class ImageRepository : IImageRepository 
{
    private readonly MainContext _mainContext;

    public ImageRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task AddAsync(Image entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Image>> GetAllAsync()
    {
        var image = await _mainContext.Image.ToListAsync();
        return image;
    }

    public async Task<Image> GetByIdAsync(int id)
    {
        var image = await _mainContext.Image.SingleOrDefaultAsync(x => x.Id == id);
        if (image != null)
        {
            return image;
        }

        throw new EntityNotFoundException();
    }

    public async Task UpdateAsync(Image entity)
    {
        var imageToUpdate = await _mainContext.Image.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (imageToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        imageToUpdate.Data = entity.Data;
        imageToUpdate.ApartmentId = entity.ApartmentId;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var imageToDelete = await _mainContext.Image.SingleOrDefaultAsync(x => x.Id == id);
        if (imageToDelete != null)
        {
            _mainContext.Image.Remove(imageToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}