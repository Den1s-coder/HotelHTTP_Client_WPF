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
            if (RoomsDataGrid.SelectedItem is Room selectedRoom && DatePicker.SelectedDate.HasValue)
            {
                var responce = await _hotelService.BookRoomAsync(selectedRoom.Id,DatePicker.SelectedDate.Value);
                if (responce)
                {
                    MessageBox.Show("Бронювання успішне");
                }
                else 
                { 
                    MessageBox.Show("Не вдалося забронювати номер"); 
                }
            }
        }
    }
}