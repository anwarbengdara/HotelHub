using HotelHub.Domain.entities;

namespace HotelHub.Serviceinterfaces
{
    public interface iRoomService
    {
        void Delete(Room room);
        Room Get(int roomid);   
        void Save(Room room);
        void Update(Room room);
        List<Room> GetAll();

    }
}
