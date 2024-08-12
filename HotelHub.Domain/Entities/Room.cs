using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHub.Domain.entities
{
    public class Room
    {
        public Room()
        {
            HotelId = 1;
        }
        public int RoomID { get; set; }              
        [MaxLength(24)]
        public string RoomNumber { get; set; }      
        [MaxLength(24)]
        public string Type { get; set; }             
        public decimal Price { get; set; }           
        public bool IsAvailable { get; set; }       
        public int HotelId { get; set; }

        public bool AirCondition { get; set; }

        public Hotel Hotel { get; set; }            
    }
}
