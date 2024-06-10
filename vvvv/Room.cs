using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHub.Domain
{
    public class Room
    {
        public int RoomID { get; set; }              // معرف فريد لكل غرفة (Primary Key)
        public string RoomNumber { get; set; }       // رقم الغرفة (مطلوب، الحد الأقصى للطول 10 أحرف)
        public int HotelID { get; set; }             // معرف الفندق (مفتاح أجنبي)
        public string Type { get; set; }             // نوع الغرفة (الحد الأقصى للطول 50 حرف)
        public decimal Price { get; set; }           // سعر الغرفة (10 أرقام، 2 منها بعد الفاصلة العشرية)
        public bool IsAvailable { get; set; }        // تحديد ما إذا كانت الغرفة متوفرة أم لا (مطلوب)
        public Hotel Hotel { get; set; }             // العلاقة مع الفندق
    }
}

