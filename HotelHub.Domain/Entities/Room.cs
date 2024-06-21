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
        public int RoomID { get; set; }              // معرف فريد لكل غرفة (Primary Key)
        [MaxLength(24)]
        public string RoomNumber { get; set; }       // رقم الغرفة 
        [MaxLength(24)]
        public string Type { get; set; }             // نوع الغرفة 
        public decimal Price { get; set; }           // سعر الغرفة 
        public bool IsAvailable { get; set; }        // مطلوب تحديد ما إذا كانت الغرفة متوفرة أم لا 
        public Hotel Hotel { get; set; }             // العلاقة مع الفندق
    }
}
