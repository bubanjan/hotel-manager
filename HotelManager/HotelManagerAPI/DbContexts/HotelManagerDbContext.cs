using HotelManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerAPI.DbContexts
{
    public class HotelManagerDbContext : DbContext
    {
        public HotelManagerDbContext(DbContextOptions<HotelManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
    }
}