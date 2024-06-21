using HotelHub.Domain.entities;
using HotelHub.persistance;
using HotelHub.Service;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HotelHub.Tests.IntegrationTests
{
    public class HotelServiceTests
    {
        private DbContextOptions<HotelHubContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<HotelHubContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private IDbContextFactory<HotelHubContext> GetDbContextFactoryAsync(DbContextOptions<HotelHubContext> options)
        {
            var mockDbFactory = new Mock<IDbContextFactory<HotelHubContext>>();
            mockDbFactory.Setup(f => f.CreateDbContext()).Returns(() => new HotelHubContext(options));
            return mockDbFactory.Object;

        }
        [Fact]
        public async Task Save_ShouldAddHotel()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new HotelService(factory);
            var hotel = new Hotel { Name = "Bab Al Baher", PhoneNumber = "123456789", Email = "author@company.com" , Address="benghazi", Rating=7};

            // Act
            await service.Save(hotel);

            // Assert
            using var context = new HotelHubContext(options);
            var savedHotel = await context.Hotel.FirstOrDefaultAsync(a => a.Name == "Bab Al Baher");
            Assert.NotNull(savedHotel);
        }
        [Fact]
        public async Task Get_ShouldReturnHotelById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new HotelService(factory);
            var hotel = new Hotel { Name = "Bab Al Baher", PhoneNumber = "123456789", Email = "author@company.com", Address = "benghazi", Rating = 7 };
            await service.Save(hotel);

            // Act
            var fetchedHotel = await service.Get(hotel.HotelID);

            // Assert
            Assert.NotNull(fetchedHotel);
            Assert.Equal(hotel.Name, fetchedHotel.Name);
        }
        [Fact]
        public async Task Delete_ShouldRemoveHotel()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new HotelService(factory);
            var hotel = new Hotel { Name = "Bab Al Baher", PhoneNumber = "123456789", Email = "author@company.com", Address = "benghazi", Rating = 7 };
            await service.Save(hotel);

            // Act
            await service.Delete(hotel.HotelID);

            // Assert
            using var context = new HotelHubContext(options);
            var deletedHotel = await context.Hotel.FindAsync(hotel.HotelID);
            Assert.Null(deletedHotel);
        }

        [Fact]
        public async Task Update_ShouldModifyHotel()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new HotelService(factory);
            var hotel = new Hotel { Name = "Bab Al Baher", PhoneNumber = "123456789", Email = "author@company.com", Address = "benghazi", Rating = 7 };
            await service.Save(hotel);

            // Act
            hotel.Name = "Bab Al Baher";
            hotel.PhoneNumber = "123456789";
            hotel.Email = "author@company.com";
            hotel.Address = "benghazi";
            hotel.Rating = 7;
            
            await service.Update(hotel);

            // Assert
            using var context = new HotelHubContext(options);
            var updatedHotel = await context.Hotel.FindAsync(hotel.HotelID);
            Assert.Equal("Bab Al Baher", updatedHotel.Name);
            Assert.Equal("123456789", updatedHotel.PhoneNumber);
            Assert.Equal("author@company.com", updatedHotel.Email);
            Assert.Equal("benghazi", updatedHotel.Address);
            Assert.Equal(7, updatedHotel.Rating);
          
        }


    }
}
