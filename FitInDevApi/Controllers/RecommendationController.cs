using Microsoft.AspNetCore.Mvc;
using FitInDevApi.Data;
using FitInDevApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitInDevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly FitContext _context;

        public RecommendationController(FitContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Recommendation>>> GetRecommendations(int userId)
        {
            return await _context.Recommendations
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Recommendation>> CreateRecommendation(Recommendation recommendation)
        {
            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecommendations), new { userId = recommendation.UserId }, recommendation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, Recommendation recommendation)
        {
            if (id != recommendation.Id)
            {
                return BadRequest();
            }

            _context.Entry(recommendation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation == null)
            {
                return NotFound();
            }

            _context.Recommendations.Remove(recommendation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
