using HotelManagement.Exceptions;
using HotelManagement.Services.ReservationConflictValidators;
using HotelManagement.Services.ReservationCreators;
using HotelManagement.Services.ReservationProviders;

namespace HotelManagement.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationConflictValidator _reservationConflictValidator;
        
        public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidator reservationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictValidator = reservationConflictValidator;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

        public async Task AddReservation(Reservation reservation)
        {
            Reservation conflictingReservation = await _reservationConflictValidator.GetConflictingReservation(reservation);

            if (conflictingReservation != null)
                throw new ReservationConflictException(conflictingReservation, reservation);

            await _reservationCreator.CreateReservation(reservation);
        }
    }
}
