using HotelManagerAPI.DbContexts;
using HotelManagerAPI.Entities;
using HotelManagerAPI.Mappers;
using HotelManagerAPI.Models;
using HotelManagerAPI.Pagination;
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

        public async Task<(IEnumerable<GuestDto>, PaginationMetadata)> GetGuestsAsync(int pageNumber, int pageSize, string? searchWord)
        {
            var collection = _context.Guests.AsQueryable();

            if (string.IsNullOrEmpty(searchWord) == false)
            {
                collection = collection.Where(x => x.FirstName != null && x.LastName != null &&
                                             (x.FirstName.ToLower() + " " + x.LastName.ToLower()).Contains(searchWord.ToLower()));
            }

            var totalItemsCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemsCount, pageSize, pageNumber);

            var collectionToReturn = await collection
                .OrderBy(o => o.FirstName)
                .ThenBy(o => o.LastName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Select(GuestMapper.ToGuestDto())
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<GuestDto> GetGuestAsync(Guid guestId)
        {
            return await _context.Guests
                            .Where(x => x.Id == guestId)
                            .Select(GuestMapper.ToGuestDto())
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteGuestAsync(Guid guestId)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(x => x.Id == guestId);
            if (guest == null)
            {
                return false;
            };
            _context.Guests.Remove(guest);
            return true;
        }

        public async Task<Guest> GetGuestEntityAsync(Guid guestId)
        {
            return await _context.Guests.FirstOrDefaultAsync(x => x.Id == guestId);
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