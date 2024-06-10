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
        public string RoomNumber { get; set; }       // رقم الغرفة (مطلوب، الحد الأقصى للطول 10 أحرف)
        [MaxLength(24)]
        public string Type { get; set; }             // نوع الغرفة (الحد الأقصى للطول 50 حرف)
        public decimal Price { get; set; }           // سعر الغرفة (10 أرقام، 2 منها بعد الفاصلة العشرية)77777777777777777777
        public bool IsAvailable { get; set; }        // تحديد ما إذا كانت الغرفة متوفرة أم لا (مطلوب)
        public Hotel Hotel { get; set; }             // العلاقة مع الفندق
    }
}
