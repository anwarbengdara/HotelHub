using HotelHub.Domain.entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHub.persistance
{
    public class HotelHubContext : DbContext
    {
        public HotelHubContext(DbContextOptions<HotelHubContext> options) :
             base(options)
        {

        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
