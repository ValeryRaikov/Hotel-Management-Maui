using HotelManagement.DbContexts;
using HotelManagement.DTOs;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly ReserveRoomDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReserveRoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using (ReserveRoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations
                    .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
                    .Where(r => r.RoomNumber == reservation.RoomID.RoomNumber)
                    .Where(r => r.EndTime > reservation.StartTime)
                    .Where(r => r.StartTime < reservation.EndTime)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                    return null;

                return ToReservation(reservationDTO);
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.Username, dto.StartTime, dto.EndTime);
        }
    }
}
