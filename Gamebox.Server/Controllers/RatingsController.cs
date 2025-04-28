using Gamebox.Server.DTO;
using Gamebox.Server.Models;
using Gamebox.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Gamebox.Server.Controllers
{
    [ApiController]
    [EnableCors("Policy")]
    [Route("ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsService _ratingsService;

        public RatingsController(RatingsService ratingsService)
        {
            _ratingsService = ratingsService;
        }


        [HttpGet()]
        public async Task<ActionResult<List<Rating>>> GetRatings([FromQuery(Name="projection")] string ProjectionName)
        {
            if(ProjectionName.ToLower().Equals("highestweighted"))
            {
                return await _ratingsService.GetHighestRatingsWeighted();
            } else if (ProjectionName.ToLower().Equals("recent"))
            {
                return await _ratingsService.GetRecentRatings();
            } else
            {
                return BadRequest("Projection not sent");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRatingByRatingId(string id)
        {
            var rating = await _ratingsService.GetRatingById(id);

            if (rating is null)
            {
                return NotFound();
            }

            return rating;
        }

        [HttpGet("{id}/user")]
        public async Task<ActionResult<List<Rating>>> GetRatingsByUserId(string id)
        {
            var rating = await _ratingsService.GetRatingsByUserId(id);

            if (rating is null)
            {
                return NotFound();
            }

            return rating;
        }

        [HttpGet("{id}/game")]
        public async Task<ActionResult<List<Rating>>> GetRatingsByGameId(string id)
        {
            var rating = await _ratingsService.GetRatingsByGameId(id);

            if (rating is null)
            {
                return NotFound();
            }

            return rating;
        }

        [HttpPost()]
        public ActionResult<Rating> CreateRating([FromBody] RatingDTO rating)
        {
            try
            {
                _ratingsService.CreateRating(rating);
            }
            catch (Exception ex)
            {
                return BadRequest("Error creating rating: " + ex);
            }
            return Ok();

        }
    }
}
