using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAuth.Api.Data;
using UserAuth.Api.DTOs;
using UserAuth.Api.Models;

namespace UserAuth.Api.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController: ControllerBase
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
                _context.SaveChanges();

                // Create a response DTO if needed
                var responseDto = new DriverResponseDto
                {
                    Id = driver.Id,
                    // Other properties
                };

                // Return the response
                return CreatedAtRoute("GetDriver", new { id = responseDto.Id }, responseDto);
            }

            return BadRequest("Invalid request payload");
        }

    }
}