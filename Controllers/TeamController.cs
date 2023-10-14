using Microsoft.AspNetCore.Mvc;
using UserAuth.Api.Data;
using UserAuth.Api.DTOs;
using UserAuth.Api.Models;

namespace UserAuth.Api.Controllers
{
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TeamController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamRequestDto teamDto)
        {
            if (ModelState.IsValid)
            {
                // Manually map properties from the DTO to the entity
                var team = new Team
                {
                    Name = teamDto.Name,
                    Year = teamDto.Year,
                };

                _context.Teams.Add(team);

                // Use await with SaveChangesAsync
                await _context.SaveChangesAsync();

                // Create a response DTO if needed
                var responseDto = new TeamResponseDto
                {
                    Id = team.Id,
                    // Other properties
                };

                // Return the response
                return CreatedAtRoute("GetTeam", new { id = responseDto.Id }, responseDto);
            }

            return BadRequest("Invalid request payload");
        }
    }
}