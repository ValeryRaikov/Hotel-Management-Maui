using HotelManagement.Models;

namespace HotelManagement.Services.ReservationCreators
{
    public interface IReservationCreator
    {
        Task CreateReservation(Reservation reservation);
    }
}
