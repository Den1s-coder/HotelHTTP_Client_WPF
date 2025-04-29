using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHTTP_Client_WPF.Model
{
    class BookingRequest
    {
        public int RoomId {  get; set; }
        public DateTime Date { get; set; }
    }
}
