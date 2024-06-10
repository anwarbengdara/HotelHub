using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHub.Domain
{
    public class Hotel
    {
            public int HotelID { get; set; }              // معرف فريد للفندق
            public string Name { get; set; }              // اسم الفندق
            public string Address { get; set; }           // عنوان الفندق
            public string PhoneNumber { get; set; }       // رقم هاتف الفندق
            public string Email { get; set; }             // البريد الإلكتروني للفندق
            public decimal Rating { get; set; }           // تقييم الفندق
           // public string ImageUrl { get; set; }          // رابط لصورة الفندق
            public List<Room> Rooms { get; set; }         // قائمة الغرف المرتبطة بهذا الفندق
        


    }
}
