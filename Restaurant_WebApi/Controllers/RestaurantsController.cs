using Common.Layer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.Commands;
using Service.Layer.DTOs.Restaurants;
using Service.Layer.Queries.GetRestaurant;
using Service.Layer.Queries.GetRestaurants;
using Service.Layer.Restaurants;
using Service.Layer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<RestaurantsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());

            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithSpecs([FromQuery] GetAllRestaurantsWithSpecsQuery specs)
        {
            var restaurants = await _mediator.Send(specs);

            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginatedWithSpecs([FromQuery] GetRestaurantsPaginatedWithSpecsQuery specs)
        {

            var restaurants = await _mediator.Send(specs);

            return Ok(restaurants);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetRestaurantByIdQuery getRestaurantByIdQuery)
        {
            var restaurant = await _mediator.Send(getRestaurantByIdQuery);
            return Ok(restaurant);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet]
        public async Task<IActionResult> GetWithSpecs([FromQuery] GetRestaurantWithSpecsQuery specs)
        {
            var restaurant = await _mediator.Send(specs);
            return Ok(restaurant);
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantCommand createRestaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(createRestaurantDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] CreateRestaurantDto createRestaurantDto)
        {

        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
