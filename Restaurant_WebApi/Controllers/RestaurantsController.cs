using Common.Layer;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Restaurants;
using Service.Layer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        // GET: api/<RestaurantsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantService.GetRestaurants();

            return Ok(restaurants);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
