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
        public Hotel Get(int hotelid)
        {
            using var db = _contextFactory.CreateDbContext();

            var hotel = db.Hotel.FirstOrDefault(x => x.HotelID == hotelid);
            return hotel;
        }
        public void Update(Hotel hotel)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Hotel.FirstOrDefault(y => y.HotelID == hotel.HotelID);

            if (tmp != null)
            {
                tmp.Email = hotel.Email;
                tmp.PhoneNumber = hotel.PhoneNumber;
                tmp.Name = hotel.Name;
                tmp.Rating = hotel.Rating;

                db.SaveChanges();
            }
        }
        public void Save(Hotel hotel)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Hotel.FirstOrDefault(x => x.HotelID == hotel.HotelID);

            if (tmp == null)
            {
                db.Hotel.Add(hotel);
                db.SaveChanges();
            }
        }

        
    }
}
