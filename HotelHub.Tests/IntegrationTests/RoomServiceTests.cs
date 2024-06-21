using HotelHub.Domain.entities;
using HotelHub.persistance;
using HotelHub.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Diagnostics;


namespace HotelHub.Tests.IntegrationTests
{
    public class RoomServiceTests
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
        public async Task Save_ShouldAddRoom()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomService(factory);
            var room = new Room { RoomNumber = "55A" , Type = "odd", Price = 400, IsAvailable = true };

            // Act
            await service.Save(room);

            // Assert
            using var context = new HotelHubContext(options);
            var savedRoom = await context.Rooms.FirstOrDefaultAsync(a => a.RoomNumber == "55A");
            Assert.NotNull(savedRoom);
        }
        [Fact]
        public async Task Get_ShouldReturnRoomById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomService(factory);
            var room = new Room { RoomNumber = "55A", Type = "odd", Price = 400, IsAvailable = true };
            await service.Save(room);

            // Act
            var fetchedRoom = await service.Get(room.RoomID);

            // Assert
            Assert.NotNull(fetchedRoom);
            Assert.Equal(room.RoomNumber, fetchedRoom.RoomNumber);
        }
        public async Task GetAll_ShouldReturnAllRooms()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomService(factory);
            await service.Save(new Room { RoomNumber = "55A", Type = "odd", Price = 400, IsAvailable = true });
            await service.Save(new Room { RoomNumber = "55A", Type = "odd", Price = 400, IsAvailable = true });

            // Act
            var rooms = await service.GetAll();

            // Assert
            Assert.Equal(2, rooms.Count);
        }
        [Fact]
        public async Task Delete_ShouldRemoveAuthor()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomService(factory);
            var room = new Room { RoomNumber = "55A", Type = "odd", Price = 400, IsAvailable = true };
            await service.Save(room);

            // Act
            await service.Delete(room);

            // Assert
            using var context = new HotelHubContext(options);
            var deletedRoom = await context.Rooms.FindAsync(room.RoomID);
            Assert.Null(deletedRoom);
        }

        [Fact]
        public async Task Update_ShouldModifyRoom()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomService(factory);
            var room = new Room { RoomNumber = "55A", Type = "odd", Price = 400, IsAvailable = true };
            await service.Save(room);

            // Act
            room.RoomNumber = "55A";
            room.Type = "odd";
            room.Price = 400;
            room.IsAvailable = true ;
            
            await service.Update(room);

            // Assert
            using var context = new HotelHubContext(options);
            var updatedRoom = await context.Rooms.FindAsync(room.RoomID);
            Assert.Equal("55A", updatedRoom.RoomNumber);
            Assert.Equal("odd", updatedRoom.Type);
            Assert.Equal(400, updatedRoom.Price);
            Assert.Equal(true, updatedRoom.IsAvailable);
        }



    }
}
