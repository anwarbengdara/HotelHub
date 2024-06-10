using HotelHub.Domain.entities;

namespace HotelHub.Serviceinterfaces
{
    public interface iRoomService
    {
        Task Delete(Room room);
        Task<Room> Get(int roomid);   
        Task Save(Room room);
        Task Update(Room room);
        Task<List<Room>>  GetAll();

    }
}
