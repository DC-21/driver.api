using Microsoft.AspNetCore.Mvc;
using UserAuth.Api.Data;
using UserAuth.Api.DTOs;
using UserAuth.Api.Models;

namespace UserAuth.Api.Controllers
{
    [ApiController]
    [Route("api/drivermedia")]

    public class DriverMediaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DriverMediaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DriverMediaRequestDto drivermediaDto)
        {
            if (ModelState.IsValid)
            {
                // Manually map properties from the DTO to the entity
                var driverMedia = new DriverMedia
                {
                    DriverId = drivermediaDto.DriverId,
                    Media = drivermediaDto.Media,
                };

                _context.DriverMedias.Add(driverMedia);

                // Use await with SaveChangesAsync
                await _context.SaveChangesAsync();

                // Create a response DTO if needed
                var responseDto = new DriverMediaResponseDto
                {
                    Id = driverMedia.Id,
                    // Other properties
                };

                // Return the response
                return CreatedAtRoute("GetDriver", new { id = responseDto.Id }, responseDto);
            }

            return BadRequest("Invalid request payload");
        }
    }
}