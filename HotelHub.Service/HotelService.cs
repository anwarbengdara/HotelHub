using HotelHub.Domain.entities;
using HotelHub.persistance;
using HotelHub.Serviceinterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHub.Service
{
    public class HotelService : ihotelService
    {
        private readonly IDbContextFactory<HotelHubContext> _contextFactory;    

        public HotelService(IDbContextFactory<HotelHubContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Hotel> Get(int hotelid)
        {
            using var db = _contextFactory.CreateDbContext();

            var hotel =await db.Hotel.FirstOrDefaultAsync(x => x.HotelID == hotelid);
            return hotel;
        } 
        public async Task Update(Hotel hotel)
        {
            using var db =  _contextFactory.CreateDbContext();

            var tmp = await db.Hotel.FirstOrDefaultAsync(y => y.HotelID == hotel.HotelID);

            if (tmp != null)
            {
                tmp.Email = hotel.Email;
                tmp.PhoneNumber = hotel.PhoneNumber;
                tmp.Name = hotel.Name;
                tmp.Rating = hotel.Rating;

                db.SaveChangesAsync();
            }
        }
        public async Task Save(Hotel hotel)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = await db.Hotel.FirstOrDefaultAsync(x => x.HotelID == hotel.HotelID);

            if (tmp == null)
            {
                db.Hotel.Add(hotel);
                db.SaveChangesAsync();
            }
        }
        public async Task Delete(int hotel)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = await db.Hotel.FirstOrDefaultAsync(x => x.HotelID == hotel);

            if (tmp != null)
            {
                db.Hotel.Remove(tmp);
                db.SaveChangesAsync();
            }
        }

    }
}
