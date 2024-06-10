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

        public async Task Save(Room room)
        {
            using var db = _contextFactory.CreateDbContext();//

            var tmp = await db.Rooms.FirstOrDefaultAsync(x => x.RoomID == room.RoomID);

            if (tmp == null)
            {
                db.Rooms.Add(room);
                db.SaveChangesAsync();
            }
        }

        public async Task Delete(Room room)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = await db.Rooms.FirstOrDefaultAsync(x => x.RoomID == room.RoomID);

            if (tmp != null)
            {
                db.Rooms.Remove(tmp);
                db.SaveChangesAsync();
            }
        }

        public async Task<Room> Get(int roomid)
        {
            using var db = _contextFactory.CreateDbContext();

            var room = await db.Rooms.FirstOrDefaultAsync(x => x.RoomID == roomid);
            return room;
        }

        public async Task<List<Room>> GetAll()
        {
            using var db = _contextFactory.CreateDbContext();

            return [.. await db.Rooms.ToListAsync()];
        }

        public async Task Update(Room room)
        {
            using var db = (_contextFactory.CreateDbContext());

            var tmp = await db.Rooms.FirstOrDefaultAsync(x => x.RoomID == room.RoomID);

            if (tmp != null)
            {
                tmp.RoomNumber = room.RoomNumber;
                tmp.Type = room.Type;
                tmp.Price = room.Price;
                tmp.IsAvailable = room.IsAvailable;

                db.SaveChangesAsync();
            }
        }
    }
}


