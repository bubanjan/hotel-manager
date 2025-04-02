using HotelManagerAPI.Mappers;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerAPI.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        [HttpGet("{id}", Name = "GetGuest")]
        public async Task<ActionResult<GuestDto>> GetGuest(Guid id)
        {
            var guestDto = await _guestRepository.GetGuestAsync(id);
            if (guestDto == null)
            {
                return NotFound();
            }

            return Ok(guestDto);
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> CreateGuest(GuestForCreationDto guestForCreation)
        {
            var guest = GuestMapper.MapToGuest(guestForCreation);

            await _guestRepository.AddGuestAsync(guest);
            await _guestRepository.SaveChangesAsync();

            var estateToReturn = GuestMapper.MapToGuestDto(guest);

            return CreatedAtRoute("GetGuest", new { id = estateToReturn.Id }, estateToReturn);
        }
    }
}