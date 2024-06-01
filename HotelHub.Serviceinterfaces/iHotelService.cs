using HotelHub.Domain.entities;

namespace HotelHub.Serviceinterfaces
{
    public interface ihotelService
    {
        void Save(Hotel hotel);
        Hotel Get(int hotelid); 
        void Update(Hotel hotel);
    }
}
