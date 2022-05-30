using AparmentRental.Core.Entities;

namespace AparmentRental.Infastructure.Repository;

public interface IApartmentRepository : IRepository<Apartment>
{
    Task<IEnumerable<Apartment>> IRepository<Apartment>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Apartment> IRepository<Apartment>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Task IRepository<Apartment>.Add(Apartment entity)
    {
        throw new NotImplementedException();
    }

    Task IRepository<Apartment>.Update(Apartment entity)
    {
        throw new NotImplementedException();
    }

    Task IRepository<Apartment>.DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}