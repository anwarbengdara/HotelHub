using Microsoft.EntityFrameworkCore;
using HotelHub.Domain.entities;
using HotelHub.persistance;
using HotelHub.Serviceinterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace HotelHub.Service
{
    public class RoomService : iRoomService
    {
        private readonly IDbContextFactory<HotelHubContext> _contextFactory;

        public RoomService(IDbContextFactory<HotelHubContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public void Save(Room room)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Rooms.FirstOrDefault(x => x.RoomID == room.RoomID);

            if (tmp == null)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
            }
        }

        public void Delete(Room room)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Rooms.FirstOrDefault(x => x.RoomID == room.RoomID);

            if (tmp != null)
            {
                db.Rooms.Remove(tmp);
                db.SaveChanges();
            }
        }

        public Room Get(int roomid)
        {
            using var db = _contextFactory.CreateDbContext();

            var room = db.Rooms.FirstOrDefault(x => x.RoomID == roomid);
            return room;
        }

        public List<Room> GetAll()
        {
            using var db = _contextFactory.CreateDbContext();

            return [.. db.Rooms];
        }

        public void Update(Room room)
        {
            using var db = (_contextFactory.CreateDbContext());

            var tmp = db.Rooms.FirstOrDefault(x => x.RoomID == room.RoomID);

            if (tmp != null)
            {
                tmp.RoomNumber = room.RoomNumber;
                tmp.Type = room.Type;
                tmp.Price = room.Price;
                tmp.IsAvailable = room.IsAvailable;

                db.SaveChanges();
            }
        }
    }
}


