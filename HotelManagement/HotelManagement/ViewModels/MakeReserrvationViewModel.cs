using HotelManagement.Services;
using HotelManagement.Stores;
using HotelManagement.Commands;
using System.Windows.Input;

namespace HotelManagement.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _username;
        private int _floorNumber;
        private int _roomNumber;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public int FloorNumber
        {
            get { return _floorNumber; }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(HotelStore hotelStore, NavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}