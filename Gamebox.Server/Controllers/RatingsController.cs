using Gamebox.Server.Models;
using Gamebox.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gamebox.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsService _ratingsService;

        public RatingsController(RatingsService ratingsService)
        {
            _ratingsService = ratingsService;
        }


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Rating>> Get(string id)
        {
            var rating = await _ratingsService.GetRatingById(id);

            if (rating is null)
            {
                return NotFound();
            }

            return rating;
        }
    }
}
