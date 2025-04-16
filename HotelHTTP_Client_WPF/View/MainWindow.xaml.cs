using HotelHTTP_Client_WPF.Model;
using HotelHTTP_Client_WPF.Service;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace HotelHTTP_Client_WPF.View
{
    public partial class MainWindow : Window
    {
        private HotelService _hotelService = new HotelService();
        private ObservableCollection<Room> _rooms = new ObservableCollection<Room>();

        public MainWindow()
        {
            InitializeComponent();
            RoomsDataGrid.ItemsSource = _rooms;
        }

        private async void LoadRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            var rooms = await _hotelService.GetAvaibleRoomsAsync();
            _rooms.Clear();
            foreach (var room in rooms)
            {
                _rooms.Add(room);
            }
        }

        private async void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsDataGrid.SelectedItem is Room selectedRoom)
            {
                var success = await _hotelService.BookRoomAsync(selectedRoom.Id,DateTime.Today,DateTime.Today.AddDays(1));
                if (success)
                {
                    MessageBox.Show("Бронювання успішне");
                    await LoadAndUpdate();
                }
                else 
                { 
                    MessageBox.Show("Не вдалося забронювати номер"); 
                }
            }
        }

        private async Task LoadAndUpdate()
        {
            var rooms = await _hotelService.GetAvaibleRoomsAsync();
            _rooms.Clear();
            foreach (var room in rooms)
            {
                _rooms.Add(room);
            }
        }
    }
}