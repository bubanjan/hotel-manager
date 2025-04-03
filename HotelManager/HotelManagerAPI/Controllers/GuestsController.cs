using HotelManagerAPI.Mappers;
using HotelManagerAPI.Models;
using HotelManagerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotelManagerAPI.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<GuestsController> _logger;
        private const int maxPageSize = 20;

        public GuestsController(IGuestRepository guestRepository, ILogger<GuestsController> logger)
        {
            _guestRepository = guestRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetGuests(int pageNumber = 1, int pageSize = 10, string? searchWord = "")
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be positeve numbers.");
            }

            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            try
            {
                var (guestsDtos, paginationMetadata) = await _guestRepository.GetGuestsAsync(pageNumber, pageSize, searchWord);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                return Ok(guestsDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occured in GetGuests.");
                return StatusCode(500, "An unexpected error occured.Please try again later.");
            }
        }

        [HttpGet("{id}", Name = "GetGuest")]
        public async Task<ActionResult<GuestDto>> GetGuest(Guid id)
        {
            try
            {
                var guestDto = await _guestRepository.GetGuestAsync(id);
                if (guestDto == null)
                {
                    return NotFound();
                }

                return Ok(guestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetGuest for ID {GuestId}", id);
                return StatusCode(500, "An unexpected error occured. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> CreateGuest(GuestForCreationDto guestForCreation)
        {
            try
            {
                var guest = GuestMapper.MapToGuest(guestForCreation);

                await _guestRepository.AddGuestAsync(guest);
                await _guestRepository.SaveChangesAsync();

                var guestToReturn = GuestMapper.MapToGuestDto(guest);

                return CreatedAtRoute("GetGuest", new { id = guestToReturn.Id }, guestToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateGuest");
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(Guid id, GuestForUpdateDto guestUpdateData)
        {
            if (guestUpdateData == null)
            {
                return BadRequest("Guest update data can not be null.");
            }
            try
            {
                var guestEntity = await _guestRepository.GetGuestEntityAsync(id);
                GuestMapper.UpdateGuest(guestEntity, guestUpdateData);
                await _guestRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateGuest for ID {GuestId}", id);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(Guid id)
        {
            try
            {
                var isDeleted = await _guestRepository.DeleteGuestAsync(id);

                if (isDeleted == false)
                {
                    return NotFound();
                }

                await _guestRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteGuest for ID {GuestId}", id);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}