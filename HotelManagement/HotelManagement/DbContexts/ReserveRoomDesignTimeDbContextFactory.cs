using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelManagement.DbContexts
{
    public class ReserveRoomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReserveRoomDbContext>
    {
        public ReserveRoomDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=hotel.db").Options;

            return new ReserveRoomDbContext(options);
        }
    }
}
