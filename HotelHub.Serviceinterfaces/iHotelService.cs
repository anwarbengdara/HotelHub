using HotelHub.Domain.entities;

namespace HotelHub.Serviceinterfaces
{
    public interface ihotelService
    {
        Task Save(Hotel hotel); 
        Task<Hotel> Get(int hotelid); 
        Task Update(Hotel hotel); 
        Task Delete(int hotelid);
    }
}
