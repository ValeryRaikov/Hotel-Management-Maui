using HotelManagement.Stores;
using HotelManagement.ViewModels;

namespace HotelManagement.Commands
{
    public class LoadReservationCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly HotelStore _hotelStore;

        public LoadReservationCommand(ReservationListingViewModel viewModel, HotelStore hotelStore)
        {
            _viewModel = viewModel;
            _hotelStore = hotelStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _hotelStore.Load();

                _viewModel.UpdateReservations(_hotelStore.Reservations);
            }
            catch (Exception)
            {
                // MessageBox.Show("Failed to load reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}