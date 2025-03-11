using HotelManagement.Models;

namespace HotelManagement.Services.ReservationProviders
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
