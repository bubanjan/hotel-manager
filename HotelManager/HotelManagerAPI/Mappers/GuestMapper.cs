using HotelManagerAPI.Entities;
using HotelManagerAPI.Models;
using System.Linq.Expressions;

namespace HotelManagerAPI.Mappers
{
    public static class GuestMapper
    {
        public static Expression<Func<Guest, GuestDto>> ToGuestDto()
        {
            return o => new GuestDto
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Telephone = o.Telephone,
                Email = o.Email,
            };
        }

        public static Guest MapToGuest(GuestForCreationDto guestForCreationDto)
        {
            return new Guest
            {
                FirstName = guestForCreationDto.FirstName,
                LastName = guestForCreationDto.LastName,
                Telephone = guestForCreationDto.Telephone,
                Email = guestForCreationDto.Email,
            };
        }

        public static GuestDto MapToGuestDto(Guest guest)
        {
            return new GuestDto
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Telephone = guest.Telephone,
                Email = guest.Email,
            };
        }
    }
}