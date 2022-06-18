using System.Collections.Generic;
using System.Threading.Tasks;
using AparmentRental.Core.Services;
using AparmentRental.Infastructure.Repository;
using AparmentRental.Infrastructure.Entities;
using ApartmentRental.Core.Services;
using ApartmentRental.Infastructure.Repository;
using FluentAssertions;
using Moq;
using Xunit;

namespace AparmentRental.Tests;

public class ApartmentServiceTests
{
    [Fact]
    public async Task GetTheCheapestApartmentAsync_ShouldReturnNull_WhenApartmentsCollectionIsNull()
    {
        var sut = new ApartmentService(Mock.Of<IApartmentRepository>(), Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());
        var result = await sut.GetTheCheapestApartmentAsync();
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetTheCheapestApartment_SchouldReturnTheCheapesApartment()
    {
        var apartments = new List<Apartment>
        {
            new()
            {
                Address = new Address()
                {
                    City = "Gdansk",
                    Country = "Poland",
                    Street = "Szeroka",
                    FlatNumber = "2",
                    BulidNumber = "1",
                    PostCode = "80-324",
                },
                Floor = 2,
                Price = 3000,
                SquareMeters = 85,
                RoomNumber = 5,
                IsElevator = true,
            },
            new()
            {
                Address = new Address()
                {
                    City = "Gdynia",
                    Country = "Poland",
                    Street = "Waska",
                    FlatNumber = "5",
                    BulidNumber = "4",
                    PostCode = "99-324",
                },
                Floor = 2,
                Price = 1500,
                SquareMeters = 35,
                RoomNumber = 2,
                IsElevator = true,
            }
        };
        
        var apartmentRepositoryMock = new Moq.Mock<IApartmentRepository>();
        apartmentRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(apartments);

        var sut = new ApartmentService(apartmentRepositoryMock.Object, Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());

        var result = await sut.GetTheCheapestApartmentAsync();
        result.Should().NotBeNull();
        result.City.Should().Be("Gdynia");
        result.Street.Should().Be("Waska");
       // result.Price.Should().Be(1500);
        //result.Square.Should().Be(42);
       // result.RoomsNumber.Should().Be(1);
        //result.IsElevator.Should().BeTrue();
    }
    
}