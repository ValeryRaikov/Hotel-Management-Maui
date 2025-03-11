using HotelManagement.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DbContexts
{
    public class ReserveRoomDbContext : DbContext
    {
        public ReserveRoomDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
