using Common.Layer;
using Microsoft.AspNetCore.Mvc;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Restaurants;
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

        [HttpGet]
        public async Task<IActionResult> GetAllWithSpecs([FromQuery] RestaurantSpecification specs)
        {
            var restaurants = await _restaurantService.GetRestaurantsWithSpecs(specs);

            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginatedWithSpecs([FromQuery] RestaurantSpecificationWithPagination specs)
        {
            var restaurants = await _restaurantService.GetRestaurantsPaginatedWithSpecs(specs);

            return Ok(restaurants);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var restaurant = await _restaurantService.GetRestaurantById(id);
            return Ok(restaurant);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet]
        public async Task<IActionResult> GetWithSpecs([FromQuery] RestaurantSpecification specs)
        {
            var restaurant = await _restaurantService.GetRestaurantWithSpecs(specs);
            return Ok(restaurant);
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _restaurantService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
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
