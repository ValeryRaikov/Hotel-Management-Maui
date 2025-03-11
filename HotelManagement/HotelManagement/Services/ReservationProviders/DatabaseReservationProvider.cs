using HotelManagement.DbContexts;
using HotelManagement.DTOs;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReserveRoomDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(ReserveRoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (ReserveRoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.Username, dto.StartTime, dto.EndTime);
        }
    }
}
