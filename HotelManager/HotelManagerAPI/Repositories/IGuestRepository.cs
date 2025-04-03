using HotelManagerAPI.Entities;
using HotelManagerAPI.Models;
using HotelManagerAPI.Pagination;

namespace HotelManagerAPI.Repositories
{
    public interface IGuestRepository
    {
        Task<(IEnumerable<GuestDto>, PaginationMetadata)> GetGuestsAsync(int pageNumber, int pageSize, string? searchWord);

        Task<GuestDto> GetGuestAsync(Guid guestId);

        Task<Guest> GetGuestEntityAsync(Guid guestId);

        Task AddGuestAsync(Guest guest);

        Task<bool> DeleteGuestAsync(Guid id);

        Task SaveChangesAsync();
    }
}