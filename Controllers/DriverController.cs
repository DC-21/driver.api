using Microsoft.AspNetCore.Mvc;
using UserAuth.Api.Data;
using UserAuth.Api.DTOs;
using UserAuth.Api.Models;

namespace UserAuth.Api.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DriverController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DriverRequestDto driverDto)
        {
            if (ModelState.IsValid)
            {
                // Manually map properties from the DTO to the entity
                var driver = new Driver
                {
                    TeamId = driverDto.TeamId,
                    Name = driverDto.Name,
                    RacingNumber = driverDto.RacingNumber
                };

                _context.Drivers.Add(driver);
                await _context.SaveChangesAsync();

                // Create a response DTO if needed
                var responseDto = new DriverResponseDto
                {
                    Id = driver.Id,
                    Name = driver.Name,
                    RacingNumber = driver.RacingNumber,
                    // Other properties, if any
                };

                // Return the response
                return CreatedAtRoute("GetDriver", new { id = responseDto.Id }, responseDto);
            }

            return BadRequest("Invalid request payload");
        }

        [HttpGet("{id}", Name = "GetDriver")]
        public async Task<IActionResult> Get(int id)
        {
            // Fetch the driver by ID and return it
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            // Create a response DTO if needed and return it
            var responseDto = new DriverResponseDto
            {
                Id = driver.Id,
                Name = driver.Name,
                RacingNumber = driver.RacingNumber,
                // Other properties, if any
            };

            return Ok(responseDto);
        }
    }

}