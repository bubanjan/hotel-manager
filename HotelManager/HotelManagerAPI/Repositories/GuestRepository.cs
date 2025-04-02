using HotelManagerAPI.DbContexts;
using HotelManagerAPI.Entities;
using HotelManagerAPI.Mappers;
using HotelManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerAPI.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelManagerDbContext _context;

        public GuestRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public async Task<GuestDto> GetGuestAsync(Guid guestId)
        {
            return await _context.Guests
                            .Where(x => x.Id == guestId)
                            .Select(GuestMapper.ToGuestDto())
                            .FirstOrDefaultAsync();
        }

        public async Task<Guest> GetGuestEntityAsync(Guid guestId)
        {
            return await _context.Guests
                            .Where(x => x.Id == guestId)
                            .FirstOrDefaultAsync();
        }

        public async Task AddGuestAsync(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}