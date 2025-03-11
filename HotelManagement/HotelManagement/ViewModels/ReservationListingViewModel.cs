using HotelManagement.Commands;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelManagement.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand LoadReservationCommand { get; }
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            LoadReservationCommand = new LoadReservationCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotelStore, makeReservationNavigationService);

            viewModel.LoadReservationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach (Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
