using HotelHTTP_Client_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelHTTP_Client_WPF.Service
{
    class HotelService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public HotelService() 
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5229/");
        }

        public async Task<List<Room>> GetAvaibleRoomsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Room>>("api/Rooms/Available");
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Помилка при отриманні номерів: {ex.Message}");
                return new List<Room>();
            }
        }

        public async Task<bool> BookRoomAsync(int roomId, DateTime startTime, DateTime endTime)
        {
            var booking = new
            {
                RoomId = roomId,
                StartTime = startTime,
                EndTime = endTime
            };

            var responce = await _httpClient.PostAsJsonAsync("api/Rooms/Book", booking);
            return responce.IsSuccessStatusCode;
        }
    }
}
